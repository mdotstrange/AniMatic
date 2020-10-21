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
            if(item.name.Contains("Base_Color") || item.name.Contains("Albedo") ||  item.name.Contains("basecolor"))
            {
                material.SetTexture("_MainTex", item as Texture2D);
            }

            //Height/Bump map names
            else if (item.name.Contains("Height") || item.name.Contains("Bump") || item.name.Contains("height"))
            {
                material.SetTexture("_ParallaxMap", item as Texture2D);
            }

            //Metallic map names
            else if (item.name.Contains("Metallic") || item.name.Contains("metallic"))
            {
                material.SetTexture("_MetallicGlossMap", item as Texture2D);
            }

            //Normal map names
            else if (item.name.Contains("Normal") || item.name.Contains("Nrm") || item.name.Contains("normal"))
            {
         
                material.SetTexture("_BumpMap", item as Texture2D);
            }

            //Ambient occlusion map names
            else if (item.name.Contains("Ambient_Occlusion") || item.name.Contains("AO") || item.name.Contains("ambientocclusion"))
            {
                material.SetTexture("_OcclusionMap", item as Texture2D);
            }

        }

        material.enableInstancing = true;
   
    }

    //[MenuItem("Assets/Create/Create Material from texture folder", false, 11)]
    //static void CreateMaterialFromFolder()
    //{
    //    Material material = new Material(Shader.Find("Standard"));

    //    string currentDirectory = GetCurrentAssetDirectory();

    //    var assets = AssetDatabase.FindAssets("t:Texture2d", new[] { currentDirectory });

    //    List<Texture2D> texes = new List<Texture2D>();
             
    //    foreach (var guid in assets)
    //    {
    //        var tex = AssetDatabase.LoadAssetAtPath<Texture2D>(AssetDatabase.GUIDToAssetPath(guid));
    //        texes.Add(tex);
    //    }

   
    //    string assetPath = AssetDatabase.GetAssetPath(texes[0]);


    //    AssetDatabase.CreateAsset(material, assetPath + ".mat");

    //    //Replace the texture names to match your formatting

    //    foreach (var item in texes)
    //    {
    //        // Main texture names
    //        if (item.name.Contains("Base_Color") || item.name.Contains("Albedo") || item.name.Contains("basecolor"))
    //        {
    //            material.SetTexture("_MainTex", item );
    //        }

    //        //Height/Bump map names
    //        else if (item.name.Contains("Height") || item.name.Contains("Bump") || item.name.Contains("height"))
    //        {
    //            material.SetTexture("_ParallaxMap", item );
    //        }

    //        //Metallic map names
    //        else if (item.name.Contains("Metallic") || item.name.Contains("metallic"))
    //        {
    //            material.SetTexture("_MetallicGlossMap", item );
    //        }

    //        //Normal map names
    //        else if (item.name.Contains("Normal") || item.name.Contains("Nrm") || item.name.Contains("normal"))
    //        {

    //            material.SetTexture("_BumpMap", item );
    //        }

    //        //Ambient occlusion map names
    //        else if (item.name.Contains("Ambient_Occlusion") || item.name.Contains("AO") || item.name.Contains("ambientocclusion"))
    //        {
    //            material.SetTexture("_OcclusionMap", item );
    //        }

    //    }

    //    material.enableInstancing = true;

    //}

    [MenuItem("Assets/Create/Create Materials from folders", false, 11)]
    static void CreateMaterialFromMultipleFolders()
    {
        List<string> selectedFolders = new List<string>();

        foreach (var item in Selection.objects)
        {
            var path = AssetDatabase.GetAssetPath(item);

            Debug.Log("Selection " + path);

            if (string.IsNullOrEmpty(path))
                continue;
      
            if (System.IO.File.Exists(path))
               path = System.IO.Path.GetDirectoryName(path);

            selectedFolders.Add(path);
        }

        foreach (var folderPath in selectedFolders)
        {
            Material material = new Material(Shader.Find("Standard"));
            string currentDirectory = folderPath;

            var assets = AssetDatabase.FindAssets("t:Texture2d", new[] { currentDirectory });

            List<Texture2D> texes = new List<Texture2D>();

            foreach (var guid in assets)
            {
                var tex = AssetDatabase.LoadAssetAtPath<Texture2D>(AssetDatabase.GUIDToAssetPath(guid));
                texes.Add(tex);
            }

            string assetPath = AssetDatabase.GetAssetPath(texes[0]);
            AssetDatabase.CreateAsset(material, assetPath + ".mat");

            foreach (var item in texes)
            {
                // Main texture names
                if (item.name.Contains("Base_Color") || item.name.Contains("Albedo") || item.name.Contains("basecolor"))
                {
                    material.SetTexture("_MainTex", item);
                }

                //Height/Bump map names
                else if (item.name.Contains("Height") || item.name.Contains("Bump") || item.name.Contains("height"))
                {
                    material.SetTexture("_ParallaxMap", item);
                }

                //Metallic map names
                else if (item.name.Contains("Metallic") || item.name.Contains("metallic"))
                {
                    material.SetTexture("_MetallicGlossMap", item);
                }

                //Normal map names
                else if (item.name.Contains("Normal") || item.name.Contains("Nrm") || item.name.Contains("normal"))
                {

                    material.SetTexture("_BumpMap", item);
                }

                //Ambient occlusion map names
                else if (item.name.Contains("Ambient_Occlusion") || item.name.Contains("AO") || item.name.Contains("ambientocclusion"))
                {
                    material.SetTexture("_OcclusionMap", item);
                }

            }
            material.enableInstancing = true;

        }

       

    }

    public static string GetCurrentAssetDirectory()
    {
        foreach (var obj in Selection.GetFiltered<Object>(SelectionMode.Assets))
        {
            var path = AssetDatabase.GetAssetPath(obj);

            if (string.IsNullOrEmpty(path))
                continue;

            if (System.IO.Directory.Exists(path))
                return path;
            else if (System.IO.File.Exists(path))
                return System.IO.Path.GetDirectoryName(path);
        }

        return "Assets";
    }
}
