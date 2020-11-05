////////////////////////////
/// By: Gavin C
/// Date: 11/4/2020
/// Desription: This is a script to go on a object with a trigger collider, changes scene when player touch, remember to add scenes to build
///////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollide : MonoBehaviour
{
    public string SceneName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Transform>().tag == "Player")
        {   
            SceneManager.LoadScene(SceneName);
        }
    }
}
