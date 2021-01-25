using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 scaleChange, positionChange, boilingbublespos;
    public float ys;
    private GameObject otherLiquid;
    private bool add;
    public ParticleSystem boilingbubbles;
    private Vector3 halfSize;
    public Material powdermaterial;
    private float tenpercentLiquidSize;
    public ParticleSystem fireParticle;
    public GameObject knob;



    void Start()
    {
        scaleChange = new Vector3(0.0f, ys, 0.0f);
        positionChange = new Vector3(0.0f, 0.0f, -ys);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "container")
        {
            otherLiquid = GameObject.Find(other.name + "Cylinder");
            tenpercentLiquidSize = otherLiquid.transform.localScale.y * 0.1f;
            add = true;
        }
        else
        {
            add = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (knob.GetComponent<HingeJoint>().angle > 0.0f)
        {
            fireParticle.Emit(1);
        }
       
        if (add == true)
        {
            if (otherLiquid.transform.localScale.y < tenpercentLiquidSize)
            {
                halfSize = new Vector3(0.0f, otherLiquid.transform.localScale.y / 2, 0.0f);
                boilingbubbles.transform.position = otherLiquid.transform.position + halfSize;
                otherLiquid.transform.localScale += 5 * scaleChange;
                otherLiquid.transform.localPosition += 5 * positionChange;
                boilingbubbles.Emit(1);
            }
            else
            {
                Destroy(boilingbubbles);
                otherLiquid.GetComponent<Renderer>().material = powdermaterial;
            }
        }
        add = false;
    }
}

