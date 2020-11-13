////////////////////////////
/// By: Gavin C
/// Date: 11/4/2020
/// Desription: This is a script to go on a object with a trigger collider, changes scene when player touch, remember to add scenes to build
///////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollide : MonoBehaviour
{   
    [Tooltip("Name of the scene you want this script to load")]
    public string SceneName;
    [Tooltip("Time before it changes scene.")]
    public int Time = 1;
    [Tooltip("Unity events that happen as soon as the player collides.")]
    public UnityEvent OnCollide;

    //on collide start coroutine & invoke events if collider is player
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Transform>().tag == "Player")
        {
            OnCollide.Invoke();
            StartCoroutine(ChangeScene());
        }
    }

    //enumerator change scene after some amount of time
    IEnumerator ChangeScene()
    {
        yield return (new WaitForSeconds(Time));
        SceneManager.LoadScene(SceneName);
    }
}
