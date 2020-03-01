using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Threading;


public class ShipCreatorWindows : EditorWindow
{
    private Texture2D _shipPreview;
    public GameObject _objectShip;
    public string searchShipName = "Ship";
    public List<Object> shipAssets = new List<Object>();


    private Texture2D _weaponPreview;
    public GameObject _objectWeapon;
    public string searchWeaponName = "Gun";
    public List<Object> weaponAssets = new List<Object>();

    public GameObject _NEWShip;

    [MenuItem("Editor Windows/Ship Creator Window")]
    static void CreateWindow()
    {
        ((ShipCreatorWindows)GetWindow(typeof(ShipCreatorWindows))).Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("Ship Creator", EditorStyles.boldLabel);

        GUILayout.Space(2f);

        ShipSwitch();
        WeaponSwitch();

        CreateShip();
    }

    private void CreateShip ()
    {
        if (_objectWeapon != null && _objectShip != null)
        {
            Rect rec = EditorGUILayout.BeginVertical();
            if (GUI.Button(rec, GUIContent.none))
            {
                _NEWShip = new GameObject("New Ship Created");
                var gunPos = _objectShip.transform.Find("GunPos");
                _objectShip = Instantiate(_objectShip);
                _objectWeapon = Instantiate(_objectWeapon);
                _objectWeapon.transform.position = gunPos.transform.position;
                _objectShip.transform.parent = _NEWShip.transform;
                _objectWeapon.transform.parent = _NEWShip.transform;

                _NEWShip.AddComponent<MeshCollider>();
                _NEWShip.AddComponent<MeshRenderer>();
                _NEWShip.AddComponent<Ship>();
            }
            GUILayout.Label("Create Ship");
            EditorGUILayout.EndVertical();
            if (GUILayout.Button("Close"))
            {
                Close();
            }
        }
    }

    private void ShipSwitch ()
    {
        PrefabShipSearcher();
        if (_objectShip != null)
        {
            if (AssetDatabase.Contains(_objectShip))
            {
                PrefabShipShow();
                EditorGUILayout.HelpBox("Object displayed", MessageType.Info);
            }
            else
            {
                EditorGUILayout.HelpBox("No prefab selected", MessageType.Info);
            }
        }
        else
        {
            _objectShip = (GameObject)EditorGUILayout.ObjectField("Object: ", _objectShip, typeof(Object), true);
            EditorGUILayout.HelpBox("Select a prefab", MessageType.Info);
        }
    }
    private void PrefabShipSearcher ()
    {
        EditorGUILayout.LabelField("Select ship");
        var aux = searchShipName;
        //searchAssetName = EditorGUILayout.TextField(aux);
        int i;
        if (aux == searchShipName)
        {
            shipAssets.Clear();
            string[] path = AssetDatabase.FindAssets(searchShipName);
            for (i = path.Length - 1; i >= 0; i--)
            {
                path[i] = AssetDatabase.GUIDToAssetPath(path[i]);
                shipAssets.Add(AssetDatabase.LoadAssetAtPath(path[i], typeof(GameObject)));

            }

        }

        for (int j = shipAssets.Count - 1; j >= 0; j--)
        {
            if (shipAssets[j] != null)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(shipAssets[j].name);

                if (GUILayout.Button("Select"))
                {
                    _objectShip = (GameObject)shipAssets[j];

                }
                _shipPreview = AssetPreview.GetAssetPreview(_objectShip);
                EditorGUILayout.EndHorizontal();
            }

        }
    }
    private void PrefabShipShow ()
    {
        if (_shipPreview != null)
        {
            Repaint();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Selected: " + _objectShip.name);
            GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _shipPreview, ScaleMode.ScaleToFit);
            EditorGUILayout.LabelField("Path: " + AssetDatabase.GetAssetPath(_objectShip));
            GUILayout.EndHorizontal();
        }
        else
            EditorGUILayout.LabelField("No existe preview");
    }

    private void WeaponSwitch ()
    {
        PrefabWeaponSearcher();
        if (_objectWeapon != null)
        {
            if (AssetDatabase.Contains(_objectWeapon))
            {
                PrefabWeaponShow();
                EditorGUILayout.HelpBox("Object displayed", MessageType.Info);
            }
            else
            {
                EditorGUILayout.HelpBox("No prefab selected", MessageType.Info);
            }
        }
        else
        {
            _objectWeapon = (GameObject)EditorGUILayout.ObjectField("Object: ", _objectWeapon, typeof(Object), true);
            EditorGUILayout.HelpBox("Select a prefab", MessageType.Info);
        }
    }
    private void PrefabWeaponSearcher ()
    {

        EditorGUILayout.LabelField("Select a weapon");
        var aux = searchWeaponName;
        //searchAssetName = EditorGUILayout.TextField(aux);
        int i;
        if (aux == searchWeaponName)
        {
            weaponAssets.Clear();
            string[] path = AssetDatabase.FindAssets(searchWeaponName);
            for (i = path.Length - 1; i >= 0; i--)
            {
                path[i] = AssetDatabase.GUIDToAssetPath(path[i]);
                weaponAssets.Add(AssetDatabase.LoadAssetAtPath(path[i], typeof(GameObject)));

            }

        }

        for (int j = weaponAssets.Count - 1; j >= 0; j--)
        {
            if (weaponAssets[j] != null)
            {

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(weaponAssets[j].name);

                if (GUILayout.Button("Select"))
                {
                    _objectWeapon = (GameObject)weaponAssets[j];

                }
                _weaponPreview = AssetPreview.GetAssetPreview(_objectWeapon);
                EditorGUILayout.EndHorizontal();
            }

        }
    }
    private void PrefabWeaponShow()
    {

        if (_weaponPreview != null)
        {
            Repaint();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Selected: "+ _objectWeapon.name);
            GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _weaponPreview, ScaleMode.ScaleToFit);
            EditorGUILayout.LabelField("Path: " + AssetDatabase.GetAssetPath(_objectWeapon));
            GUILayout.EndHorizontal();
        }
        else
            EditorGUILayout.LabelField("Preview not found");
    }
}
