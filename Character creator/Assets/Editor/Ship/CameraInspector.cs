using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
[CustomEditor(typeof(CameraControl))]
public class CameraInspector : Editor
{
    CameraControl _target;
    bool _fade;
    bool _groupFollowEnabled;
    static int camTypes;
    public static GameObject _objectFollow;
    public Vector3 followOffset = new Vector3(+5, +5, 0);
    bool _groupLookEnabled;
    public static GameObject _objectLook;
    string[] cameraTypes = { "Top", "Down", "Follow", "Look", "None" };
   

    private void OnEnable()
    {
        Cam();
    }

    private void Cam()
    {
        _target = (CameraControl)target;
    }

    public override void OnInspectorGUI()
    {

        ShowValues();
    }

    void ShowValues()
    {
        camTypes = EditorGUILayout.Popup("Camera types", camTypes, cameraTypes);
        if (camTypes == 0)
        {
            _target.transform.position = new Vector3(0, 20, 0);
            _target.transform.forward = new Vector3(0, -1, 0);
            _groupLookEnabled = false;
            _groupFollowEnabled = false;
        }
        else if (camTypes == 1)
        {
            _target.transform.position = new Vector3(20, 0, 0);
            _target.transform.forward = new Vector3(-1, 0, 0);
            _groupLookEnabled = false;
            _groupFollowEnabled = false;
        }
        else if (camTypes == 2)
        {
            _groupFollowEnabled = true;
            _groupLookEnabled = false;
        }
        else if (camTypes == 3)
        {
            _groupLookEnabled = true;
            _groupFollowEnabled = false;
        }
        //var a =_target.GetComponent<Camera>();

        //Region Follow
        #region
        _groupFollowEnabled = EditorGUILayout.BeginToggleGroup("Following", _groupFollowEnabled);
        EditorGUILayout.EndToggleGroup();
        if (camTypes != 2)
        {
            EditorGUILayout.HelpBox("Select Follow option to active", MessageType.Info);
        }
        else
        {
            EditorGUILayout.HelpBox("Activated", MessageType.Info);
            EditorGUILayout.LabelField("Add Game Object to follow", EditorStyles.boldLabel);
            _objectFollow = (GameObject)EditorGUILayout.ObjectField("Object: ", _objectFollow, typeof(Object), true);
            if (_objectFollow != null)
            {
                _target.transform.position = _objectFollow.transform.localPosition + followOffset;
                _target.transform.forward = _objectFollow.transform.position.normalized;
                _target.transform.Rotate(80, 0, 0);
            }
        }
        #endregion //

        //Region Look
        #region
        _groupLookEnabled = EditorGUILayout.BeginToggleGroup("Looking", _groupLookEnabled);
        EditorGUILayout.EndToggleGroup();
        if (camTypes != 3)
        {
            EditorGUILayout.HelpBox("Select Look option to active", MessageType.Info);
        }
        else
        {
            EditorGUILayout.HelpBox("Activated", MessageType.Info);
            EditorGUILayout.LabelField("Add Game Object to look", EditorStyles.boldLabel);
            _objectLook = (GameObject)EditorGUILayout.ObjectField("Object: ", _objectLook, typeof(Object), true);
            if (_objectLook != null)
            {
                _target.transform.forward = (_objectLook.transform.position - _target.transform.position).normalized;
            }
        }
        #endregion
    }
}
