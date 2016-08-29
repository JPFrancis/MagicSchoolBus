Shader "Custom/New Shader" {

	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
	}
  
  SubShader {
   
    Pass {
      
     	CGPROGRAM

      #pragma vertex vert
      #pragma fragment frag

      // Use shader model 3.0 target, to get nicer looking lighting
      #pragma target 3.0

      #include "UnityCG.cginc"

      sampler2D _MainTex;

      struct VertexIn{
				 float4 position  : POSITION; 
				 float3 normal    : NORMAL; 
				 float4 texcoord  : TEXCOORD0; 
				 float4 tangent   : TANGENT;
      };


      struct VertexOut {
        float4 pos    	: POSITION; 
        float3 normal 	: NORMAL; 
        float4 uv     	: TEXCOORD0; 
        float3 origPos : TEXCOORD1;
      };
    

      VertexOut vert(VertexIn v) {
        
        VertexOut o;

        o.normal = v.normal;
        
        o.uv = v.texcoord;

        o.origPos = v.position;
        
        // Getting the position for actual position
        o.pos = mul( UNITY_MATRIX_MVP , v.position );
        
        return o;

      }

      // Fragment Shader
      fixed4 frag(VertexOut i) : COLOR {


      	//float3 col = float3( sin(i.uv.x*100) , sin(i.uv.y*100), 0.5);

      	//Half Rainbow mauve
      	//float3 col = float3(i.uv.x,1.2-i.uv.y, i.uv.z+.6);


      	//Sinusoidal Grey-Blue Rainbow float3 col = float3(.4+ i.uv.x *5 * sin(_Time.y) * i.origPos.x,.5-i.uv.y * sin(_Time.y) *(i.origPos.y), i.uv.z+.6);

      	float3 col = float3((i.uv.x) + tan(_Time.y*2)*.2 - .1, (i.uv.y), .6);

      	float newX = i.uv.x *4 * sin(_Time.y) * i.origPos.x;
      	float newY = i.uv.y *2;

      	float2 newUV = float2(newX, newY);

      	//col = tex2D(_MainTex, newUV).xyz;

      	//col = i.normal * .5 + .5;

      	//if( i.normal.y == 1){
      	//	col = float3(1, 1, 1);
      	//}



		    fixed4 color;
        color = fixed4( col , 1 );
        return color;
      }

      ENDCG
    }
  }

  FallBack "Diffuse"

}
