using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;

public class display : MonoBehaviour
{
    public byte[] s;
    FileStream file;
     void Start()
    {

    }
    public void onClickShow()
    {
        Application.OpenURL(Application.persistentDataPath + name + ".pdf");
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
