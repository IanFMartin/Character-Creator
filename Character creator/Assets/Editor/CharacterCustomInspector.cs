using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Character))]
public class CharacterCustomInspector : Editor
{
    bool showTotalStats = true;
    bool showHeadStats = false;
    bool showBodyStats = false;
    bool showLeftArmStats = false;
    bool showRightArmStats = false;
    bool showLeftLegStats = false;
    bool showRightLegStats = false;

    string status = "Total Stats:";
    string headStatus = "Head Stats:";
    string bodyStatus = "Body Stats:";
    string rightArmStatus = "Right Arm Stats:";
    string leftArmStatus = "Left Arm Stats:";
    string rightLegStatus = "Right Leg Stats:";
    string leftLegStatus = "Left Leg Stats:";

    private SerializedObject obj;

    #region Serialized Properties
    private SerializedProperty totalLife;
    private SerializedProperty totalShield;
    private SerializedProperty totalForce;

    private SerializedProperty headLife;
    private SerializedProperty headShield;
    private SerializedProperty headForce;

    private SerializedProperty bodyLife;
    private SerializedProperty bodyShield;
    private SerializedProperty bodyForce;

    private SerializedProperty leftArmLife;
    private SerializedProperty leftArmShield;
    private SerializedProperty leftArmForce;

    private SerializedProperty rightArmLife;
    private SerializedProperty rightArmShield;
    private SerializedProperty rightArmForce;

    private SerializedProperty leftLegLife;
    private SerializedProperty leftLegShield;
    private SerializedProperty leftLegForce;

    private SerializedProperty rightLegLife;
    private SerializedProperty rightLegShield;
    private SerializedProperty rightLegForce;
    #endregion

    private void OnEnable()
    {
        obj = new SerializedObject(target);
        Character character = (Character)target;

        character.totalLife = character.totalStats.life;
        character.totalShield = character.totalStats.shield;
        character.totalForce = character.totalStats.force;

        character.headLife = character.headStats.life;
        character.headShield = character.headStats.shield;
        character.headForce = character.headStats.force;

        character.bodyLife = character.bodyStats.life;
        character.bodyShield = character.bodyStats.shield;
        character.bodyForce = character.bodyStats.force;

        character.arm1Life = character.arm1Stats.life;
        character.arm1Shield = character.arm1Stats.shield;
        character.arm1Force = character.arm1Stats.force;

        character.arm2Life = character.arm2Stats.life;
        character.arm2Shield = character.arm2Stats.shield;
        character.arm2Force = character.arm2Stats.force;

        character.leg1Life = character.leg1Stats.life;
        character.leg1Shield = character.leg1Stats.shield;
        character.leg1Force = character.leg1Stats.force;

        character.leg2Life = character.leg2Stats.life;
        character.leg2Shield = character.leg2Stats.shield;
        character.leg2Force = character.leg2Stats.force;

        totalLife = obj.FindProperty("totalLife");
        totalShield = obj.FindProperty("totalShield");
        totalForce = obj.FindProperty("totalForce");

        headLife = obj.FindProperty("headLife");
        headShield = obj.FindProperty("headShield");
        headForce = obj.FindProperty("headForce");

        bodyLife = obj.FindProperty("bodyLife");
        bodyShield = obj.FindProperty("bodyShield");
        bodyForce = obj.FindProperty("bodyForce");

        leftArmLife = obj.FindProperty("arm1Life");
        leftArmShield = obj.FindProperty("arm1Shield");
        leftArmForce = obj.FindProperty("arm1Force");

        rightArmLife = obj.FindProperty("arm2Life");
        rightArmShield = obj.FindProperty("arm2Shield");
        rightArmForce = obj.FindProperty("arm2Force");

        leftLegLife = obj.FindProperty("leg1Life");
        leftLegShield = obj.FindProperty("leg1Shield");
        leftLegForce = obj.FindProperty("leg1Force");

        rightLegLife = obj.FindProperty("leg2Life");
        rightLegShield = obj.FindProperty("leg2Shield");
        rightLegForce = obj.FindProperty("leg2Force");        
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Character character = (Character)target;
        
        #region Values Assignment
        character.headLife = character.headStats.life;
        character.headShield = character.headStats.shield;
        character.headForce = character.headStats.force;

        character.bodyLife = character.bodyStats.life;
        character.bodyShield = character.bodyStats.shield;
        character.bodyForce = character.bodyStats.force;

        character.arm1Life = character.arm1Stats.life;
        character.arm1Shield = character.arm1Stats.shield;
        character.arm1Force = character.arm1Stats.force;

        character.arm2Life = character.arm2Stats.life;
        character.arm2Shield = character.arm2Stats.shield;
        character.arm2Force = character.arm2Stats.force;

        character.leg1Life = character.leg1Stats.life;
        character.leg1Shield = character.leg1Stats.shield;
        character.leg1Force = character.leg1Stats.force;

        character.leg2Life = character.leg2Stats.life;
        character.leg2Shield = character.leg2Stats.shield;
        character.leg2Force = character.leg2Stats.force;

        totalLife.intValue = headLife.intValue + bodyLife.intValue + leftArmLife.intValue +
                        rightArmLife.intValue + leftArmLife.intValue + rightLegLife.intValue;
        totalShield.intValue = headShield.intValue + bodyShield.intValue + leftArmShield.intValue +
                                    rightArmShield.intValue + leftLegShield.intValue + rightLegShield.intValue;
        totalForce.intValue = headForce.intValue + bodyForce.intValue + leftArmForce.intValue +
                                    rightArmForce.intValue + leftLegForce.intValue + rightLegForce.intValue;
        #endregion

        #region Foldouts
        //Total
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

        //Head
        showHeadStats = EditorGUILayout.Foldout(showHeadStats, headStatus);
        if (showHeadStats)
            if (Selection.activeTransform)
            {
                EditorGUILayout.PropertyField(headLife, new GUIContent("Life"));
                EditorGUILayout.PropertyField(headShield, new GUIContent("Shield"));
                EditorGUILayout.PropertyField(headForce, new GUIContent("Force"));
            }

        if (!Selection.activeTransform)
        {
            showHeadStats = false;
        }

        //Body
        showBodyStats = EditorGUILayout.Foldout(showBodyStats, bodyStatus);
        if (showBodyStats)
            if (Selection.activeTransform)
            {
                EditorGUILayout.PropertyField(bodyLife, new GUIContent("Life"));
                EditorGUILayout.PropertyField(bodyShield, new GUIContent("Shield"));
                EditorGUILayout.PropertyField(bodyForce, new GUIContent("Force"));
            }

        if (!Selection.activeTransform)
        {
            showBodyStats = false;
        }

        //Left Arm
        showLeftArmStats = EditorGUILayout.Foldout(showLeftArmStats, leftArmStatus);
        if (showLeftArmStats)
            if (Selection.activeTransform)
            {
                EditorGUILayout.PropertyField(leftArmLife, new GUIContent("Life"));
                EditorGUILayout.PropertyField(leftArmShield, new GUIContent("Shield"));
                EditorGUILayout.PropertyField(leftArmForce, new GUIContent("Force"));
            }

        if (!Selection.activeTransform)
        {
            showLeftArmStats = false;
        }

        //Right Arm
        showRightArmStats = EditorGUILayout.Foldout(showRightArmStats, rightArmStatus);
        if (showRightArmStats)
            if (Selection.activeTransform)
            {
                EditorGUILayout.PropertyField(rightArmLife, new GUIContent("Life"));
                EditorGUILayout.PropertyField(rightArmShield, new GUIContent("Shield"));
                EditorGUILayout.PropertyField(rightArmForce, new GUIContent("Force"));
            }

        if (!Selection.activeTransform)
        {
            showRightArmStats = false;
        }

        //Left Leg
        showLeftLegStats = EditorGUILayout.Foldout(showLeftLegStats, leftLegStatus);
        if (showLeftLegStats)
            if (Selection.activeTransform)
            {
                EditorGUILayout.PropertyField(leftLegLife, new GUIContent("Life"));
                EditorGUILayout.PropertyField(leftLegShield, new GUIContent("Shield"));
                EditorGUILayout.PropertyField(leftLegForce, new GUIContent("Force"));
            }

        if (!Selection.activeTransform)
        {
            showLeftLegStats = false;
        }

        //Right Leg
        showRightLegStats = EditorGUILayout.Foldout(showRightLegStats, rightLegStatus);
        if (showRightLegStats)
            if (Selection.activeTransform)
            {
                EditorGUILayout.PropertyField(rightLegLife, new GUIContent("Life"));
                EditorGUILayout.PropertyField(rightLegShield, new GUIContent("Shield"));
                EditorGUILayout.PropertyField(rightLegForce, new GUIContent("Force"));
            }

        if (!Selection.activeTransform)
        {
            showRightLegStats = false;
        }

        #endregion

    }


    private void OnSceneGUI()
    {
        Character character = (Character)target;

        Handles.color = Color.green;
        Handles.Label(character.headTrasnform.position + character.headTrasnform.up * 3,
                                        "Life: " + totalLife.intValue.ToString(), EditorStyles.helpBox);

        Handles.color = Color.cyan;
        Handles.Label(character.headTrasnform.position + character.headTrasnform.up * 2.5f,
                                        "Shield: " + totalShield.intValue.ToString(), EditorStyles.helpBox);

        Handles.color = Color.red;
        Handles.Label(character.headTrasnform.position + character.headTrasnform.up * 2,
                                        "Force: " + totalForce.intValue.ToString(), EditorStyles.helpBox);
    }

}
