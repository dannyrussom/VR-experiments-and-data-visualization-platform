using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class signup : MonoBehaviour 
{
    public TMPro.TMP_Dropdown questionsList;
    public TMPro.TMP_Dropdown professorsList;
    public TMPro.TMP_InputField selectedfield2;
    private string signupoccupation;
    public GameObject username2;
    public GameObject password2;
    public GameObject answer;
    public Canvas signupCanvas;
    public Canvas loginCanvas;
    public GameObject ErrorMessage2;
    public GameObject ErrorMessage3;
    public GameObject ErrorMessage4;

    void Start()
    {

    }


    public void SignUpStarter()
    {
        ErrorMessage2.gameObject.SetActive(false);
        ErrorMessage3.gameObject.SetActive(false);
        ErrorMessage4.gameObject.SetActive(false);
        if (username2.GetComponent<TMPro.TextMeshProUGUI>().text.Length <= 1)
        {
            ErrorMessage2.gameObject.SetActive(true);
            ErrorMessage2.GetComponent<TMPro.TextMeshProUGUI>().text = "username can't be empty!";
        }
        if (password2.GetComponent<TMPro.TextMeshProUGUI>().text.Length <= 1)
        {
            ErrorMessage3.gameObject.SetActive(true);
            ErrorMessage3.GetComponent<TMPro.TextMeshProUGUI>().text = "password can't be empty!";
        }
        if (answer.GetComponent<TMPro.TextMeshProUGUI>().text.Length <= 1)
        {
            ErrorMessage4.gameObject.SetActive(true);
            ErrorMessage4.GetComponent<TMPro.TextMeshProUGUI>().text = "reset answer can't be empty!";
        }
        if(username2.GetComponent<TMPro.TextMeshProUGUI>().text.Length > 1 && password2.GetComponent<TMPro.TextMeshProUGUI>().text.Length > 1 && answer.GetComponent<TMPro.TextMeshProUGUI>().text.Length > 1)
        {
            if (signupoccupation == "Student")
            {
                StartCoroutine(studentSignup(username2.GetComponent<TMPro.TextMeshProUGUI>().text.ToString(),
                      password2.GetComponent<TMPro.TextMeshProUGUI>().text.ToString(),
                      professorsList.options[professorsList.value].text,
                      questionsList.options[questionsList.value].text,
                      answer.GetComponent<TMPro.TextMeshProUGUI>().text.ToString()));


                /*Debug.LogError(username2.GetComponent<TMPro.TextMeshProUGUI>().text.ToString() + "  "
                    + password2.GetComponent<TMPro.TextMeshProUGUI>().text.ToString()+ "  " 
                    + professorsList.options[professorsList.value].text + " "
                    + questionsList.options[questionsList.value].text + "  "
                    + answer.GetComponent<TMPro.TextMeshProUGUI>().text.ToString());*/

            }
            else if (signupoccupation == "professor")
            {
                /*Debug.LogError(username2.GetComponent<TMPro.TextMeshProUGUI>().text.ToString() + "  "
                    + password2.GetComponent<TMPro.TextMeshProUGUI>().text.ToString() + "  "
                    + questionsList.options[questionsList.value].text + "  "
                    + answer.GetComponent<TMPro.TextMeshProUGUI>().text.ToString());*/

                StartCoroutine(professorSignup(username2.GetComponent<TMPro.TextMeshProUGUI>().text.ToString(),
                      password2.GetComponent<TMPro.TextMeshProUGUI>().text.ToString(),
                      questionsList.options[questionsList.value].text,
                      answer.GetComponent<TMPro.TextMeshProUGUI>().text.ToString()));
            }
            else
            {
                Debug.LogError("occupation didn't match");
                Debug.Log(signupoccupation);
            }
        }
    }

    public void prepareSignUpPage()
    {
        login loginscript = gameObject.GetComponent<login>();
        Debug.LogError(loginscript.occupation);
        signupoccupation = loginscript.occupation;
        if (loginscript.occupation == "Student")
        {
            professorsList.gameObject.SetActive(true);
            StartCoroutine(GetAllProfessors());
            StartCoroutine(GetAllQuestions());
        }
        if (loginscript.occupation == "professor")
        {
            professorsList.gameObject.SetActive(false);
            StartCoroutine(GetAllQuestions());
        }
    }

    IEnumerator studentSignup(string name, string password, string professor, string question, string answer)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("password", password);
        form.AddField("professor", professor);
        form.AddField("question", question);
        form.AddField("answer", answer);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/check/studentsignup.php", form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("error");
            }
            else
            {
                Debug.Log("successfully signed up");
               // signupCanvas.gameObject.SetActive(false);
                //loginCanvas.gameObject.SetActive(true);
            }
        }
    }
    IEnumerator professorSignup(string name, string password, string question, string answer)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("password", password);
        form.AddField("question", question);
        form.AddField("answer", answer);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/check/professorsignup.php", form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("error");
            }
            else
            {
                Debug.Log("successfully signed up");
                // signupCanvas.gameObject.SetActive(false);
                //loginCanvas.gameObject.SetActive(true);
            }
        }
    }

    IEnumerator GetAllQuestions()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/check/getallquestions.php"))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("error");
            }
            else
            {
                //Debug.LogError(www.downloadHandler.text);
                string[] questions = www.downloadHandler.text.Split('/');
                questionsList.options.Clear();
                foreach (var question in questions)
                {
                    questionsList.options.Add(new TMPro.TMP_Dropdown.OptionData() { text = $"{question}" });
                }
            }
        }
    }

    IEnumerator GetAllProfessors()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/check/getallprofessors.php"))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("error");
            }
            else
            {
                //Debug.LogError(www.downloadHandler.text);
                string[] professors = www.downloadHandler.text.Split('/');
                professorsList.options.Clear();
                foreach (var professor in professors)
                {
                    professorsList.options.Add(new TMPro.TMP_Dropdown.OptionData() { text = $"{professor}" });
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
