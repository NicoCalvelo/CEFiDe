using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class userManager : MonoBehaviour
{

    private static userManager _instance;
    public static userManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("The UI Manager is NULL");
            }

            return _instance;
        }
    }

    public AWSManager aWSManager;
    public userInfo newUserInfo;
    public userEvaluaciones newUserEvaluaciones;

    [Header("Paneles")]
    public GameObject registrarse_Panel;
    public GameObject userPanel;

    [Header("Ingresar_Panel")]
    public InputField dni;
    public InputField tresCaracteres;


    private void Awake()
    {
        _instance = this;
    }

    public void Start()       
    {
        if (PlayerPrefs.GetString("userDNI") != "")
        {
            AWSManager.Instance.getList(PlayerPrefs.GetString("userDNI"));
        }
        else
        {
            Debug.Log("userDNI is empty");
            userPanel.GetComponentInChildren<GameObject>().SetActive(true);
        }
    }



    public void createNewUser()
    {
        newUserInfo = new userInfo();
        registrarse_Panel.gameObject.SetActive(true);
    }
    
    public void ingresar()
    {
        if (string.IsNullOrEmpty(dni.text) || string.IsNullOrEmpty(tresCaracteres.text))
        {
            userPanel.GetComponent<user_Panel>().activarBarraError("Es necesario llenar todos los espacios");
        }
        else
        {
            aWSManager.ingresar(dni.text, tresCaracteres.text);
        }

    }

    public void submitUser()
    {
        userInfo awsUser = new userInfo();
        awsUser.nombre = newUserInfo.nombre;
        awsUser.apellido = newUserInfo.apellido;
        awsUser.mail = newUserInfo.mail;
        awsUser.DNI = newUserInfo.DNI;
        awsUser.tresCaracteres = newUserInfo.tresCaracteres;
        awsUser.fraseRecuerdo = newUserInfo.fraseRecuerdo;

        PlayerPrefs.SetString("userDNI", awsUser.DNI);

        
        BinaryFormatter bf = new BinaryFormatter();
        string filePath = Application.persistentDataPath + "/user" + awsUser.DNI + ".dat";
        FileStream file = File.Create(filePath);
        bf.Serialize(file, awsUser);
        file.Close();

        Debug.Log(Application.persistentDataPath);

        AWSManager.Instance.uploadToS3(filePath, awsUser.DNI);
    }
}
