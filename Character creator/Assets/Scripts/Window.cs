using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Threading;
using System.Collections.Generic;

public class Window : EditorWindow
{

    private GameObject _myHead;
    private GameObject _myBody;
    private GameObject _ME;
    private string _partName;
    private string _partName2;
    private string _newName = "new enemy";
    private Texture2D _preview;
    private Texture2D _preview2;
    private Texture2D _preview3;
    private Texture2D _preview4;
    private List<Object> _head = new List<Object>();
    private List<Object> _body = new List<Object>();


    [MenuItem("Custom Windows/Create enemy")]
    static void CreateWindow()
    {
        ((Window)GetWindow(typeof(Window))).Show();
    }
    void OnGUI()
    {
        minSize = new Vector2(500, 300);
        maxSize = new Vector2(500, 500);
        _myHead = (GameObject)EditorGUILayout.ObjectField("Head :", _myHead, typeof(GameObject), true);
        if (_myHead == null) HeadSearcher();
        else
        {
            _preview = AssetPreview.GetAssetPreview(_myHead);
            if (_preview != null)
            {
                GUILayout.BeginHorizontal();
                GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _preview, ScaleMode.ScaleToFit);
                GUILayout.EndHorizontal();
            }
            if (GUILayout.Button("Clear"))
            {
                _myHead = null;
            }

        }
        _myBody = (GameObject)EditorGUILayout.ObjectField("Body :", _myBody, typeof(GameObject), true);
        if (_myBody == null) BodySearcher();
        else
        {
            _preview2 = AssetPreview.GetAssetPreview(_myBody);
            if (_preview2 != null)
            {
                GUILayout.BeginHorizontal();
                GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _preview2, ScaleMode.ScaleToFit);
                GUILayout.EndHorizontal();
            }
            if (GUILayout.Button("Clear"))
            {
                _myBody = null;
            }
        }



        if (_myBody != null && _myHead != null)
        {
            _newName = EditorGUILayout.TextField("Name ", _newName);
            if (GUILayout.Button("Create and save"))
            {
                _ME = new GameObject(_newName);
                var _Myneck = _myBody.transform.Find("neck");
                var _myBodyInstantiated = Instantiate(_myBody);
                var _myHeadInstantiated = Instantiate(_myHead);
                _myHeadInstantiated.transform.position = _Myneck.transform.localPosition;
                _myBodyInstantiated.transform.parent = _ME.transform;
                _myHeadInstantiated.transform.parent = _ME.transform;
                var asd = PrefabUtility.CreateEmptyPrefab("Assets/Prefab/New Enemy/" + _newName + "_enemy.prefab");
                PrefabUtility.ReplacePrefab(_ME, asd);
            }
            if (GUILayout.Button("Close"))
            {
                Close();
            }
        }
    }
    private void HeadSearcher()
    {
        EditorGUILayout.LabelField("Search asset");
        var aux = _partName;
        _partName = EditorGUILayout.TextField(aux);
        int i;
        if (aux != _partName)
        {
            _head.Clear();
            string[] allPaths = AssetDatabase.FindAssets(_partName);
            for (i = allPaths.Length - 1; i >= 0; i--)
            {
                allPaths[i] = AssetDatabase.GUIDToAssetPath(allPaths[i]);
                _head.Add(AssetDatabase.LoadAssetAtPath(allPaths[i], typeof(Object)));
            }
        }
        for (i = _head.Count - 1; i >= 0; i--)
        {
            if (_head[i].GetType() == typeof(GameObject) && _head[i].name.Contains("Head"))
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(_head[i].ToString());
                _preview3 = AssetPreview.GetAssetPreview(_head[i]);
                if (_preview3 != null)
                {
                    GUILayout.BeginHorizontal();
                    GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _preview3, ScaleMode.ScaleToFit);
                    GUILayout.EndHorizontal();
                }
                if (GUILayout.Button("Select"))
                {
                    _myHead = (GameObject)_head[i];
                }
                EditorGUILayout.EndHorizontal();
            }

        }
    }
    private void BodySearcher()
    {
        EditorGUILayout.LabelField("Search asset");
        var aux = _partName2;
        _partName2 = EditorGUILayout.TextField(aux);
        int i;
        if (aux != _partName2)
        {
            _body.Clear();
            string[] allPaths = AssetDatabase.FindAssets(_partName2);
            for (i = allPaths.Length - 1; i >= 0; i--)
            {
                allPaths[i] = AssetDatabase.GUIDToAssetPath(allPaths[i]);
                _body.Add(AssetDatabase.LoadAssetAtPath(allPaths[i], typeof(Object)));
            }
        }
        for (i = _body.Count - 1; i >= 0; i--)
        {
            if (_body[i].GetType() == typeof(GameObject) && _body[i].name.Contains("Body"))
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(_body[i].ToString());
                _preview4 = AssetPreview.GetAssetPreview(_body[i]);
                if (_preview4 != null)
                {
                    GUILayout.BeginHorizontal();
                    GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _preview4, ScaleMode.ScaleToFit);
                    GUILayout.EndHorizontal();
                }
                if (GUILayout.Button("Select"))
                {
                    _myBody = (GameObject)_body[i];
                }
                EditorGUILayout.EndHorizontal();
            }
        }
    }

}
