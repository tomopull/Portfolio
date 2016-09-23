// Shader created with Shader Forge v1.28 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.28;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:33678,y:32712,varname:node_4013,prsc:2|emission-719-OUT,clip-4222-OUT;n:type:ShaderForge.SFN_Tex2d,id:623,x:33020,y:32812,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_623,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:73c0c91c860bd4f59b37f6c881a1055f,ntxv:0,isnm:False|UVIN-4525-OUT;n:type:ShaderForge.SFN_Tex2d,id:2752,x:32388,y:32895,ptovrint:False,ptlb:DistortionTex,ptin:_DistortionTex,varname:node_2752,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-6930-UVOUT;n:type:ShaderForge.SFN_Lerp,id:4525,x:32662,y:32898,varname:node_4525,prsc:2|A-5618-UVOUT,B-2752-R,T-8781-OUT;n:type:ShaderForge.SFN_TexCoord,id:5618,x:32388,y:32674,varname:node_5618,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:6930,x:32757,y:32672,varname:node_6930,prsc:2,spu:0,spv:0.1|UVIN-5618-UVOUT;n:type:ShaderForge.SFN_Slider,id:8781,x:32231,y:33144,ptovrint:False,ptlb:Distortion,ptin:_Distortion,varname:node_8781,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.03760684,max:0.1;n:type:ShaderForge.SFN_Tex2d,id:2235,x:33017,y:33007,ptovrint:False,ptlb:AlphaTex,ptin:_AlphaTex,varname:node_2235,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6e052391bdb074650a529b79ef1837fe,ntxv:0,isnm:False;n:type:ShaderForge.SFN_VertexColor,id:5996,x:33017,y:33173,varname:node_5996,prsc:2;n:type:ShaderForge.SFN_Multiply,id:719,x:33384,y:32881,varname:node_719,prsc:2|A-623-RGB,B-5996-RGB,C-1523-RGB,D-777-OUT,E-2235-RGB;n:type:ShaderForge.SFN_Multiply,id:4222,x:33409,y:33099,varname:node_4222,prsc:2|A-623-A,B-5996-A,C-2235-A,D-2235-RGB;n:type:ShaderForge.SFN_Color,id:1523,x:33017,y:33345,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1523,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:777,x:33017,y:33526,ptovrint:False,ptlb:Lightness,ptin:_Lightness,varname:node_777,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;proporder:623-2752-8781-1523-777-2235;pass:END;sub:END;*/

Shader "Shader Forge/TestLiquidShader" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _DistortionTex ("DistortionTex", 2D) = "white" {}
        _Distortion ("Distortion", Range(0, 0.1)) = 0.03760684
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        _Lightness ("Lightness", Float ) = 2
        _AlphaTex ("AlphaTex", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _DistortionTex; uniform float4 _DistortionTex_ST;
            uniform float _Distortion;
            uniform sampler2D _AlphaTex; uniform float4 _AlphaTex_ST;
            uniform float4 _Color;
            uniform float _Lightness;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 node_1583 = _Time + _TimeEditor;
                float2 node_6930 = (i.uv0+node_1583.g*float2(0,0.1));
                float4 _DistortionTex_var = tex2D(_DistortionTex,TRANSFORM_TEX(node_6930, _DistortionTex));
                float2 node_4525 = lerp(i.uv0,float2(_DistortionTex_var.r,_DistortionTex_var.r),_Distortion);
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_4525, _MainTex));
                float4 _AlphaTex_var = tex2D(_AlphaTex,TRANSFORM_TEX(i.uv0, _AlphaTex));
                clip((_MainTex_var.a*i.vertexColor.a*_AlphaTex_var.a*_AlphaTex_var.rgb) - 0.5);
////// Lighting:
////// Emissive:
                float3 emissive = (_MainTex_var.rgb*i.vertexColor.rgb*_Color.rgb*_Lightness*_AlphaTex_var.rgb);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _DistortionTex; uniform float4 _DistortionTex_ST;
            uniform float _Distortion;
            uniform sampler2D _AlphaTex; uniform float4 _AlphaTex_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 node_1058 = _Time + _TimeEditor;
                float2 node_6930 = (i.uv0+node_1058.g*float2(0,0.1));
                float4 _DistortionTex_var = tex2D(_DistortionTex,TRANSFORM_TEX(node_6930, _DistortionTex));
                float2 node_4525 = lerp(i.uv0,float2(_DistortionTex_var.r,_DistortionTex_var.r),_Distortion);
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_4525, _MainTex));
                float4 _AlphaTex_var = tex2D(_AlphaTex,TRANSFORM_TEX(i.uv0, _AlphaTex));
                clip((_MainTex_var.a*i.vertexColor.a*_AlphaTex_var.a*_AlphaTex_var.rgb) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
