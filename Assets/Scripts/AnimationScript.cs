////////////////////////////
/// By: Riley mitchell
/// Date: 11/12/2020
/// Desription: animator script that moves through the frames chosen in the editor at a chosen pase
///////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{   
    [Tooltip("List of sprites in the animation.")]
    public Sprite[] list;
    [Tooltip("Transition speed of the animation.")]
    public float speed = 0.05f;
    int size;
    float timer = 0f;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // getting length of list to move through and assinging spite renderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        size = list.Length;
    }

    // Update is called once per frame
    void Update()
    {
        // moving through list based on timer
        spriteRenderer.sprite = list[Mathf.FloorToInt((timer / speed) % size)];
        timer += Time.deltaTime;
        
    }
}
