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

        if (_rightLeg == null)
        {
            _rightLeg = partSearcher.searcher("Leg");
            force = 0;
            shield = 0;
            life = 0;
        }
        else
        {
            _rightLegPreview = AssetPreview.GetAssetPreview(_rightLeg);
            if (_rightLegPreview != null)
            {
                GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _rightLegPreview, ScaleMode.ScaleToFit);
            }

            life = EditorGUILayout.IntField("Life: ", life);
            if(life < 0)
            {
                EditorGUILayout.HelpBox("Can not be less than 0", MessageType.Error);
                life = 0;

            }
            shield = EditorGUILayout.IntField("Shield: ", shield);
            if (shield < 0)
            {
                EditorGUILayout.HelpBox("Can not be less than 0", MessageType.Error);
                shield = 0;

            }
            force = EditorGUILayout.IntField("Force: ", force);
            if (force < 0)
            {
                EditorGUILayout.HelpBox("Can not be less than 0", MessageType.Error);
                force = 0;

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
