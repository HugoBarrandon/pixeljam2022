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
//int x;
//int y;
int size;

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

float4 MainPS(VertexShaderOutput input) : COLOR0
{
	float4 color = tex2D(s0, input.TextureCoordinates);
	float s = size / 100.0;
	if (input.TextureCoordinates.x > 0.5-s && input.TextureCoordinates.x < 0.5 + s &&
		input.TextureCoordinates.y > 0.5 - s && input.TextureCoordinates.y < 0.5 + s) {
		color = float4(0,0,0,0);
	}
	else {
		color = float4(0, 0, 0, 1);
	}
	return color;
}

technique SpriteDrawing
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};