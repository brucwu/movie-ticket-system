// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/SpriteGradient"
{
    Properties
    {
        [PerRendererData] _mainTex("Sprite Texture", 2D) = "white" {}
        _Color("Left Color", Color) = (1,1,1,1)
        _Color2("Right Color", Color) = (1,1,1,1)
        _Scale("Scale", Float) = 1

        _StencilComp("Stencil Comparison", Float) = 8
        _Stencil("Stencil ID", Float) = 0
        _StencilOp("Stencil Operation", Float) = 0
        _StencilWritemask("Stencil Write mask", Float) = 255
        _StencilReadmask("Stencil Read mask", Float) = 255
        _Colormask("Color mask", Float) = 15
        // see for example
        // http://answers.unity3d.com/questions/980924/ui-mask-with-shader.html

    }

    SubShader
    {
        Tags
        {
            "Queue" = "Transparent"
            "IgnoreProjector" = "True"
            "RenderType" = "Transparent"
            "PreviewType" = "Plane"
            "CanUseSpriteAtlas" = "True"
        }


        Stencil
        {
            Ref[_Stencil]
            Comp[_StencilComp]
            Pass[_StencilOp]
            Readmask[_StencilReadmask]
            Writemask[_StencilWritemask]
        }

        Cull Off
        Lighting Off
        ZWrite Off
        ZTest[unity_GUIZTestmode]
        Fog
        {
            mode Off
        }
        Blend SrcAlpha OneminusSrcAlpha
        Colormask[_Colormask]

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float4 color : COLOR;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                fixed4 color : COLOR;
                half2 texcoord : TEXCOORD0;
            };

            fixed4 _Color;
            fixed4 _Color2;

            v2f vert(appdata_t IN)
            {
                v2f OUT;
                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.texcoord = IN.texcoord;
                #ifdef UNITY_HALF_TEXEL_OFFSET
                OUT.vertex.xy += (_ScreenParams.zw - 1.0)*float2(-1,1);
                #endif
                OUT.color = lerp(_Color, _Color2, IN.texcoord.y);
                return OUT;
            }

            sampler2D _MainTex;

            fixed4 frag(v2f i) : COLOR
            {
                fixed4 c = tex2D(_MainTex, i.texcoord) * i.color;
                clip(c.a - 0.01);
                return c;
            }
            ENDCG
        }
    }
}