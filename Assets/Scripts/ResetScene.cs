////////////////////////////
/// By: Dhruv
/// Date: 11/4/2020
/// Desription: This is a script to be used by unity event to rest the Scene
///////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetScene : MonoBehaviour
{
    public void ResetTheScene()
    {
        //Reset the screen and log it
        Debug.Log("SceneReset");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
