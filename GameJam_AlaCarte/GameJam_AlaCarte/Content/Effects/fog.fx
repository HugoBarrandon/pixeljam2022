﻿#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

Texture2D SpriteTexture;
sampler s0;
sampler2D SpriteTextureSampler = sampler_state
{
	Texture = <SpriteTexture>;
};

struct VertexShaderOutput
{
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
	float2 TextureCoordinates : TEXCOORD0;
};

float4 MainPS(VertexShaderOutput input) : COLOR
{
	float4 texelColorFromLoadedImage = tex2D(s0, input.TextureCoordinates);
	// we can clip low alpha pixels on the shader if we like directly .. we wont however here.
   // clip(texelColorFromLoadedImage.a - 0.01f);
   float4 theColorWeGaveToSpriteBatchDrawAsaParameter = input.Color;
   float4 blendedColor = texelColorFromLoadedImage * theColorWeGaveToSpriteBatchDrawAsaParameter;
   // Until now blendColor is just like a regular spritebatch draw you are used to.
   // So now we will weight the rgb color elements towards grey,
   // However in this case were not actually doing a greyscale but this is also kinda neat.
   blendedColor.rgb = blendedColor.rgb * 0.5f + 0.5f;
   return blendedColor;
	
}

technique SpriteDrawing
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};