using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class RightLegSelector : CharacterCreator
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
        EditorGUILayout.LabelField("Right Leg Selector", myStyle);

        minSize = new Vector2(400, 400);
        maxSize = new Vector2(400, 400);

        CharacterCreator.SpaceOnLine(2);
        _rightLeg = (GameObject)EditorGUILayout.ObjectField("Right leg :", _rightLeg, typeof(GameObject), true);
        life = EditorGUILayout.IntField("Life: ", life);
        shield = EditorGUILayout.IntField("Shield: ", shield);
        force = EditorGUILayout.IntField("Force: ", force);

        if (_rightLeg == null) _rightLeg = partSearcher.searcher("Leg");
        else
        {
            _rightLegPreview = AssetPreview.GetAssetPreview(_rightLeg);
            if (_rightLegPreview != null)
            {
                GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _rightLegPreview, ScaleMode.ScaleToFit);
            }
            if (GUILayout.Button("Clear"))
            {
                _rightLeg = null;
            }
            if (GUILayout.Button("Close"))
            {
                Close();

            }

        }

        Repaint();
    }
}
