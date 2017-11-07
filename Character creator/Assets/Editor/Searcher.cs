using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Searcher
{


    List<Object> _SercherList = new List<Object>();
    Texture2D _listPreview;
    GameObject part;
    string _partName;
    float slider = 80f;
    Vector2 scroll;

    public GameObject searcher(string bodyPart)
    {
        EditorGUILayout.LabelField("Search asset");
        slider = GUILayout.HorizontalSlider(slider, 40f, 190f);
        scroll = EditorGUILayout.BeginScrollView(scroll, true, false, GUILayout.Width(400), GUILayout.Height(310));
        int i;
        _SercherList.Clear();
        string[] allPaths = AssetDatabase.FindAssets(bodyPart);
        for (i = allPaths.Length - 1; i >= 0; i--)
        {
            allPaths[i] = AssetDatabase.GUIDToAssetPath(allPaths[i]);
            _SercherList.Add(AssetDatabase.LoadAssetAtPath(allPaths[i], typeof(Object)));
        }

        for (i = _SercherList.Count - 1; i >= 0; i--)
        {
            if (_SercherList[i].GetType() == typeof(GameObject))
            {
                GameObject gO = (GameObject)_SercherList[i];
                if (gO.tag == bodyPart)
                {
                    EditorGUILayout.BeginHorizontal();
                    _listPreview = AssetPreview.GetAssetPreview(_SercherList[i]);
                    
                    if (GUILayout.Button(_listPreview, GUILayout.Width(slider), GUILayout.Height(slider)))
                    {
                        return part = (GameObject)_SercherList[i];
                    }

                }
                CharacterCreator.SpaceOnLine(4);
                EditorGUILayout.EndHorizontal();
            }

        }
        EditorGUILayout.EndScrollView();
        return null;
    }
    /*
    public MonoScript ScriptSearcher ()
    {


        EditorGUILayout.LabelField("BUSCAR SCRIPT");


        //GameObject[] allObjects = (GameObject[])Editor.FindObjectsOfType(typeof(GameObject));


        
        var aux = _scriptName;
        _scriptName = EditorGUILayout.TextField(aux);
        int i;
        if (aux != _scriptName)
        {
            _scriptSearcher.Clear();
            string[] allPaths = AssetDatabase.FindAssets(_scriptName);
            for (i = allPaths.Length - 1; i >= 0; i--)
            {
                allPaths[i] = AssetDatabase.GUIDToAssetPath(allPaths[i]);
                _scriptSearcher.Add(AssetDatabase.LoadAssetAtPath(allPaths[i], typeof(Object)));
            }
        }
        for (i = _scriptSearcher.Count - 1; i >= 0; i--)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(_scriptSearcher[i].ToString());
            if (GUILayout.Button("Seleccionar"))
            {
                return script = (MonoScript)_scriptSearcher[i];
            }
            EditorGUILayout.EndHorizontal();
        }
        

        return null;
    }
    */
}
