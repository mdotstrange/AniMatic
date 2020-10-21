using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;


public class CreateNewMaterialFromTextures : MonoBehaviour
{
    [MenuItem("Assets/Create/Create Material from textures", false, 10)]
    static void CreateMaterial()
    {      
        Material material = new Material(Shader.Find("Standard"));
        string assetPath = AssetDatabase.GetAssetPath(Selection.activeObject);
        AssetDatabase.CreateAsset(material, assetPath + ".mat");


        //Replace the texture names to match your formatting

        foreach (var item in Selection.objects)
        {
           // Main texture names
            if(item.name.Contains("Base_Color") || item.name.Contains("Albedo"))
            {
                material.SetTexture("_MainTex", item as Texture2D);
            }

            //Height/Bump map names
            else if (item.name.Contains("Height") || item.name.Contains("Bump"))
            {
                material.SetTexture("_ParallaxMap", item as Texture2D);
            }

            //Metallic map names
            else if (item.name.Contains("Metallic"))
            {
                material.SetTexture("_MetallicGlossMap", item as Texture2D);
            }

            //Normal map names
            else if (item.name.Contains("Normal") || item.name.Contains("Nrm"))
            {
                material.SetTexture("_BumpMap", item as Texture2D);
            }

            //Ambient occlusion map names
            else if (item.name.Contains("Ambient_Occlusion") || item.name.Contains("AO"))
            {
                material.SetTexture("_OcclusionMap", item as Texture2D);
            }

        }

        material.enableInstancing = true;

      
    }
}
