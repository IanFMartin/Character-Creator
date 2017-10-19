using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class CharacterCreator : EditorWindow
{
    string _newName;
    Vector2  scroll;
    protected static GameObject _head;
    protected static GameObject _leftArm;
    protected static GameObject _rightArm;
    protected static GameObject _leftLeg;
    protected static GameObject _rightLeg;
    protected static GameObject _body;

    protected static Texture2D _headPreview;
    protected static Texture2D _leftArmPreview;
    protected static Texture2D _rightArmPreview;
    protected static Texture2D _leftLegPreview;
    protected static Texture2D _rightLegPreview;
    protected static Texture2D _bodyPreview;
    #region var useless
    //private Texture2D _listHeadPreview;
    //private Texture2D _listLeftArmPreview;
    //private Texture2D _listRightArmPrewview;
    //private Texture2D _listLeftLegPreview;
    //private Texture2D _listRightLegPreview;
    //private Texture2D _listBodyPreview;

    //private string _partName;
    //private string _partName2;
    //private string _partName3;
    //private string _partName4;
    //private string _partName5;
    //private string _partName6;

    //private List<Object> _headList = new List<Object>();
    //private List<Object> _rightArmList = new List<Object>();
    //private List<Object> _leftArmsList = new List<Object>();
    //private List<Object> _leftLegList = new List<Object>();
    //private List<Object> _rightLegList = new List<Object>();
    //private List<Object> _bodyList = new List<Object>();
    #endregion

    public Searcher partSearcher = new Searcher();

    [MenuItem("Windows/Character creator")]
    static void CreateWindow()
    {
        ((CharacterCreator)GetWindow(typeof(CharacterCreator))).Show();
    }

    private void OnGUI()
    {
        minSize = new Vector2(500, 800);
        //maxSize = new Vector2(500, 800);
        #region My Style
        var myStyle = new GUIStyle(GUI.skin.label);
        myStyle.alignment = TextAnchor.MiddleCenter;
        myStyle.fontStyle = FontStyle.Bold;
        myStyle.fontSize = 16;
        #endregion
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Character Creator", myStyle);
        scroll= GUILayout.BeginScrollView(scroll);

        if (_head == null)
        {

            if (GUI.Button(new Rect(200, 30, 100, 100), "Cabeza"))

            {
                ((HeadSelector)GetWindow(typeof(HeadSelector))).Show();
            }
        }
        else if (GUI.Button(new Rect(200, 30, 100, 100), _headPreview)) ((HeadSelector)GetWindow(typeof(HeadSelector))).Show();

        if (_body == null)
        {

            if (GUI.Button(new Rect(175, 140, 150, 200), "Cuerpo"))
            {
                ((BodySelector)GetWindow(typeof(BodySelector))).Show();
            }
        }
        else if (GUI.Button(new Rect(175, 140, 150, 200), _bodyPreview))
            ((BodySelector)GetWindow(typeof(BodySelector))).Show();

        if (_leftArm == null)
        {

            if (GUI.Button(new Rect(115, 140, 50, 175), "B-Izquierdo"))
            {
                ((LeftArmSelector)GetWindow(typeof(LeftArmSelector))).Show();
            }
        }
        else if (GUI.Button(new Rect(115, 140, 50, 175), _leftArmPreview))
            ((LeftArmSelector)GetWindow(typeof(LeftArmSelector))).Show();
        if (_rightArm == null)
        {
            if (GUI.Button(new Rect(335, 140, 50, 175), "B-Derecho"))
            {

                ((RightArmSelector)GetWindow(typeof(RightArmSelector))).Show();
            }
        }
        else if (GUI.Button(new Rect(335, 140, 50, 175), _rightArmPreview))
            ((RightArmSelector)GetWindow(typeof(RightArmSelector))).Show();

        if (_leftLeg == null)
        {
            if (GUI.Button(new Rect(175, 350, 60, 175), "L-Izquierda"))
            {
                ((LeftLegSelector)GetWindow(typeof(LeftLegSelector))).Show();

            }
        }
        else if (GUI.Button(new Rect(175, 350, 60, 175), _leftLegPreview))
            ((LeftLegSelector)GetWindow(typeof(LeftLegSelector))).Show();


        if (_rightLeg == null)
        {

            if (GUI.Button(new Rect(265, 350, 60, 175), "L-Derecha"))
            {

                ((RightLegSelector)GetWindow(typeof(RightLegSelector))).Show();
            }
        }
        else if (GUI.Button(new Rect(265, 350, 60, 175), _rightLegPreview))
            ((RightLegSelector)GetWindow(typeof(RightLegSelector))).Show();
        //ACORDATE QUE ACA ABAJO HAY UN O Y TIENE QUE IR UN Y. SE QUE TE VAS A OLVIDAR Y VAS A ENTRAR
        //EN UNA CRISIS, NO SEAS BOLUDO Y LEEEME, gil.
        if (_body != null || _head != null && _leftArm != null &&
            _rightArm != null && _leftLeg != null && _rightLeg != null)
        {
              _newName = EditorGUI.TextField(new Rect(0,540,500,50),"Name ", _newName);
            if (GUI.Button(new Rect(110,605,100,100) ,"Create and save"))
            {
                var _Character = new GameObject(_newName);

                var _neck = _body.transform.Find("Neck");
                var _rightShoulder = _body.transform.Find("RightShoulder");
                var _leftShoulder = _body.transform.Find("LeftShoulder");
                var _leftWaist = _body.transform.Find("LeftWaist");
                var _rightWaist = _body.transform.Find("RightWaist");


                var _bodyInstantiated = Instantiate(_body);
                var _headInstantiated = Instantiate(_head);
                var _rightArmInstantiated = Instantiate(_rightArm);
                var _leftArmInstantiated = Instantiate(_leftArm);
                var _rightLegInstantiated = Instantiate(_rightLeg);
                var _leftLegInstantiated = Instantiate(_leftLeg);

                _headInstantiated.transform.position = _neck.transform.position;
                _rightArmInstantiated.transform.position = _rightShoulder.transform.position;
                _rightArmInstantiated.transform.Rotate(new Vector3(0, 180, 0));
                _leftArmInstantiated.transform.position = _leftShoulder.transform.position;
                _leftLegInstantiated.transform.position = _leftWaist.transform.position;
                _rightLegInstantiated.transform.position = _rightWaist.transform.position;

                _bodyInstantiated.transform.parent = _Character.transform;
                _headInstantiated.transform.parent = _Character.transform;
                _rightArmInstantiated.transform.parent = _Character.transform;
                _leftArmInstantiated.transform.parent = _Character.transform;
                _rightLegInstantiated.transform.parent = _Character.transform;
                _leftLegInstantiated.transform.parent = _Character.transform;


                var asd = PrefabUtility.CreateEmptyPrefab("Assets/Prefab/" + _newName + ".prefab");
                PrefabUtility.ReplacePrefab(_Character, asd);
            }
            if (GUI.Button(new Rect(350, 605, 100, 100),"Close"))
            {
                Close();
            }
            if (GUI.Button(new Rect(235, 605, 100, 100),"Clear"))
            {
                _body = null;
                _head = null;
                _leftArm = null;
                _rightArm = null;
                _leftLeg = null;
                _rightLeg = null;
            }
        }

        GUILayout.EndScrollView();
    }
    public static void SpaceOnLine(int N)
    {
        for (int i = 0; i < N; i++)
        {
            EditorGUILayout.Space();

        }
    }
    #region Searcher
    //    private void HeadSearcher()
    //    {
    //        EditorGUILayout.LabelField("Search asset");
    //        var aux = _partName;
    //        _partName = EditorGUILayout.TextField(aux);
    //        int i;
    //        if (aux != _partName)
    //        {
    //            _headList.Clear();
    //            string[] allPaths = AssetDatabase.FindAssets(_partName);
    //            for (i = allPaths.Length - 1; i >= 0; i--)
    //            {
    //                allPaths[i] = AssetDatabase.GUIDToAssetPath(allPaths[i]);
    //                _headList.Add(AssetDatabase.LoadAssetAtPath(allPaths[i], typeof(Object)));
    //            }
    //        }
    //        for (i = _headList.Count - 1; i >= 0; i--)
    //        {
    //            if (_headList[i].GetType() == typeof(GameObject) && _headList[i].name.Contains("Head"))
    //            {
    //                EditorGUILayout.BeginHorizontal();
    //                EditorGUILayout.LabelField(_headList[i].ToString());
    //                _listHeadPreview = AssetPreview.GetAssetPreview(_headList[i]);
    //                if (_listHeadPreview != null)
    //                {
    //                    GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _listHeadPreview, ScaleMode.ScaleToFit);
    //                }
    //                if (GUILayout.Button("Select"))
    //                {

    //                    _head = (GameObject)_headList[i];
    //                }
    //                EditorGUILayout.EndHorizontal();
    //            }

    //        }
    //    }

    //    private void BodySearcher()
    //    {
    //        EditorGUILayout.LabelField("Search asset");
    //        var aux = _partName2;
    //        _partName2 = EditorGUILayout.TextField(aux);
    //        int i;
    //        if (aux != _partName2)
    //        {
    //            _bodyList.Clear();
    //            string[] allPaths = AssetDatabase.FindAssets(_partName2);
    //            for (i = allPaths.Length - 1; i >= 0; i--)
    //            {
    //                allPaths[i] = AssetDatabase.GUIDToAssetPath(allPaths[i]);
    //                _bodyList.Add(AssetDatabase.LoadAssetAtPath(allPaths[i], typeof(Object)));
    //            }
    //        }
    //        for (i = _bodyList.Count - 1; i >= 0; i--)
    //        {
    //            if (_bodyList[i].GetType() == typeof(GameObject) && _bodyList[i].name.Contains("Body"))
    //            {
    //                EditorGUILayout.BeginHorizontal();
    //                EditorGUILayout.LabelField(_bodyList[i].ToString());
    //                _listBodyPreview = AssetPreview.GetAssetPreview(_bodyList[i]);
    //                if (_listBodyPreview != null)
    //                {
    //                    GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _listBodyPreview, ScaleMode.ScaleToFit);
    //                }
    //                if (GUILayout.Button("Select"))
    //                {

    //                    _body = (GameObject)_bodyList[i];
    //                }
    //                EditorGUILayout.EndHorizontal();
    //            }

    //        }
    //    }

    //    private void LeftArmSearcher()
    //    {
    //        EditorGUILayout.LabelField("Search asset");
    //        var aux = _partName3;
    //        _partName3 = EditorGUILayout.TextField(aux);
    //        int i;
    //        if (aux != _partName3)
    //        {
    //            _leftArmsList.Clear();
    //            string[] allPaths = AssetDatabase.FindAssets(_partName3);
    //            for (i = allPaths.Length - 1; i >= 0; i--)
    //            {
    //                allPaths[i] = AssetDatabase.GUIDToAssetPath(allPaths[i]);
    //                _leftArmsList.Add(AssetDatabase.LoadAssetAtPath(allPaths[i], typeof(Object)));
    //            }
    //        }
    //        for (i = _leftArmsList.Count - 1; i >= 0; i--)
    //        {
    //            if (_leftArmsList[i].GetType() == typeof(GameObject) && _leftArmsList[i].name.Contains("Arm"))
    //            {
    //                EditorGUILayout.BeginHorizontal();
    //                EditorGUILayout.LabelField(_leftArmsList[i].ToString());
    //                _listLeftArmPreview = AssetPreview.GetAssetPreview(_leftArmsList[i]);
    //                if (_listLeftArmPreview != null)
    //                {
    //                    GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _listLeftArmPreview, ScaleMode.ScaleToFit);
    //                }
    //                if (GUILayout.Button("Select"))
    //                {

    //                    _leftArm = (GameObject)_leftArmsList[i];
    //                }
    //                EditorGUILayout.EndHorizontal();
    //            }

    //        }
    //    }

    //    private void RightArmSearcher()
    //    {
    //        EditorGUILayout.LabelField("Search asset");
    //        var aux = _partName4;
    //        _partName4 = EditorGUILayout.TextField(aux);
    //        int i;
    //        if (aux != _partName4)
    //        {
    //            _rightArmList.Clear();
    //            string[] allPaths = AssetDatabase.FindAssets(_partName4);
    //            for (i = allPaths.Length - 1; i >= 0; i--)
    //            {
    //                allPaths[i] = AssetDatabase.GUIDToAssetPath(allPaths[i]);
    //                _rightArmList.Add(AssetDatabase.LoadAssetAtPath(allPaths[i], typeof(Object)));
    //            }
    //        }
    //        for (i = _rightArmList.Count - 1; i >= 0; i--)
    //        {
    //            if (_rightArmList[i].GetType() == typeof(GameObject) && _rightArmList[i].name.Contains("Arm"))
    //            {
    //                EditorGUILayout.BeginHorizontal();
    //                EditorGUILayout.LabelField(_rightArmList[i].ToString());
    //                _listRightArmPrewview = AssetPreview.GetAssetPreview(_rightArmList[i]);
    //                if (_listRightArmPrewview != null)
    //                {
    //                    GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _listRightArmPrewview, ScaleMode.ScaleToFit);
    //                }
    //                if (GUILayout.Button("Select"))
    //                {

    //                    _rightArm = (GameObject)_rightArmList[i];
    //                }
    //                EditorGUILayout.EndHorizontal();
    //            }

    //        }
    //    }

    //private void LeftLegSearcher()
    //    {
    //        EditorGUILayout.LabelField("Search asset");
    //        var aux = _partName5;
    //        _partName5 = EditorGUILayout.TextField(aux);
    //        int i;
    //        if (aux != _partName5)
    //        {
    //            _leftLegList.Clear();
    //            string[] allPaths = AssetDatabase.FindAssets(_partName5);
    //            for (i = allPaths.Length - 1; i >= 0; i--)
    //            {
    //                allPaths[i] = AssetDatabase.GUIDToAssetPath(allPaths[i]);
    //                _leftLegList.Add(AssetDatabase.LoadAssetAtPath(allPaths[i], typeof(Object)));
    //            }
    //        }
    //        for (i = _leftLegList.Count - 1; i >= 0; i--)
    //        {
    //            if (_leftLegList[i].GetType() == typeof(GameObject) && _leftLegList[i].name.Contains("Leg"))
    //            {
    //                EditorGUILayout.BeginHorizontal();
    //                EditorGUILayout.LabelField(_leftLegList[i].ToString());
    //                _listLeftLegPreview = AssetPreview.GetAssetPreview(_leftLegList[i]);
    //                if (_listLeftLegPreview != null)
    //                {
    //                    GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _listLeftLegPreview, ScaleMode.ScaleToFit);
    //                }
    //                if (GUILayout.Button("Select"))
    //                {

    //                    _leftLeg = (GameObject)_leftLegList[i];
    //                }
    //                EditorGUILayout.EndHorizontal();
    //            }

    //        }
    //    }

    //    private void RightLegSearcher()
    //    {
    //        EditorGUILayout.LabelField("Search asset");
    //        var aux = _partName6;
    //        _partName6 = EditorGUILayout.TextField(aux);
    //        int i;
    //        if (aux != _partName6)
    //        {
    //            _rightLegList.Clear();
    //            string[] allPaths = AssetDatabase.FindAssets(_partName6);
    //            for (i = allPaths.Length - 1; i >= 0; i--)
    //            {
    //                allPaths[i] = AssetDatabase.GUIDToAssetPath(allPaths[i]);
    //                _rightLegList.Add(AssetDatabase.LoadAssetAtPath(allPaths[i], typeof(Object)));
    //            }
    //        }
    //        for (i = _rightLegList.Count - 1; i >= 0; i--)
    //        {
    //            if (_rightLegList[i].GetType() == typeof(GameObject) && _rightLegList[i].name.Contains("Leg"))
    //            {
    //                EditorGUILayout.BeginHorizontal();
    //                EditorGUILayout.LabelField(_rightLegList[i].ToString());
    //                _listRightLegPreview = AssetPreview.GetAssetPreview(_rightLegList[i]);
    //                if (_listRightLegPreview != null)
    //                {
    //                    GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _listRightLegPreview, ScaleMode.ScaleToFit);
    //                }
    //                if (GUILayout.Button("Select"))
    //                {
    //                    _rightLeg = (GameObject)_rightLegList[i];
    //                }
    //                EditorGUILayout.EndHorizontal();
    //            }

    //        }
    //    }
    #endregion
}
