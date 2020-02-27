using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Character))]
public class CharacterCustomInspector : Editor
{
    //SerializedProperty totalLife;
    bool showTotalStats = true;
    string status = "Total Stats:";

    private SerializedObject obj;
    private SerializedProperty totalLife;
    private SerializedProperty totalShield;
    private SerializedProperty totalForce;

    private void OnEnable()
    {
        obj = new SerializedObject(target);
        totalLife = obj.FindProperty("totalLife");
        totalShield = obj.FindProperty("totalShield");
        totalForce = obj.FindProperty("totalForce");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Character character = (Character)target;

        character.totalLife = character.totalStats.life;
        character.totalShield = character.totalStats.shield;
        character.totalForce = character.totalStats.life;


        showTotalStats = EditorGUILayout.Foldout(showTotalStats, status);
        if (showTotalStats)
            if (Selection.activeTransform)
            {
                EditorGUILayout.PropertyField(totalLife, new GUIContent("Life"));
                EditorGUILayout.PropertyField(totalShield, new GUIContent("Shield"));
                EditorGUILayout.PropertyField(totalForce, new GUIContent("Force"));
            }

        if (!Selection.activeTransform)
        {
            showTotalStats = false;
        }

    }
}
