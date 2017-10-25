using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class LeftArmSelector : CharacterCreator
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
        EditorGUILayout.LabelField("Left Arm Selector", myStyle);


        CharacterCreator.SpaceOnLine(2);

        minSize = new Vector2(400, 400);
        maxSize = new Vector2(400, 400);

        _leftArm = (GameObject)EditorGUILayout.ObjectField("Left arm :", _leftArm, typeof(GameObject), true);
        life = EditorGUILayout.IntField("Life: ", life);
        shield = EditorGUILayout.IntField("Shield: ", shield);
        force = EditorGUILayout.IntField("Force: ", force);

        if (_leftArm == null) _leftArm = partSearcher.searcher("Arm");
        else
        {
            _leftArmPreview = AssetPreview.GetAssetPreview(_leftArm);
            if (_leftArmPreview != null)
            {
                GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _leftArmPreview, ScaleMode.ScaleToFit);
            }
            if (GUILayout.Button("Clear"))
            {
                _leftArm = null;
            }
            if (GUILayout.Button("Close"))
            {
                Close();

            }

        }

        Repaint();
    }
}
