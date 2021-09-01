Shader "Graph/Point Surface"
{
    Properties
    {
        _Smoothness("Smoothness", Range(0,1)) = 0.5
    }
    SubShader
    {
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface ConfigureSurface Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        struct Input
        {
            float3 worldPos;
        };
        
    float _Smoothness;

    void ConfigureSurface(Input input, inout SurfaceOutputStandard surface)
    {
        // objects worldPos
        // X controls red, Y controls green, Z controls blue
        //surface.Albedo = input.worldPos * 0.5 + 0.5;
        // only use red and green
        surface.Albedo.rg = input.worldPos.xy * 0.5 + 0.5;
        surface.Smoothness = _Smoothness;
    }

        ENDCG
    }
    FallBack "Diffuse"
}
