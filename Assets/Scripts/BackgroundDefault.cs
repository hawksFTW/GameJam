using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundDefault : MonoBehaviour
{

    public int sortOrder;

    // Use this for initialization
    void Start()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mr.sortingLayerName = "Default";
        mr.sortingOrder = sortOrder;
    }


}
