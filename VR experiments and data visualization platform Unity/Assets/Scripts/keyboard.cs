using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboard : MonoBehaviour
{
    public TMPro.TMP_InputField selectedfield;
    private bool capslock;
    public GameObject capslocksign;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void typer(string character)
    {
        if (character.Contains("space"))
        {
            selectedfield.text += " ";
        }
        else
        {
            if (capslock == true)
            {
                selectedfield.text += character.ToUpper();
            }
            else if (capslock == false)
            {
                selectedfield.text += character;
            }
        }

    }
    public void back()
    {
        selectedfield.text = selectedfield.text.Remove(selectedfield.text.Length - 1, 1);
    }
    public void shift()
    {
        if (capslock == false)
        {
            capslock = true;
            capslocksign.GetComponent<TMPro.TextMeshProUGUI>().color = Color.red;
        }
        else if (capslock == true)
        {
            capslock = false;
            capslocksign.GetComponent<TMPro.TextMeshProUGUI>().color = Color.white;
        }
    }
    public void enter()
    {
        //SignUpStarter();
    }

    public void setSelected(TMPro.TMP_InputField selectedf)
    {
        selectedfield = selectedf;
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
