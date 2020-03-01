using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

[CustomEditor(typeof(Ship))]
public class ShipInspector : Editor
{
    Ship _target;

    Rect rect;

    int value;

    AnimBool _fade;
    bool _fadeAll;

    private void OnEnable()
    {

        _target = (Ship)target;


        _fade = new AnimBool(false);
        _fade.valueChanged.AddListener(Repaint);
    }

    public override void OnInspectorGUI()
    {
        ShowValues();
        Repaint();
    }

    void ShowValues()
    {
        EditorGUILayout.LabelField("Custom Inspector Ship", EditorStyles.boldLabel);
        _fadeAll = EditorGUILayout.Foldout(_fadeAll, "Expandir/Contraer");
        if (_fadeAll)
        {
            EditorGUILayout.BeginHorizontal();
            _target.team = (Ship.Team)EditorGUILayout.EnumPopup("Team", _target.team);
            if (_target.team == Ship.Team.Alliance)
            {
                GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), (Texture2D)Resources.Load("alliance"), ScaleMode.ScaleToFit);
            }
            else if (_target.team == Ship.Team.Rebel)
            {
                GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), (Texture2D)Resources.Load("rebel"), ScaleMode.ScaleToFit);
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();

            _target.level = EditorGUILayout.IntField("Nivel", _target.level);
            if (_target.level < 0) _target.level = 0;
            _target.experience = EditorGUILayout.Slider("Experiencia", _target.experience, 0, 100);
            EditorGUI.ProgressBar(GUILayoutUtility.GetRect(15, 15, "TextField"), _target.experience / 100, _target.experience + "%");

            EditorGUILayout.Space();

            Stats();
            _target.statScore = (_target.health + _target.maxSpeed + _target.defense + _target.shield + _target.damage) / 5;

            EditorGUILayout.Space();

            _target.respawn = EditorGUILayout.Vector3Field("Respawn", _target.respawn);

            EditorGUILayout.Space();

            _target.shipTypeID = EditorGUILayout.Popup("Clase", _target.shipTypeID, _target.shipType);
            if (_target.shipTypeID != 0 && _target.shipTypeID != 1 && _target.shipTypeID != 2)
            {
                EditorGUILayout.HelpBox("Ninguna clase seleccionada", MessageType.Warning);
            }

            EditorGUILayout.Space();

            _fade.target = EditorGUILayout.Foldout(_fade.target, _target.description);
            if (EditorGUILayout.BeginFadeGroup(_fade.faded))
            {
                _target.health = EditorGUILayout.IntField("Salud", _target.health + (_target.level * 10));
                _target.maxSpeed = EditorGUILayout.FloatField("Velocidad Máx", _target.maxSpeed + (_target.level * 10));
                _target.shield = EditorGUILayout.IntField("Escudo", _target.shield + (_target.level * 10));
                _target.damage = EditorGUILayout.FloatField("Daño", _target.damage + (_target.level * 10));
                _target.defense = EditorGUILayout.IntField("Defensa", _target.defense + (_target.level * 10));
                _target.statScore = EditorGUILayout.FloatField("Stats Score", _target.statScore + (_target.level * 10));
            }
            EditorGUILayout.EndFadeGroup();
        }


        EditorGUILayout.EndFadeGroup();
    }

    void Stats()
    {
        //Elige Destructor
        if (_target.shipTypeID == 0)
        {
            Renderer rend = _target.GetComponent<Renderer>();
            _target.description = "Mother of naves";
            _target.health = 170;
            _target.maxSpeed = 40;
            _target.defense = 140;
            _target.shield = 70;
            _target.damage = 120;
            rend.sharedMaterial.color = new Color(0.5f, 0, 1);
        }
        //Elige Fragata
        if (_target.shipTypeID == 1)
        {
            Renderer rend = _target.GetComponent<Renderer>();
            _target.description = "La fragata";
            _target.health = 70;
            _target.maxSpeed = 140;
            _target.defense = 60;
            _target.shield = 50;
            _target.damage = 80;
            rend.sharedMaterial.color = new Color(0, 1, 0.5f);
        }
        //Elige Crucero
        if (_target.shipTypeID == 2)
        {
            Renderer rend = _target.GetComponent<Renderer>();
            _target.description = "El crucero";
            _target.health = 160;
            _target.maxSpeed = 80;
            _target.defense = 180;
            _target.shield = 60;
            _target.damage = 100;
            rend.sharedMaterial.color = new Color(0.5f, 0.5f, 0.5f);

        }
    }
}
