// Shader created with Shader Forge v1.28 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.28;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:34403,y:33291,varname:node_4013,prsc:2|diff-3818-OUT,normal-8717-OUT;n:type:ShaderForge.SFN_TexCoord,id:8379,x:32643,y:32720,varname:node_8379,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2d,id:6089,x:33277,y:32467,ptovrint:False,ptlb:Base,ptin:_Base,varname:node_6089,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:750b247aa68f63c46a3258b508a11f51,ntxv:0,isnm:False|UVIN-8379-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:7523,x:33277,y:32667,ptovrint:False,ptlb:BlendImg,ptin:_BlendImg,varname:node_7523,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:48ba1ccb20a5a5f40b036d104b278033,ntxv:0,isnm:False|UVIN-8379-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:5662,x:32868,y:33120,ptovrint:False,ptlb:Base_Normal,ptin:_Base_Normal,varname:node_5662,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3f8825c7fb0bb334083d465fc9226b55,ntxv:3,isnm:True|UVIN-8379-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:290,x:32867,y:33801,ptovrint:False,ptlb:Blending_Normal,ptin:_Blending_Normal,varname:node_290,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c8af09f46a85c984990d490782724ea4,ntxv:3,isnm:True|UVIN-8379-UVOUT;n:type:ShaderForge.SFN_Transform,id:682,x:33253,y:32854,varname:node_682,prsc:2,tffrom:2,tfto:0|IN-5662-RGB;n:type:ShaderForge.SFN_ComponentMask,id:1496,x:33451,y:32854,varname:node_1496,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-682-XYZ;n:type:ShaderForge.SFN_Add,id:9828,x:33356,y:33302,varname:node_9828,prsc:2|A-1496-OUT,B-8725-OUT;n:type:ShaderForge.SFN_Clamp01,id:4148,x:33587,y:33302,varname:node_4148,prsc:2|IN-9828-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8725,x:33125,y:33322,ptovrint:False,ptlb:Value,ptin:_Value,varname:node_8725,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.2;n:type:ShaderForge.SFN_Subtract,id:7919,x:33100,y:33517,varname:node_7919,prsc:2|A-4148-OUT,B-8315-OUT;n:type:ShaderForge.SFN_Multiply,id:6557,x:33300,y:33517,varname:node_6557,prsc:2|A-7919-OUT,B-7742-OUT;n:type:ShaderForge.SFN_Add,id:569,x:33529,y:33517,varname:node_569,prsc:2|A-6557-OUT,B-1012-OUT;n:type:ShaderForge.SFN_Clamp01,id:7161,x:33730,y:33517,varname:node_7161,prsc:2|IN-569-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8315,x:33073,y:33695,ptovrint:False,ptlb:node_8315,ptin:_node_8315,varname:node_8315,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_ValueProperty,id:7742,x:33275,y:33695,ptovrint:False,ptlb:node_7742,ptin:_node_7742,varname:node_7742,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:10;n:type:ShaderForge.SFN_ValueProperty,id:1012,x:33502,y:33685,ptovrint:False,ptlb:node_1012,ptin:_node_1012,varname:node_1012,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Lerp,id:8717,x:33568,y:33840,varname:node_8717,prsc:2|A-5662-RGB,B-290-RGB,T-7161-OUT;n:type:ShaderForge.SFN_Lerp,id:3818,x:33944,y:32566,varname:node_3818,prsc:2|A-6089-RGB,B-6362-OUT,T-7161-OUT;n:type:ShaderForge.SFN_Multiply,id:6362,x:33660,y:32621,varname:node_6362,prsc:2|A-7523-RGB,B-5910-RGB;n:type:ShaderForge.SFN_Color,id:5910,x:33645,y:32819,ptovrint:False,ptlb:node_5910,ptin:_node_5910,varname:node_5910,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.284,c2:0.4705882,c3:0.04498268,c4:1;proporder:6089-5662-7523-290-8725-1012-8315-7742-5910;pass:END;sub:END;*/

Shader "Shader Forge/TestOsawaShader2" {
    Properties {
        _Base ("Base", 2D) = "white" {}
        _Base_Normal ("Base_Normal", 2D) = "bump" {}
        _BlendImg ("BlendImg", 2D) = "white" {}
        _Blending_Normal ("Blending_Normal", 2D) = "bump" {}
        _Value ("Value", Float ) = 0.2
        _node_1012 ("node_1012", Float ) = 0.5
        _node_8315 ("node_8315", Float ) = 0.5
        _node_7742 ("node_7742", Float ) = 10
        _node_5910 ("node_5910", Color) = (0.284,0.4705882,0.04498268,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
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
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _Base; uniform float4 _Base_ST;
            uniform sampler2D _BlendImg; uniform float4 _BlendImg_ST;
            uniform sampler2D _Base_Normal; uniform float4 _Base_Normal_ST;
            uniform sampler2D _Blending_Normal; uniform float4 _Blending_Normal_ST;
            uniform float _Value;
            uniform float _node_8315;
            uniform float _node_7742;
            uniform float _node_1012;
            uniform float4 _node_5910;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Base_Normal_var = UnpackNormal(tex2D(_Base_Normal,TRANSFORM_TEX(i.uv0, _Base_Normal)));
                float3 _Blending_Normal_var = UnpackNormal(tex2D(_Blending_Normal,TRANSFORM_TEX(i.uv0, _Blending_Normal)));
                float node_7161 = saturate((((saturate((mul( _Base_Normal_var.rgb, tangentTransform ).xyz.rgb.g+_Value))-_node_8315)*_node_7742)+_node_1012));
                float3 normalLocal = lerp(_Base_Normal_var.rgb,_Blending_Normal_var.rgb,node_7161);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _Base_var = tex2D(_Base,TRANSFORM_TEX(i.uv0, _Base));
                float4 _BlendImg_var = tex2D(_BlendImg,TRANSFORM_TEX(i.uv0, _BlendImg));
                float3 diffuseColor = lerp(_Base_var.rgb,(_BlendImg_var.rgb*_node_5910.rgb),node_7161);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _Base; uniform float4 _Base_ST;
            uniform sampler2D _BlendImg; uniform float4 _BlendImg_ST;
            uniform sampler2D _Base_Normal; uniform float4 _Base_Normal_ST;
            uniform sampler2D _Blending_Normal; uniform float4 _Blending_Normal_ST;
            uniform float _Value;
            uniform float _node_8315;
            uniform float _node_7742;
            uniform float _node_1012;
            uniform float4 _node_5910;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Base_Normal_var = UnpackNormal(tex2D(_Base_Normal,TRANSFORM_TEX(i.uv0, _Base_Normal)));
                float3 _Blending_Normal_var = UnpackNormal(tex2D(_Blending_Normal,TRANSFORM_TEX(i.uv0, _Blending_Normal)));
                float node_7161 = saturate((((saturate((mul( _Base_Normal_var.rgb, tangentTransform ).xyz.rgb.g+_Value))-_node_8315)*_node_7742)+_node_1012));
                float3 normalLocal = lerp(_Base_Normal_var.rgb,_Blending_Normal_var.rgb,node_7161);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _Base_var = tex2D(_Base,TRANSFORM_TEX(i.uv0, _Base));
                float4 _BlendImg_var = tex2D(_BlendImg,TRANSFORM_TEX(i.uv0, _BlendImg));
                float3 diffuseColor = lerp(_Base_var.rgb,(_BlendImg_var.rgb*_node_5910.rgb),node_7161);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
