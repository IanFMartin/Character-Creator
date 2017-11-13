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
    float slider = 90f;
    Vector2 scroll;

    public GameObject searcher(string bodyPart)
    {
        EditorGUILayout.LabelField("Search asset");
        slider = GUILayout.HorizontalSlider(slider, 50f, 130f);
        scroll = EditorGUILayout.BeginScrollView(scroll, true, false, GUILayout.Width(400), GUILayout.Height(315));
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

                    var amountButtons = Mathf.FloorToInt(400 / slider);
                    //Debug.Log("cantidad de botones " + amountButtons);
                    for (int j = 0; j < _SercherList.Count; j++)
                    {


                        var rowPosition = Mathf.FloorToInt(j / amountButtons);
                        //Debug.Log("rowPosition " + rowPosition);

                        var colPosition = j - rowPosition * amountButtons;
                        //Debug.Log("colPosition " + colPosition);
                    
                        if (GUI.Button(new Rect((rowPosition*slider), (colPosition*slider), slider, slider), _listPreview))
                        {
                            return part = (GameObject)_SercherList[i];
                        }

                    }


                }
                CharacterCreator.SpaceOnLine(4);
                EditorGUILayout.EndHorizontal();
            }

        }
        EditorGUILayout.EndScrollView();
        return null;
    }

}
