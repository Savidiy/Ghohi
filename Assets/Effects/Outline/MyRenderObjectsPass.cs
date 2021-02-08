﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MyRenderObjectsPass : ScriptableRenderPass
{
    private RenderTargetHandle _destination;
    private List<ShaderTagId> _shaderTagIdList = new List<ShaderTagId>() { new ShaderTagId("UniversalForward") };
    private FilteringSettings _filteringSettings;
    private RenderStateBlock _renderStateBlock;
    private Material _overrideMaterial;
    private RenderTargetIdentifier _depth;

    public MyRenderObjectsPass(RenderTargetHandle destination, int layerMask, Material overrideMaterial)
    {
        _destination = destination;
        _filteringSettings = new FilteringSettings(RenderQueueRange.opaque, layerMask);
        _renderStateBlock = new RenderStateBlock(RenderStateMask.Nothing);
        _overrideMaterial = overrideMaterial;
    }

    public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
    {
        cmd.GetTemporaryRT(_destination.id, cameraTextureDescriptor);
        ConfigureTarget(_destination.Identifier(), _depth);
        ConfigureClear(ClearFlag.Color, Color.clear);
    }

    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        SortingCriteria sortingCriteria = renderingData.cameraData.defaultOpaqueSortFlags;
        DrawingSettings drawingSettings = CreateDrawingSettings(_shaderTagIdList, ref renderingData, sortingCriteria);
        drawingSettings.overrideMaterial = _overrideMaterial;
        context.DrawRenderers(renderingData.cullResults, ref drawingSettings, ref _filteringSettings, ref _renderStateBlock);
    }

    public void SetDepthTexture(RenderTargetIdentifier depth)
    {
        _depth = depth;
    }
}
