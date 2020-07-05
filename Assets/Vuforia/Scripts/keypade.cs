using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System;
using System.Net;
using System.IO;

public class keypade : MonoBehaviour, IVirtualButtonEventHandler
{
    string pass = "101010";
    string html = string.Empty;
    string url;
    public GameObject btn0, btn1, submit,clr;
    public TextMesh tm;
    public string str = "";
    void Start()
    {
        //btn0 = GameObject.Find("VirtualButtonclr");
        //btn1 = GameObject.Find("VirtualButtonsubmit");
        //submit = GameObject.Find("VirtualButtonsubmit");
        //clr = GameObject.Find("VirtualButtonclr");
        //btn0.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        //btn1.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        //submit.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        //clr.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        //tm = (TextMesh)GameObject.Find("Text").GetComponent<TextMesh>();
    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        /*switch (vb.VirtualButtonName)
        {
            case "clr":
                str = str.Remove(str.Length - 1);
                break;
            case "VirtualButton0":
                str = str + "0";
                break;
            case "VirtualButton1":
                str = str + "1";
                break;
            case "VirtualButton2":
                str = str + "2";
                break;
            case "submit":
                if (string.Equals(pass,str))
                {
                    url = @"https://us-central1-obscure-lock.cloudfunctions.net/API/openLocker?id=1&u_id=kk";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.AutomaticDecompression = DecompressionMethods.GZip;

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        html = reader.ReadToEnd();
                    }
                }
                break;
        }*/
        Debug.Log("ENTERED......" + vb.VirtualButtonName);
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        //tm.text = str;
    }
}
