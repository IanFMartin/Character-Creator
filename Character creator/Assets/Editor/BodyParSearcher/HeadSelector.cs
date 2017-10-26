using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class HeadSelector : CharacterCreator
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

        EditorGUILayout.LabelField("Head Selector", myStyle);
        minSize = new Vector2(400, 400);
        maxSize = new Vector2(400, 400);

        CharacterCreator.SpaceOnLine(2);


        _head = (GameObject)EditorGUILayout.ObjectField("Head :", _head, typeof(GameObject), true);
        if (_head == null)
        {
            _head = partSearcher.searcher("Head");
            force = 0;
            shield = 0;
            life = 0;
        }
        else
        {
            _headPreview = AssetPreview.GetAssetPreview(_head);
            if (_headPreview != null)
            {
                GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _headPreview, ScaleMode.ScaleToFit);
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
