using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class currentAttach : MonoBehaviour
{
    XRSocketInteractor socket;
    IXRSelectInteractable socketValue;
    public GameObject Record = null;
    public GameObject Needle;
    public AudioClip RecordScratch;


    // Start is called before the first frame update
    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
        //PlaceRecord();
    }

    // Update is called once per frame
    public void PlaceRecord()
    {
        socketValue = socket.GetOldestInteractableSelected();
        try
        {
            Record = socketValue.transform.gameObject;
            Record.GetComponent<AudioSource>().Play();
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }

        Needle.transform.rotation = Quaternion.Lerp(Needle.transform.rotation, Quaternion.AngleAxis(44, Vector3.up), 1f);
    }
    public void RemoveRecord()
    {
        Record.GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Needle.transform.rotation = Quaternion.identity; //Resets needle rotation;
    }
}
