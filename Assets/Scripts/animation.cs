﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
////////////////////////////
/// By: Riley mitchell
/// Date: 11/12/2020
/// Desription: animator script that moves through the frames chosen in the editor at a chosen pase
///////////////////////////
public class animation : MonoBehaviour
{
    public Sprite[] list;
    public float speed = 0;
    int size;
    public float timer = 0f;
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