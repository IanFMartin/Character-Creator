using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class RightArmSelector : CharacterCreator
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

        EditorGUILayout.LabelField("Right Arm Selector", myStyle);
        
        CharacterCreator.SpaceOnLine(2);
        minSize = new Vector2(400, 400);
        maxSize = new Vector2(400, 400);
        _rightArm = (GameObject)EditorGUILayout.ObjectField("Right arm :", _rightArm, typeof(GameObject), true);
        life = EditorGUILayout.IntField("Life: ", life);
        shield = EditorGUILayout.IntField("Shield: ", shield);
        force = EditorGUILayout.IntField("Force: ", force);

        if (_rightArm == null) _rightArm = partSearcher.searcher("Arm");
        else
        {
            _rightArmPreview = AssetPreview.GetAssetPreview(_rightArm);
            if (_rightArmPreview != null)
            {
                GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _rightArmPreview, ScaleMode.ScaleToFit);
            }
            if (GUILayout.Button("Clear"))
            {
                _rightArm = null;
            }
            if (GUILayout.Button("Close"))
            {
                Close();

            }

        }

        Repaint();
    }
}
