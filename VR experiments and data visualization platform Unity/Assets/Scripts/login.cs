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
    public GameObject ErrorMessagep;
    public GameObject ErrorMessageA;
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
        ErrorMessage.gameObject.SetActive(false);
        ErrorMessagep.gameObject.SetActive(false);
        if (username1.GetComponent<TMPro.TextMeshProUGUI>().text.Length <= 1)
        {
            ErrorMessage.gameObject.SetActive(true);
            ErrorMessage.GetComponent<TMPro.TextMeshProUGUI>().text = "username can't be empty!";
        }
        if (password1.GetComponent<TMPro.TextMeshProUGUI>().text.Length <= 1)
        {
            ErrorMessagep.gameObject.SetActive(true);
            ErrorMessagep.GetComponent<TMPro.TextMeshProUGUI>().text = "password can't be empty!";
        }
        if (username1.GetComponent<TMPro.TextMeshProUGUI>().text.Length > 1 && password1.GetComponent<TMPro.TextMeshProUGUI>().text.Length > 1)
        {
            //ErrorMessage.gameObject.SetActive(false);
            if (occupation == "Student")
            {
                StartCoroutine(studentLogin(username1.GetComponent<TMPro.TextMeshProUGUI>().text.ToString(), password1.GetComponent<TMPro.TextMeshProUGUI>().text.ToString()));
                
            }
            else if (occupation == "professor")
            {
                StartCoroutine(professorLogin(username1.GetComponent<TMPro.TextMeshProUGUI>().text.ToString(), password1.GetComponent<TMPro.TextMeshProUGUI>().text.ToString()));
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
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/check/VR-experiments-and-data-visualization-platform-backend/studentlogin.php", form))
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
                    ErrorMessageA.gameObject.SetActive(false);
                    ErrorMessage.gameObject.SetActive(false);
                    ErrorMessagep.gameObject.SetActive(false);
                    loginCanvas.gameObject.SetActive(false);
                    experimentCanvas.gameObject.SetActive(true);
                }
                else
                {
                    usersnameInputField.text = "";
                    passwordInputField.text = "";
                    ErrorMessageA.gameObject.SetActive(true);
                    ErrorMessageA.GetComponent<TMPro.TextMeshProUGUI>().text = www.downloadHandler.text;
                    Debug.Log(password);
                }
            }
        }
    }

    IEnumerator professorLogin(string firstname, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("firstname", firstname);
        form.AddField("password", password);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/check/VR-experiments-and-data-visualization-platform-backend/professorlogin.php", form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
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
                    ErrorMessageA.gameObject.SetActive(false);
                    ErrorMessage.gameObject.SetActive(false);
                    ErrorMessage.gameObject.SetActive(false);
                    loginCanvas.gameObject.SetActive(false);
                    experimentCanvas.gameObject.SetActive(true);
                }
                else
                {
                    usersnameInputField.text = "";
                    passwordInputField.text = "";
                    ErrorMessageA.gameObject.SetActive(true);
                    ErrorMessageA.GetComponent<TMPro.TextMeshProUGUI>().text = www.downloadHandler.text;
                    Debug.Log(password);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
