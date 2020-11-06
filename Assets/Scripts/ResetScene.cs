////////////////////////////
/// By: Dhruv
/// Date: 11/4/2020
/// Desription: This is a script to be used by unity event to rest the Scene OR will be activated by pressing "R"
///////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{   
    //if you press "R" call ResetTheScene
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            ResetTheScene();
        }
    }

    //unity event function
    public void ResetTheScene()
    {
        //Reset the screen and log it
        Debug.Log("SceneReset");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
