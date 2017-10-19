using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class BodySelector : CharacterCreator
{
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

        if (_body == null) _body = partSearcher.searcher("Body");
        else
        {
            _bodyPreview = AssetPreview.GetAssetPreview(_body);
            if (_headPreview != null)
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
