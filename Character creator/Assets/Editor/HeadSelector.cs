using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class HeadSelector : CharacterCreator
{
    private void OnGUI()
    {

        var myStyle = new GUIStyle(GUI.skin.label);
        myStyle.alignment = TextAnchor.MiddleCenter;
        myStyle.fontStyle = FontStyle.Bold;
        myStyle.fontSize = 14;
        CharacterCreator.SpaceOnLine(2);

        EditorGUILayout.LabelField("Head Selector", myStyle);
        minSize = new Vector2(400, 400);
        maxSize = new Vector2(400, 400);

        CharacterCreator.SpaceOnLine(2);


        _head = (GameObject)EditorGUILayout.ObjectField("Head :", _head, typeof(GameObject), true);

        if (_head == null) _head = partSearcher.searcher("Head");
        else
        {
            _headPreview = AssetPreview.GetAssetPreview(_head);
            if (_headPreview != null)
            {
                GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _headPreview, ScaleMode.ScaleToFit);
            }
            if (GUILayout.Button("Clear"))
            {
                _head = null;
            }
            if (GUILayout.Button("Close"))
            {
                Close();

            }

            Repaint();
        }
    }
}
