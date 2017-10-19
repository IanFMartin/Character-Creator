using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Searcher{


    List<Object> _SercherList = new List<Object>();
    Texture2D _listPreview;
    GameObject part;
    string _partName;

    public GameObject searcher(string bodyPart) 
    {
        EditorGUILayout.LabelField("Search asset");
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
                if( gO.tag == bodyPart)
                {
                EditorGUILayout.BeginHorizontal();
               
                    _listPreview = AssetPreview.GetAssetPreview(_SercherList[i]);
                if (_listPreview != null)
                {
                    GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _listPreview, ScaleMode.ScaleToFit);
                }
                EditorGUILayout.BeginVertical();
                EditorGUILayout.LabelField(_SercherList[i].ToString());
                if (GUILayout.Button("Select"))
                {

                    return part = (GameObject)_SercherList[i];
                        
                }

                }
                CharacterCreator.SpaceOnLine(4);

                EditorGUILayout.EndVertical();
                EditorGUILayout.EndHorizontal();
            }

        }
        return null;
    }
}
