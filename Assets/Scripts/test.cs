using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System;
using System.Net;
using System.IO;
using System.Net.Http;
public class test : MonoBehaviour
{
    string locker_id = "1";
    string user_id = "userTemp";
    Boolean flag;
    string pass;
    string str = "";
    string url;
    public TextMesh tm;
    string btnName;
    void Start()
    {
        tm = (TextMesh)GameObject.Find("Text").GetComponent<TextMesh>();

        /*url = "https://us-central1-obscure-lock.cloudfunctions.net/API/getPass?id="+locker_id;
        pass = callAPI(url);
        url = "https://us-central1-obscure-lock.cloudfunctions.net/API/getFlag?id=" + locker_id;
        flag = Boolean.Parse(callAPI(url));*/
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
            {
                //btnName = Hit.collider.gameObject.name;
                btnName = Hit.transform.name;
                switch (btnName)
                {
                    case "pVirtualButton0":
                        str = str + "0";
                        break;
                    case "pVirtualButton1":
                        str = str + "1";
                        break;
                    case "pVirtualButton2":
                        str = str + "2";
                        break;
                    case "pVirtualButton3":
                        str = str + "3";
                        break;
                    case "pVirtualButton4":
                        str = str + "4";
                        break;
                    case "pVirtualButton5":
                        str = str + "5";
                        break;
                    case "pVirtualButton6":
                        str = str + "6";
                        break;
                    case "pVirtualButton7":
                        str = str + "7";
                        break;
                    case "pVirtualButton8":
                        str = str + "8";
                        break;
                    case "pVirtualButton9":
                        str = str + "9";
                        break;
                    case "pVirtualButton11":
                        if (!string.Equals("", str))
                        {
                            str = str.Remove(str.Length - 1);
                        }
                        break;
                    case "pVirtualButton12":
                        setText("Processing...");
                        url = "https://us-central1-obscure-lock.cloudfunctions.net/API/getPass?id="+locker_id;
                        pass = callAPI(url);
                        url = "https://us-central1-obscure-lock.cloudfunctions.net/API/getFlag?id=" + locker_id;
                        flag = Boolean.Parse(callAPI(url));
                        if (string.Equals(pass, str))
                        {
                            if (flag)
                            {
                                url = @"https://us-central1-obscure-lock.cloudfunctions.net/API/closeLocker?id="+locker_id+"&u_id="+user_id;
                                setText("Unlocked");
                            }
                            else
                            {
                                url = @"https://us-central1-obscure-lock.cloudfunctions.net/API/openLocker?id="+locker_id+"&u_id="+user_id;
                                setText("Locked");
                            }
                            string resLocker = callAPI(url);
                        }
                        else
                        {
                            setText("Wrong Password");
                        }
                        break;
                    default:
                        {
                            Debug.Log("Default Case");
                            break;
                        }
                }
                setText(str);
            }
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
    public void setText(string s)
    {
        tm.text = s;
    }
}
