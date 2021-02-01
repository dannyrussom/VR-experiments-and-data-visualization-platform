using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scale : MonoBehaviour
{
    public GameObject myScaleText;
    private float totalWeight = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        login myloginOne = new login();
        myloginOne.loginStarter();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            totalWeight += other.GetComponent<Rigidbody>().mass;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            totalWeight -= other.GetComponent<Rigidbody>().mass;
        }
    }

    // Update is called once per frame
    void Update()
    {
        myScaleText.GetComponent<TMPro.TextMeshProUGUI>().text = totalWeight.ToString();
    }
}
