using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class OutlinePass : ScriptableRenderPass
{
    private string _profilerTag = "Outline";
    private Material _material;

    public OutlinePass(Material material)
    {
        _material = material;
    }
        
    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        var cmd = CommandBufferPool.Get(_profilerTag);

#pragma warning disable CS0618 // Type or member is obsolete
        using (new ProfilingSample(cmd, _profilerTag))
#pragma warning restore CS0618 // Type or member is obsolete
        {
            var mesh = RenderingUtils.fullscreenMesh;
            cmd.DrawMesh(mesh, Matrix4x4.identity, _material, 0, 0);
        }

        context.ExecuteCommandBuffer(cmd);
        CommandBufferPool.Release(cmd);
    }
}
