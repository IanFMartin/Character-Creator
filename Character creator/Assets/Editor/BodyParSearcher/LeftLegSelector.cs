using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class LeftLegSelector : CharacterCreator
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

        EditorGUILayout.LabelField("Left Leg Selector", myStyle);


        CharacterCreator.SpaceOnLine(2);

        minSize = new Vector2(400, 400);
        maxSize = new Vector2(400, 400);

        _leftLeg = (GameObject)EditorGUILayout.ObjectField("Left leg :", _leftLeg, typeof(GameObject), true);

        if (_leftLeg == null)
        {
            _leftLeg = partSearcher.searcher("Leg");
            force = 0;
            shield = 0;
            life = 0;
        }
        else
        {
            _leftLegPreview = AssetPreview.GetAssetPreview(_leftLeg);
            if (_leftLegPreview != null)
            {
                GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _leftLegPreview, ScaleMode.ScaleToFit);
            }
            life = EditorGUILayout.IntField("Life: ", life);
            if (life < 0)
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
                _leftLeg = null;
            }
            if (GUILayout.Button("Close"))
            {
                Close();

            }

        }

        Repaint();
    }
}
