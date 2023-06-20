Shader "Oustom/Portal"
{
    Properties
    {
        [IntRange] _StencillD("Stencil ID",Range(0, 255)) = 0
    }
    
    SubShader 
    {
        Tags
        {
            "Queue" = "Geometry-1"
        }
        Pass
        {
            Zwrite off
            
            ColorMask 0
            
            Cull front
            Stencil
            {
                Ref [_StencillD]
                Comp always
                Pass replace
            }
        }
    }
}