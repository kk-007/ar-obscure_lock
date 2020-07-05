using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Net;
using System.IO;
using System.Net.Http;

public class LoginController : MonoBehaviour
{
    public GameObject email;
    public GameObject password;
    public GameObject login;

    public Button btnLogin;

    private string Email;
    private string Password;
    string locker_id = "1";
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        btnLogin = login.GetComponent<Button>();
        btnLogin.onClick.AddListener(validateLogin);
    }

    // Update is called once per frame
    void Update()
    {
        Email = email.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
    }
    private void validateLogin()
    {
        string url = "https://us-central1-obscure-lock.cloudfunctions.net/API/logInCheck?id=" + locker_id + "&uid=" + Email + "&upass=" + Password;
        Boolean flag = Boolean.Parse(callAPI(url));
        /*if (Email.Equals("test") && Password.Equals("test"))
        {
            SceneManager.LoadScene("LockScreen");
        }*/
        if (flag)
        {
            SceneManager.LoadScene("LockScreen");
        }
    }
    public string callAPI(string url)
    {
        string res = string.Empty;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.AutomaticDecompression = DecompressionMethods.GZip;

        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            res = reader.ReadToEnd();
        }
        return res;
    }
}
