//By: Dhruv 
//Date: 10/22/2020
//Desc: A function to spawn on command

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummoningFunc : MonoBehaviour
{
    public GameObject[] ObjectstoSpawn;
    //This function will spawn in all the objects set to spawn. Needs to be public so Unity Events can use it
    public void Spawn()
    {
        for (int i = 0; i < ObjectstoSpawn.Length; ++i)
        {
            Instantiate(ObjectstoSpawn[i], transform.position, Quaternion.identity);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
