using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravelScript : MonoBehaviour
{

    public Vector3 offset = Vector3.zero;


    private bool Pressed = false;

    private bool Present = true;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Fire1") > 0)
        {
            if(Pressed == false)
            {
                Pressed = true;
                if(Present == true)
                {
                    transform.position += offset;
                    Present = false;
                }
                else if(Present == false)
                {
                    transform.position -= offset;
                    Present = true;
                }
                Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
                
            }
        }
        else
        {
            Pressed = false;
        }
    }
}