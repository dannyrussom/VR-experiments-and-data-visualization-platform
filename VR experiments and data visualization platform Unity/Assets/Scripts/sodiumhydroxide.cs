using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sodiumhydroxide : MonoBehaviour
{
    public ParticleSystem hydrogenBubbles;
    private bool startReaction = false;
    private GameObject changedToWater;
    public Material myWater;
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "liquid")
        {
            Debug.Log("COLLISION WITH LIQUID DETECTEDDDDDDDDDDDDDDDDDD");
            if (other.GetComponent<Renderer>().material.name.Contains("hydrogen"))
            {
                Debug.Log("HYDROGEN IS INNNNNNNNNNNNNNN");
                startReaction = true;
                changedToWater = other.gameObject;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        if(startReaction == true)
        {
            if(i<500)
            {
                hydrogenBubbles.Emit(10);
                i++;
            }
            else
            {
                startReaction = false;
                Destroy(gameObject);
                Destroy(hydrogenBubbles);
                changedToWater.GetComponent<Renderer>().material = myWater;
            }
        }
    }
}
