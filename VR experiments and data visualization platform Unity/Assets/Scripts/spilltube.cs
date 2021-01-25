using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spilltube : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem myParticleSystemOne1;
    //public GameObject liquid1;
    private Vector3 scaleChange1, positionChange1, balloonscaleChange1, balloonpositionChange1;
    public float ys1;
    private GameObject otherLiquid1, otherLiquid2;
    private bool add1;
    public bool methaneCheck, ammoniaCheck;
    public GameObject triggerOne, triggerTwo;
    public GameObject knob;
    public GameObject airBalloon;
    public ParticleSystem bubbleOne, bubbleTwo;
    public GameObject containerOne, ContainerTwo;
    public Material water;

    void Start()
    {
        scaleChange1 = new Vector3(0.0f, ys1, 0.0f);
        positionChange1 = new Vector3(0.0f, 0.0f, -ys1);
        balloonscaleChange1 = new Vector3(ys1, ys1, ys1);
        balloonpositionChange1 = new Vector3(0.0f, 0.0f, -ys1);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "container")
        {
            //Debug.LogError("it's a liquiddddddddddddddddddddddddddddddddddddddddddddddddddddddddd");
            add1 = true;
            otherLiquid1 = GameObject.Find(other.name + "Cylinder");
        }
     }
    
    // Update is called once per frame
    void Update()
    {
        if (knob.GetComponent<HingeJoint>().angle > 0)
        {
            Debug.LogError("methane  " + methaneCheck + "  ammonia  " + ammoniaCheck);
            if (methaneCheck == true && ammoniaCheck == true)
            {
                Debug.Log("methane  " + methaneCheck + "  ammonia  " + ammoniaCheck);
                if (add1 == true)
                {
                    otherLiquid1.transform.localScale -= scaleChange1;
                    otherLiquid1.transform.localPosition -= positionChange1;
                }
                
                if (airBalloon.transform.localScale.y > 0.4f)
                {
                    bubbleOne.Emit(1);
                    bubbleTwo.Emit(1);
                    myParticleSystemOne1.Emit(1);
                    airBalloon.transform.localScale -= 1500 * balloonscaleChange1;
                    airBalloon.transform.localPosition += 23 * balloonpositionChange1;
                }
                else
                {
                    containerOne.GetComponent<Renderer>().material = water;
                    ContainerTwo.GetComponent<Renderer>().material = water;
                }
            }
        }
            add1 = false;
        
    }
}
