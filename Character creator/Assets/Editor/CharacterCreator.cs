using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class CharacterCreator : EditorWindow
{
    private GameObject _head;
    private GameObject _leftArm;
    private GameObject _rightArm;
    private GameObject _leftLeg;
    private GameObject _rightLeg;
    private GameObject _body;

    private Texture2D _headPreview;
    private Texture2D _leftArmPreview;
    private Texture2D _rightArmPreview;
    private Texture2D _leftLegPreview;
    private Texture2D _rightLegPreview;
    private Texture2D _bodyPreview;

    private Texture2D _listHeadPreview;
    private Texture2D _listLeftArmPreview;
    private Texture2D _listRightArmPrewview;
    private Texture2D _listLeftLegPreview;
    private Texture2D _listRightLegPreview;
    private Texture2D _listBodyPreview;

    private string _partName;
    private string _partName2;
    private string _partName3;
    private string _partName4;
    private string _partName5;
    private string _partName6;

    private List<Object> _headList = new List<Object>();
    private List<Object> _rightArmList = new List<Object>();
    private List<Object> _leftArmsList = new List<Object>();
    private List<Object> _leftLegList = new List<Object>();
    private List<Object> _rightLegList = new List<Object>();
    private List<Object> _bodyList = new List<Object>();

    [MenuItem("Window/Character creator")]
    static void CreateWindow()
    {
        ((CharacterCreator)GetWindow(typeof(CharacterCreator))).Show();
    }

    private void OnGUI()
    {
        minSize = new Vector2(500, 300);

        EditorGUILayout.LabelField("CHARACTER CREATOR", EditorStyles.boldLabel);
        GUILayout.BeginScrollView(new Vector2(300, 300));
        #region Searchers
        _head = (GameObject)EditorGUILayout.ObjectField("Head :", _head, typeof(GameObject), true);

        if (_head == null) HeadSearcher();
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

        }

        _body = (GameObject)EditorGUILayout.ObjectField("Body :", _body, typeof(GameObject), true);
        if (_body == null) BodySearcher();
        else
        {
            _bodyPreview = AssetPreview.GetAssetPreview(_body);
            if (_bodyPreview != null)
            {
                GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _bodyPreview, ScaleMode.ScaleToFit);
            }
            if (GUILayout.Button("Clear"))
            {
                _body = null;
            }
        }


        _leftArm = (GameObject)EditorGUILayout.ObjectField("Left arm :", _leftArm, typeof(GameObject), true);
        if (_leftArm == null) LeftArmSearcher();
        else
        {
            _leftArmPreview = AssetPreview.GetAssetPreview(_leftArm);
            if (_leftArmPreview != null)
            {
                GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _leftArmPreview, ScaleMode.ScaleToFit);
            }
            if (GUILayout.Button("Clear"))
            {
                _leftArm = null;
            }
        }


        _rightArm = (GameObject)EditorGUILayout.ObjectField("Right arm :", _rightArm, typeof(GameObject), true);
        if (_rightArm == null) RightArmSearcher();
        else
        {
            _rightArmPreview = AssetPreview.GetAssetPreview(_rightArm);
            if (_rightArmPreview != null)
            {
                GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _rightArmPreview, ScaleMode.ScaleToFit);
            }
            if (GUILayout.Button("Clear"))
            {
                _rightArm = null;
            }
        }


        _leftLeg = (GameObject)EditorGUILayout.ObjectField("Left leg :", _leftLeg, typeof(GameObject), true);
        if (_leftLeg == null) LeftLegSearcher();
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
        }


        _rightLeg = (GameObject)EditorGUILayout.ObjectField("Right leg :", _rightLeg, typeof(GameObject), true);
        if (_rightLeg == null) RightLegSearcher();
        else
        {
            _rightLegPreview = AssetPreview.GetAssetPreview(_rightLeg);
            if (_rightLegPreview != null)
            {
                GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _rightLegPreview, ScaleMode.ScaleToFit);
            }
            if (GUILayout.Button("Clear"))
            {
                _rightLeg = null;
            }
        }
        #endregion

        GUILayout.EndScrollView();
    }

    private void HeadSearcher()
    {
        EditorGUILayout.LabelField("Search asset");
        var aux = _partName;
        _partName = EditorGUILayout.TextField(aux);
        int i;
        if (aux != _partName)
        {
            _headList.Clear();
            string[] allPaths = AssetDatabase.FindAssets(_partName);
            for (i = allPaths.Length - 1; i >= 0; i--)
            {
                allPaths[i] = AssetDatabase.GUIDToAssetPath(allPaths[i]);
                _headList.Add(AssetDatabase.LoadAssetAtPath(allPaths[i], typeof(Object)));
            }
        }
        for (i = _headList.Count - 1; i >= 0; i--)
        {
            if (_headList[i].GetType() == typeof(GameObject) && _headList[i].name.Contains("Head"))
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(_headList[i].ToString());
                _listHeadPreview = AssetPreview.GetAssetPreview(_headList[i]);
                if (_listHeadPreview != null)
                {
                    GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _listHeadPreview, ScaleMode.ScaleToFit);
                }
                if (GUILayout.Button("Select"))
                {
                    
                    _head = (GameObject)_headList[i];
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
            _bodyList.Clear();
            string[] allPaths = AssetDatabase.FindAssets(_partName2);
            for (i = allPaths.Length - 1; i >= 0; i--)
            {
                allPaths[i] = AssetDatabase.GUIDToAssetPath(allPaths[i]);
                _bodyList.Add(AssetDatabase.LoadAssetAtPath(allPaths[i], typeof(Object)));
            }
        }
        for (i = _bodyList.Count - 1; i >= 0; i--)
        {
            if (_bodyList[i].GetType() == typeof(GameObject) && _bodyList[i].name.Contains("Body"))
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(_bodyList[i].ToString());
                _listBodyPreview = AssetPreview.GetAssetPreview(_bodyList[i]);
                if (_listBodyPreview != null)
                {
                    GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _listBodyPreview, ScaleMode.ScaleToFit);
                }
                if (GUILayout.Button("Select"))
                {

                    _body = (GameObject)_bodyList[i];
                }
                EditorGUILayout.EndHorizontal();
            }

        }
    }

    private void LeftArmSearcher()
    {
        EditorGUILayout.LabelField("Search asset");
        var aux = _partName3;
        _partName3 = EditorGUILayout.TextField(aux);
        int i;
        if (aux != _partName3)
        {
            _leftArmsList.Clear();
            string[] allPaths = AssetDatabase.FindAssets(_partName3);
            for (i = allPaths.Length - 1; i >= 0; i--)
            {
                allPaths[i] = AssetDatabase.GUIDToAssetPath(allPaths[i]);
                _leftArmsList.Add(AssetDatabase.LoadAssetAtPath(allPaths[i], typeof(Object)));
            }
        }
        for (i = _leftArmsList.Count - 1; i >= 0; i--)
        {
            if (_leftArmsList[i].GetType() == typeof(GameObject) && _leftArmsList[i].name.Contains("Arm"))
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(_leftArmsList[i].ToString());
                _listLeftArmPreview = AssetPreview.GetAssetPreview(_leftArmsList[i]);
                if (_listLeftArmPreview != null)
                {
                    GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _listLeftArmPreview, ScaleMode.ScaleToFit);
                }
                if (GUILayout.Button("Select"))
                {

                    _leftArm = (GameObject)_leftArmsList[i];
                }
                EditorGUILayout.EndHorizontal();
            }

        }
    }

    private void RightArmSearcher()
    {
        EditorGUILayout.LabelField("Search asset");
        var aux = _partName4;
        _partName4 = EditorGUILayout.TextField(aux);
        int i;
        if (aux != _partName4)
        {
            _rightArmList.Clear();
            string[] allPaths = AssetDatabase.FindAssets(_partName4);
            for (i = allPaths.Length - 1; i >= 0; i--)
            {
                allPaths[i] = AssetDatabase.GUIDToAssetPath(allPaths[i]);
                _rightArmList.Add(AssetDatabase.LoadAssetAtPath(allPaths[i], typeof(Object)));
            }
        }
        for (i = _rightArmList.Count - 1; i >= 0; i--)
        {
            if (_rightArmList[i].GetType() == typeof(GameObject) && _rightArmList[i].name.Contains("Arm"))
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(_rightArmList[i].ToString());
                _listRightArmPrewview = AssetPreview.GetAssetPreview(_rightArmList[i]);
                if (_listRightArmPrewview != null)
                {
                    GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _listRightArmPrewview, ScaleMode.ScaleToFit);
                }
                if (GUILayout.Button("Select"))
                {

                    _rightArm = (GameObject)_rightArmList[i];
                }
                EditorGUILayout.EndHorizontal();
            }

        }
    }

private void LeftLegSearcher()
    {
        EditorGUILayout.LabelField("Search asset");
        var aux = _partName5;
        _partName5 = EditorGUILayout.TextField(aux);
        int i;
        if (aux != _partName5)
        {
            _leftLegList.Clear();
            string[] allPaths = AssetDatabase.FindAssets(_partName5);
            for (i = allPaths.Length - 1; i >= 0; i--)
            {
                allPaths[i] = AssetDatabase.GUIDToAssetPath(allPaths[i]);
                _leftLegList.Add(AssetDatabase.LoadAssetAtPath(allPaths[i], typeof(Object)));
            }
        }
        for (i = _leftLegList.Count - 1; i >= 0; i--)
        {
            if (_leftLegList[i].GetType() == typeof(GameObject) && _leftLegList[i].name.Contains("Leg"))
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(_leftLegList[i].ToString());
                _listLeftLegPreview = AssetPreview.GetAssetPreview(_leftLegList[i]);
                if (_listLeftLegPreview != null)
                {
                    GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _listLeftLegPreview, ScaleMode.ScaleToFit);
                }
                if (GUILayout.Button("Select"))
                {

                    _leftLeg = (GameObject)_leftLegList[i];
                }
                EditorGUILayout.EndHorizontal();
            }

        }
    }

    private void RightLegSearcher()
    {
        EditorGUILayout.LabelField("Search asset");
        var aux = _partName6;
        _partName6 = EditorGUILayout.TextField(aux);
        int i;
        if (aux != _partName6)
        {
            _rightLegList.Clear();
            string[] allPaths = AssetDatabase.FindAssets(_partName6);
            for (i = allPaths.Length - 1; i >= 0; i--)
            {
                allPaths[i] = AssetDatabase.GUIDToAssetPath(allPaths[i]);
                _rightLegList.Add(AssetDatabase.LoadAssetAtPath(allPaths[i], typeof(Object)));
            }
        }
        for (i = _rightLegList.Count - 1; i >= 0; i--)
        {
            if (_rightLegList[i].GetType() == typeof(GameObject) && _rightLegList[i].name.Contains("Leg"))
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(_rightLegList[i].ToString());
                _listRightLegPreview = AssetPreview.GetAssetPreview(_rightLegList[i]);
                if (_listRightLegPreview != null)
                {
                    GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _listRightLegPreview, ScaleMode.ScaleToFit);
                }
                if (GUILayout.Button("Select"))
                {
                    _rightLeg = (GameObject)_rightLegList[i];
                }
                EditorGUILayout.EndHorizontal();
            }

        }
    }
}
