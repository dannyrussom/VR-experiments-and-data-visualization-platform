using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour
{
    private GameObject otherLiquid3;
    public spilltube mySpillTubeScript;
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "liquid")
        {
            if (other.name == "containerC" || other.name == "container2C")
            {
                otherLiquid3 = GameObject.Find(other.name + "ylinder");
                if (otherLiquid3.GetComponent<MeshRenderer>().material.name.Contains("methane"))
                {
                    mySpillTubeScript.methaneCheck = true;
                    Debug.Log("METHANE CHECKED INNNNNNNNNNNNN");
                 }
                if (otherLiquid3.GetComponent<MeshRenderer>().material.name.Contains("ammonia"))
                {
                    mySpillTubeScript.ammoniaCheck = true;
                    Debug.Log("AMMONIA CHECKED INNNNNNNNNNNNN");
                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "liquid")
        {
            if (other.name == "containerC" || other.name == "container2C")
            {
                otherLiquid3 = GameObject.Find(other.name + "ylinder");
                if (otherLiquid3.GetComponent<MeshRenderer>().material.name.Contains("methane"))
                {
                    mySpillTubeScript.methaneCheck = false;
                    Debug.Log("METHANE CHECKED OUTTTTTTTTTT");
                }
                if (otherLiquid3.GetComponent<MeshRenderer>().material.name.Contains("ammonia"))
                {
                    mySpillTubeScript.ammoniaCheck = false;
                    Debug.Log("AMMONIA CHECKED OUTTTTTTTTTTT");
                }
            }
        }
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
