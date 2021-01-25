using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spillbeaker : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem myParticleSystemOne;
    public GameObject liquid;
    private Vector3 scaleChange, positionChange;
    public float ys;
    private GameObject otherLiquid;
    private GameObject otherParticle;
    private bool add;
    private bool addMore;
    public Material myMaterial;
    
    void Start()
    {
        scaleChange = new Vector3(0.0f, ys, 0.0f);
        positionChange = new Vector3(0.0f, 0.0f, -ys);
        /*myMaterial = gameObject.GetComponent<ParticleSystemRenderer>().material;*/
        myMaterial = gameObject.GetComponent<MeshRenderer>().material;
        gameObject.GetComponent<ParticleSystemRenderer>().material = myMaterial;
    }

    private void OnParticleCollision(GameObject other)
    {
       // Debug.LogError("check point one " + other.tag + " " + other.layer + " " + other.name);
        if (other.tag == "container")
        {
            myMaterial = gameObject.GetComponent<ParticleSystemRenderer>().material;
           // Debug.LogError("check point two " + other.tag + " " + other.layer + " " + other.name);
            otherLiquid = GameObject.Find(other.name + "Cylinder");
            if (otherLiquid.name != "containerCylinder" || otherLiquid.name != "container2Cylinder" || otherLiquid.name != "containerCCylinder" || otherLiquid.name != "container2CCylinder")
            {
                otherParticle = GameObject.Find(other.name + "Particle");
            }
            
           if (otherLiquid.name == "containerCylinder" || otherLiquid.name == "container2Cylinder")
            {
                addMore = true;
            }
            else {
                add = true;
            }
            
            otherLiquid.GetComponent<MeshRenderer>().material = myMaterial;
            if (otherLiquid.name.Contains("container") == false)
            {
                otherParticle.GetComponent<ParticleSystemRenderer>().material = myMaterial;
            }
            
        }
        else
        {
            add = false;
            addMore = false;
        }

    }



    // Update is called once per frame
    void Update()
    {
        if (add == true)
        {
            otherLiquid.transform.localScale -= scaleChange;
            otherLiquid.transform.localPosition -= positionChange;
        }
        if (addMore == true)
        {
            otherLiquid.transform.localScale -= 8 * scaleChange;
            otherLiquid.transform.localPosition -= 8 * positionChange;
        }
        if (Vector3.Angle(Vector3.down, transform.forward) <= 90f)
        {
            if (liquid.transform.localScale.y < 0.0f)
            {
                myParticleSystemOne.Emit(1);
                liquid.transform.localScale += scaleChange;
                liquid.transform.localPosition += positionChange;

            }
            else
            {
                add = false;
                addMore = false;

            }
        }
        add = false;
        addMore = false;


    }
}
