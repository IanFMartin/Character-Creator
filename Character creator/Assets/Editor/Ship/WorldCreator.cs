using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Worlds))]
public class WorldCreator : Editor
{

    Worlds _target;

    private Texture2D _worldPrev;
    public GameObject _objectWorld;
    public string searchWorldName = "World";
    public List<Object> worldAssets = new List<Object>();
    private GameObject world;
    public int createSize;

    private void OnEnable()
    {
        _target = (Worlds)target;
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("Worlds Inspector", EditorStyles.boldLabel);

        PrefabShipSearcher();
    }

    private void PrefabShipSearcher()
    {
        if (_target.Size < 0)
        {
            _target.Size = 0;
        }
        _target.Size = EditorGUILayout.IntField("Size", _target.Size);
        EditorGUILayout.LabelField("Select world");
        var aux = searchWorldName;
        int i;
        if (aux == searchWorldName)
        {
            worldAssets.Clear();
            string[] path = AssetDatabase.FindAssets(searchWorldName);
            for (i = path.Length - 1; i >= 0; i--)
            {
                path[i] = AssetDatabase.GUIDToAssetPath(path[i]);
                worldAssets.Add(AssetDatabase.LoadAssetAtPath(path[i], typeof(GameObject)));
            }

        }

        for (int j = worldAssets.Count - 1; j >= 0; j--)
        {
            if (worldAssets[j] != null)
            {
                _worldPrev = AssetPreview.GetAssetPreview(worldAssets[j]);
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(worldAssets[j].name);
                if (GUILayout.Button("Select"))
                {
                    _objectWorld = (GameObject)worldAssets[j];
                }
                EditorGUILayout.EndHorizontal();
                worldAssets[j] = (GameObject)EditorGUILayout.ObjectField("Object: ", worldAssets[j], typeof(Object), true);
            }

        }

        if (_worldPrev != null && _objectWorld != null)
        {
            GUILayout.BeginVertical();
            GUILayout.Label("Selected: " + _objectWorld.name);
            GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _worldPrev, ScaleMode.ScaleToFit);
            EditorGUILayout.LabelField("Path: " + AssetDatabase.GetAssetPath(_objectWorld));
            GUILayout.EndVertical();
            Repaint();
        }
        else
            EditorGUILayout.LabelField("No existe preview");



        if (_worldPrev != null)
        {
            if (GUILayout.Button("Create"))
            {
                world = new GameObject("New World");
                _objectWorld = Instantiate(_objectWorld);
                _objectWorld.transform.parent = world.transform.parent;
                _objectWorld.transform.localScale = new Vector3(createSize, createSize, createSize);
            }

        }
    }
}


