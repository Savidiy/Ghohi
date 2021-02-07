using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class OutlineFeature : ScriptableRendererFeature
{
    [Serializable]
    public class RenderSettings
    {
        public Material OverrideMaterial = null;
        public LayerMask LayerMask = 0;
    }

    [SerializeField] private string _renderTextureName;
    [SerializeField] private RenderSettings _renderSettings;

    private RenderTargetHandle _renderTexture;
    private MyRenderObjectsPass _renderPass;


    public override void Create()
    {
        _renderTexture.Init(_renderTextureName);
        _renderPass = new MyRenderObjectsPass(_renderTexture, _renderSettings.LayerMask, _renderSettings.OverrideMaterial);
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(_renderPass);
    }
    

}
