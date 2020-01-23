using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using UnityAndroidOpenUrl;

public class display : MonoBehaviour
{
    public byte[] s;
    FileStream file;
     void Start()
    {

    }
    public void onClickShow()
    {
        //Application.OpenURL(Application.persistentDataPath + name + ".pdf");
         string dataType = "application/pdf";
         string documentUrl = Application.persistentDataPath + name + ".pdf";
         AndroidOpenUrl.OpenFile(documentUrl, dataType); 
    }
    public void setDisplay()
    {
        BinaryFormatter bf = new BinaryFormatter();
        string filePath = Application.persistentDataPath + name + ".pdf";
        file = File.Create(filePath);
        bf.Serialize(file, s);       
        file.Close();
        Debug.Log("created");
    }
}
