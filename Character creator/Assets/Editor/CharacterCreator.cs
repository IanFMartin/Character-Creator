using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class CharacterCreator : EditorWindow
{
    string _newName;
    string _scriptName;

    Vector2 scroll;

    int totalLife;
    int totalShield;
    int totalForce;

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

    List<Object> _scriptSearcher = new List<Object>();
    List<Object> scriptList = new List<Object>();

    MonoScript script;

    Character character;


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

    [MenuItem("Editor Windows/Character creator")]
    static void CreateWindow()
    {
        ((CharacterCreator)GetWindow(typeof(CharacterCreator))).Show();
    }

    private void OnGUI()
    {
        minSize = new Vector2(500, 800);
        maxSize = new Vector2(500, 800);
        #region My Style
        var myStyle = new GUIStyle(GUI.skin.label);
        myStyle.alignment = TextAnchor.MiddleCenter;
        myStyle.fontStyle = FontStyle.Bold;
        myStyle.fontSize = 16;
        #endregion
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Character Creator", myStyle);
        scroll = EditorGUILayout.BeginScrollView(scroll, true, false, GUILayout.Width(Screen.width), GUILayout.Height(Screen.height - 55));

        if (_head == null)
        {

            if (GUI.Button(new Rect(200, 30, 100, 100), "Head"))

            {
                ((HeadSelector)GetWindow(typeof(HeadSelector))).Show();
            }
        }
        else if (GUI.Button(new Rect(200, 30, 100, 100), _headPreview)) ((HeadSelector)GetWindow(typeof(HeadSelector))).Show();

        if (_body == null)
        {

            if (GUI.Button(new Rect(175, 140, 150, 200), "Body"))
            {
                ((BodySelector)GetWindow(typeof(BodySelector))).Show();
            }
        }
        else if (GUI.Button(new Rect(175, 140, 150, 200), _bodyPreview))
            ((BodySelector)GetWindow(typeof(BodySelector))).Show();

        if (_leftArm == null)
        {

            if (GUI.Button(new Rect(115, 140, 50, 175), "Left" + "\n" + "Arm"))
            {
                ((LeftArmSelector)GetWindow(typeof(LeftArmSelector))).Show();
            }
        }
        else if (GUI.Button(new Rect(115, 140, 50, 175), _leftArmPreview))
            ((LeftArmSelector)GetWindow(typeof(LeftArmSelector))).Show();
        if (_rightArm == null)
        {
            if (GUI.Button(new Rect(335, 140, 50, 175), "Right" + "\n" + "Arm"))
            {

                ((RightArmSelector)GetWindow(typeof(RightArmSelector))).Show();
            }
        }
        else if (GUI.Button(new Rect(335, 140, 50, 175), _rightArmPreview))
            ((RightArmSelector)GetWindow(typeof(RightArmSelector))).Show();

        if (_leftLeg == null)
        {
            if (GUI.Button(new Rect(175, 350, 60, 175), "Left" + "\n" + "Leg"))
            {
                ((LeftLegSelector)GetWindow(typeof(LeftLegSelector))).Show();

            }
        }
        else if (GUI.Button(new Rect(175, 350, 60, 175), _leftLegPreview))
            ((LeftLegSelector)GetWindow(typeof(LeftLegSelector))).Show();


        if (_rightLeg == null)
        {

            if (GUI.Button(new Rect(265, 350, 60, 175), "Right" + "\n" + "Leg"))
            {

                ((RightLegSelector)GetWindow(typeof(RightLegSelector))).Show();
            }
        }
        else if (GUI.Button(new Rect(265, 350, 60, 175), _rightLegPreview))
            ((RightLegSelector)GetWindow(typeof(RightLegSelector))).Show();
        //YA CAMBIASTE EL O POR EL Y NO TE OLVIDES
        if (_body != null && _head != null && _leftArm != null &&
            _rightArm != null && _leftLeg != null && _rightLeg != null)
        {
            GUILayout.BeginVertical();
            _newName = EditorGUI.TextField(new Rect(5, 540, 400, 20), "Name ", _newName);

            totalLife = HeadSelector.life + LeftArmSelector.life + LeftLegSelector.life +
                        RightArmSelector.life + RightLegSelector.life + BodySelector.life;
            totalForce = HeadSelector.force + LeftArmSelector.force + LeftLegSelector.force +
                        RightArmSelector.force + RightLegSelector.force + BodySelector.force;
            totalShield = HeadSelector.shield + LeftArmSelector.shield + LeftLegSelector.shield +
                        RightArmSelector.shield + RightLegSelector.shield + BodySelector.shield;

            EditorGUI.LabelField(new Rect(100, 575, 120, 25), "Total Life :  " + totalLife);
            EditorGUI.LabelField(new Rect(235, 575, 120, 25), "Total Shield :  " + totalShield);
            EditorGUI.LabelField(new Rect(365, 575, 120, 25), "Total Force :  " + totalForce);




            #region Create and save
            if (GUI.Button(new Rect(100, 615, 120, 25), "Create and save"))
            {
                if (_newName == null || _newName == "")
                {
                    _newName = "Character";
                }
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

                _Character.AddComponent<Character>();
                _Character.GetComponent<Character>().headTrasnform = _headInstantiated.transform;

                Object emptyPrefab = PrefabUtility.CreateEmptyPrefab("Assets/Prefab/" + _newName + ".prefab");
                PrefabUtility.ReplacePrefab(_Character, emptyPrefab);

                AssetDatabase.CreateFolder("Assets/ScriptableObject", _Character.name);
                string path = "Assets/ScriptableObject/" + _Character.name + "/";
                ScriptableObjectUtility.CreateAsset<BodypartStats>(path, "Body of " + _Character.name, BodySelector.life,
                                                                     BodySelector.shield, BodySelector.force);
                ScriptableObjectUtility.CreateAsset<BodypartStats>(path, "Left arm of " + _Character.name, LeftArmSelector.life,
                                                                    LeftArmSelector.shield, LeftArmSelector.force);
                ScriptableObjectUtility.CreateAsset<BodypartStats>(path, "Right arm of " + _Character.name, RightArmSelector.life,
                                                                    RightArmSelector.shield, RightArmSelector.force);
                ScriptableObjectUtility.CreateAsset<BodypartStats>(path, "Left leg of " + _Character.name, LeftLegSelector.life,
                                                                    LeftLegSelector.shield, LeftLegSelector.force);
                ScriptableObjectUtility.CreateAsset<BodypartStats>(path, "Right leg of " + _Character.name, RightLegSelector.life,
                                                                    RightLegSelector.shield, RightLegSelector.force);
                ScriptableObjectUtility.CreateAsset<BodypartStats>(path, "Head of " + _Character.name, HeadSelector.life,
                                                                    HeadSelector.shield, HeadSelector.force);

                var partStats = _Character.GetComponent<Character>().bodyStats = new BodypartStats();
                partStats.life = BodySelector.life;
                partStats.shield = BodySelector.shield;
                partStats.force = BodySelector.force;
                partStats = _Character.GetComponent<Character>().headStats = new BodypartStats();
                partStats.life = HeadSelector.life;
                partStats.shield = HeadSelector.shield;
                partStats.force = HeadSelector.force;
                partStats = _Character.GetComponent<Character>().arm1Stats = new BodypartStats();
                partStats.life = LeftArmSelector.life;
                partStats.shield = LeftArmSelector.shield;
                partStats.force = LeftArmSelector.force;
                partStats = _Character.GetComponent<Character>().arm2Stats = new BodypartStats();
                partStats.life = RightArmSelector.life;
                partStats.shield = RightArmSelector.shield;
                partStats.force = RightArmSelector.force;
                partStats = _Character.GetComponent<Character>().leg1Stats = new BodypartStats();
                partStats.life = LeftLegSelector.life;
                partStats.shield = LeftLegSelector.shield;
                partStats.force = LeftLegSelector.force;
                partStats = _Character.GetComponent<Character>().leg2Stats = new BodypartStats();
                partStats.life = RightLegSelector.life;
                partStats.shield = RightLegSelector.shield;
                partStats.force = RightLegSelector.force;
                partStats = _Character.GetComponent<Character>().totalStats = new BodypartStats();
                partStats.life = totalLife;
                partStats.shield = totalShield;
                partStats.force = totalForce;
            }
            #endregion

            if (GUI.Button(new Rect(350, 615, 100, 25), "Close"))
            {
                Close();
            }
            if (GUI.Button(new Rect(235, 615, 100, 25), "Clear"))
            {
                _body = null;
                _head = null;
                _leftArm = null;
                _rightArm = null;
                _leftLeg = null;
                _rightLeg = null;
                _newName = null;
                totalForce = 0;
                totalLife = 0;
                totalShield = 0;
            }
            GUILayout.EndVertical();
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

}
