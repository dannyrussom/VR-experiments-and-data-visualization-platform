using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class login : MonoBehaviour
{
    public int userid;
    public string occupation;
    public GameObject username1;
    public GameObject password1;
    public Canvas loginCanvas;
    public Canvas experimentCanvas;
    public GameObject ErrorMessage;
    public TMPro.TMP_InputField usersnameInputField;
    public TMPro.TMP_InputField passwordInputField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetToProfessor()
    {
        occupation = "professor";
    }

    public void SetToStudent()
    {
        occupation = "Student";
    }

   
    public void loginStarter()
    {
        if (username1.GetComponent<TMPro.TextMeshProUGUI>().text == null)
        {
            ErrorMessage.gameObject.SetActive(true);
            ErrorMessage.GetComponent<TMPro.TextMeshProUGUI>().text = "username can't be empty!";
        }
        else if (password1.GetComponent<TMPro.TextMeshProUGUI>().text == null)
        {
            ErrorMessage.gameObject.SetActive(true);
            ErrorMessage.GetComponent<TMPro.TextMeshProUGUI>().text = "password can't be empty!";
        }
        else
        {
            //ErrorMessage.gameObject.SetActive(false);
            if (occupation == "Student")
            {
                StartCoroutine(studentLogin(username1.GetComponent<TMPro.TextMeshProUGUI>().text.ToString(), password1.GetComponent<TMPro.TextMeshProUGUI>().text.ToString()));
                
            }
            else if (occupation == "professor")
            {
                // StartCoroutine(studentLogin(username1.ToString(), password1.ToString()));
            }
            else
            {
                Debug.LogError("occupation didn't match");
                Debug.Log(occupation);
            }
        }
    }

    IEnumerator studentLogin(string firstname, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("firstname", firstname);
        form.AddField("password", password);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/check/studentlogin.php", form))
        {
            yield return www.SendWebRequest();
            if(www.isNetworkError || www.isHttpError)
            {
                Debug.Log("error");
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Contains("successful"))
                {
                    usersnameInputField.text = "";
                    passwordInputField.text = "";
                    ErrorMessage.gameObject.SetActive(false);
                    loginCanvas.gameObject.SetActive(false);
                    experimentCanvas.gameObject.SetActive(true);
                }
                else
                {
                    usersnameInputField.text = "";
                    passwordInputField.text = "";
                    ErrorMessage.gameObject.SetActive(true);
                    ErrorMessage.GetComponent<TMPro.TextMeshProUGUI>().text = www.downloadHandler.text;
                    Debug.Log("!"+password+"fend");
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
