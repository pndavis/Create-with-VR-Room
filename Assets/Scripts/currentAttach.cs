using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class currentAttach : MonoBehaviour
{
    XRSocketInteractor socket;
    public IXRSelectInteractable socketValue;
    public GameObject Record;
    public int test = 0;

    // Start is called before the first frame update
    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    // Update is called once per frame
    void Update()
    {

        if (socket.hasSelection)
        {
            socketValue = socket.GetOldestInteractableSelected();
            Record = socketValue.transform.gameObject;
            Record.GetComponent<AudioSource>().Play(); 
        }
        else
        {
            //Record.GetComponent<AudioSource>().Stop();
        }

        


    }
}
