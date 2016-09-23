// Shader created with Shader Forge v1.28 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.28;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:33654,y:32365,varname:node_3138,prsc:2|emission-9567-RGB,alpha-9567-A;n:type:ShaderForge.SFN_Tex2d,id:9567,x:33410,y:32440,ptovrint:False,ptlb:Texture2D,ptin:_Texture2D,varname:node_9567,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:edf2fd6cda04cfd4180cf264c8371871,ntxv:0,isnm:False|UVIN-4677-OUT;n:type:ShaderForge.SFN_TexCoord,id:8282,x:32490,y:32645,varname:node_8282,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:5915,x:32993,y:32428,varname:node_5915,prsc:2|A-8329-OUT,B-661-OUT;n:type:ShaderForge.SFN_Divide,id:661,x:32775,y:32294,varname:node_661,prsc:2|A-4623-OUT,B-5836-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4623,x:32492,y:32294,ptovrint:False,ptlb:Value,ptin:_Value,varname:node_4623,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Vector2,id:5836,x:32492,y:32358,varname:node_5836,prsc:2,v1:6,v2:6;n:type:ShaderForge.SFN_Frac,id:4677,x:33216,y:32440,varname:node_4677,prsc:2|IN-5915-OUT;n:type:ShaderForge.SFN_Add,id:8329,x:32784,y:32634,varname:node_8329,prsc:2|A-8282-UVOUT,B-6521-OUT;n:type:ShaderForge.SFN_Time,id:1877,x:32490,y:32809,varname:node_1877,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4853,x:32784,y:32777,varname:node_4853,prsc:2|A-1877-T,B-9448-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9448,x:32490,y:32993,ptovrint:False,ptlb:Speed,ptin:_Speed,varname:node_9448,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Floor,id:2199,x:33017,y:32777,varname:node_2199,prsc:2|IN-4853-OUT;n:type:ShaderForge.SFN_Divide,id:4984,x:33282,y:32897,varname:node_4984,prsc:2|A-2199-OUT,B-1666-OUT;n:type:ShaderForge.SFN_Floor,id:7355,x:33514,y:32897,varname:node_7355,prsc:2|IN-4984-OUT;n:type:ShaderForge.SFN_Multiply,id:4450,x:33814,y:32911,varname:node_4450,prsc:2|A-7355-OUT,B-6984-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6984,x:33282,y:33074,ptovrint:False,ptlb:value,ptin:_value,varname:node_6984,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-1;n:type:ShaderForge.SFN_ComponentMask,id:1666,x:33017,y:32986,varname:node_1666,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-5836-OUT;n:type:ShaderForge.SFN_Append,id:6521,x:33347,y:32754,varname:node_6521,prsc:2|A-2199-OUT,B-4450-OUT;proporder:9567-4623-9448-6984;pass:END;sub:END;*/

Shader "Shader Forge/Kadai1Shader" {
    Properties {
        _Texture2D ("Texture2D", 2D) = "white" {}
        _Value ("Value", Float ) = 1
        _Speed ("Speed", Float ) = 2
        _value ("value", Float ) = -1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Texture2D; uniform float4 _Texture2D_ST;
            uniform float _Value;
            uniform float _Speed;
            uniform float _value;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_1877 = _Time + _TimeEditor;
                float node_2199 = floor((node_1877.g*_Speed));
                float2 node_5836 = float2(6,6);
                float2 node_4677 = frac(((i.uv0+float2(node_2199,(floor((node_2199/node_5836.g))*_value)))*(_Value/node_5836)));
                float4 _Texture2D_var = tex2D(_Texture2D,TRANSFORM_TEX(node_4677, _Texture2D));
                float3 emissive = _Texture2D_var.rgb;
                float3 finalColor = emissive;
                return fixed4(finalColor,_Texture2D_var.a);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
