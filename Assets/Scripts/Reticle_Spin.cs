using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle_Spin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, .555f, 0); //(60*33.3)/(60*60) 33 1/3 is the standard record speed
    }
}
