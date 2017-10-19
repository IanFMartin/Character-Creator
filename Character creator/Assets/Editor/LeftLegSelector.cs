using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class LeftLegSelector : CharacterCreator
{
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
        if (_leftLeg == null) _leftLeg = partSearcher.searcher("Leg");
        else
        {
            _leftLegPreview = AssetPreview.GetAssetPreview(_leftLeg);
            if (_leftLegPreview != null)
            {
                GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _leftLegPreview, ScaleMode.ScaleToFit);
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
