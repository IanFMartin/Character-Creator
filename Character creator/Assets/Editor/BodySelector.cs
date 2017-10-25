using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class BodySelector : CharacterCreator
{
    public static int force;
    public static int shield;
    public static int life;

    private void OnGUI()
    {

        var myStyle = new GUIStyle(GUI.skin.label);
        myStyle.alignment = TextAnchor.MiddleCenter;
        myStyle.fontStyle = FontStyle.Bold;
        myStyle.fontSize = 14;
        CharacterCreator.SpaceOnLine(2);

        minSize = new Vector2(400, 400);
        maxSize = new Vector2(400, 400);

        CharacterCreator.SpaceOnLine(2);

        EditorGUILayout.LabelField("Body Selector", myStyle);
        _body = (GameObject)EditorGUILayout.ObjectField("Body :", _body, typeof(GameObject), true);
        life = EditorGUILayout.IntField("Life: ", life);
        shield = EditorGUILayout.IntField("Shield: ", shield);
        force = EditorGUILayout.IntField("Force: ", force);

        if (_body == null) _body = partSearcher.searcher("Body");
        else
        {
            _bodyPreview = AssetPreview.GetAssetPreview(_body);
            if (_bodyPreview != null)
            {
                GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _bodyPreview, ScaleMode.ScaleToFit);
            }
            if (GUILayout.Button("Clear"))
            {
                _body = null;
            }
            if (GUILayout.Button("Close"))
            {
                Close();
            }


            Repaint();
        }


    }

               
}

