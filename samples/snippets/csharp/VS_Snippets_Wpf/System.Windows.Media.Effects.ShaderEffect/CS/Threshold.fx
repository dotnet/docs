// <snippet10>
// Threshold shader 

// Object Declarations

sampler2D implicitInput : register(s0);
float threshold : register(c0);
float4 blankColor : register(c1);

//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------
float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(implicitInput, uv);
    float intensity = (color.r + color.g + color.b) / 3;
    
    float4 result;
    if (intensity > threshold)
    {
        result = color;
    }
    else
    {
        result = blankColor;
    }
    
    return result;
}
// </snippet10>