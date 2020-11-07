////////////////////////////
/// By: Gavin C
/// Date: 11/6/2020
/// Desription: This is a script to be accused via unity events to change the scene
///////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventChangeScene : MonoBehaviour
{
    [Tooltip("Name of the scene you want this script to load")]
    public string SceneName;

    //Load new scene
    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
