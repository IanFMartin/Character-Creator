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
    float slider = 90;
    Vector2 scroll;

    public GameObject searcher(string bodyPart)
    {
        EditorGUILayout.LabelField("Search asset");
        slider = GUILayout.HorizontalSlider(slider, 50, 130);
        scroll = EditorGUILayout.BeginScrollView(scroll, false, false, GUILayout.Width(400), GUILayout.Height(315));
        int i;
        _SercherList.Clear();
        string[] allPaths = AssetDatabase.FindAssets(bodyPart);
        for (i = allPaths.Length - 1; i >= 0; i--)
        {
            allPaths[i] = AssetDatabase.GUIDToAssetPath(allPaths[i]);
            _SercherList.Add(AssetDatabase.LoadAssetAtPath(allPaths[i], typeof(Object)));
        }

        for (int j = 0; j < _SercherList.Count; j++)
        {
            if (_SercherList[j].GetType() == typeof(GameObject))
            {
                GameObject gO = (GameObject)_SercherList[j];
                if (gO.tag == bodyPart)
                {

                    EditorGUILayout.BeginHorizontal();
                    _listPreview = AssetPreview.GetAssetPreview(_SercherList[j]);

                    var amountButtons = Mathf.FloorToInt(400 / slider);
                    var colPosition = Mathf.FloorToInt(j / amountButtons);
                    var rowPosition = j - colPosition * amountButtons;
                 
                    if (GUI.Button(new Rect((rowPosition * slider), (colPosition * slider), slider, slider), _listPreview))
                    {
                        return part = (GameObject)_SercherList[j];
                    }
                }
                CharacterCreator.SpaceOnLine(4);
                EditorGUILayout.EndHorizontal();

            }else
            {
                _SercherList.Remove(_SercherList[j]);
                j--;
            }
        }

        EditorGUILayout.EndScrollView();
        return null;
    }

}
