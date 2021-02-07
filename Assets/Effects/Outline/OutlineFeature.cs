﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class OutlineFeature : ScriptableRendererFeature
{
    [SerializeField] private RenderPassEvent _renderPassEvent;

    [SerializeField] private string _renderTextureName;
    [SerializeField] private RenderSettings _renderSettings;
    private RenderTargetHandle _renderTexture;
    private MyRenderObjectsPass _renderPass;

    [SerializeField] private string _bluredTextureName;
    [SerializeField] private BlurSettings _blurSettings;
    private RenderTargetHandle _bluredTexture;
    private BlurPass _blurPass;

    [SerializeField] private Material _outlineMaterial;
    private OutlinePass _outlinePass;

    public override void Create()
    {
        _renderTexture.Init(_renderTextureName);
        _bluredTexture.Init(_bluredTextureName);

        _renderPass = new MyRenderObjectsPass(
            _renderTexture,
            _renderSettings.LayerMask,
            _renderSettings.OverrideMaterial);
        _blurPass = new BlurPass(
            _renderTexture.Identifier(),
            _bluredTexture,
            _blurSettings.BlurMaterial,
            _blurSettings.DownSample,
            _blurSettings.PassesCount);
        _outlinePass = new OutlinePass(
            _outlineMaterial);

        _renderPass.renderPassEvent = _renderPassEvent;
        _blurPass.renderPassEvent = _renderPassEvent;
        _outlinePass.renderPassEvent = _renderPassEvent;

    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        var depthTexture = renderer.cameraDepth;
        _renderPass.SetDepthTexture(depthTexture);

        renderer.EnqueuePass(_renderPass);
        renderer.EnqueuePass(_blurPass);
        renderer.EnqueuePass(_outlinePass);
    } 
}

[Serializable]
public class RenderSettings
{
    public Material OverrideMaterial = null;
    public LayerMask LayerMask = 0;
}

[Serializable]
public class BlurSettings
{
    public Material BlurMaterial;
    public int DownSample = 1;
    public int PassesCount = 1;
}

