﻿using UnityEngine;
using UnityEditor;
using System.IO;

public static class ScriptableObjectUtility
{
    public static void CreateAsset<T>(string path, string name, int life, int shield, int force) where T : BodypartStats
    {
        //Creamos la instancia del asset
        T asset = ScriptableObject.CreateInstance<T>();
        asset.infoOfVar(life, shield, force);

        //Creamos la ubicación donde vamos a guardar el asset
        string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + name + ".asset");
        
        //Creamos el asset
        AssetDatabase.CreateAsset(asset, assetPathAndName);

        //Guardamos los assets en disco
        AssetDatabase.SaveAssets();

        //Importa los assets que fueron modificados
        AssetDatabase.Refresh();

        //Ponemos el foco en la ventana de proyecto
        EditorUtility.FocusProjectWindow();

        //Marcamos como seleccionado el asset que acabamos de crear
        Selection.activeObject = asset;
    }
}