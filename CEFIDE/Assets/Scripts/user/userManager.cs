using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
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
    public List<noticiaContent> noticias;
    public homePanel home_Panel;

    [Header("Paneles")]
    public GameObject registrarse_Panel;
    public GameObject userPanel;
    public GameObject leerTexto;

    [Header("Info_Panle")]
    public byte[] horarios;

    [Header("Ingresar_Panel")]
    public InputField dni;
    public InputField tresCaracteres;


    private void Awake()
    {
        _instance = this;
    }

    public void Start()       
    {
        AWSManager.Instance.buscarNoticias();
        if (PlayerPrefs.GetString("userDNI") != "")
        {
            AWSManager.Instance.getList(PlayerPrefs.GetString("userDNI"));
        }
    }

    public void setNoticias()
    {
        home_Panel.load.SetActive(false);
        foreach (noticiaContent n in noticias)
        {
            Vector3 nPos = new Vector3(0, 0 - (673 * noticias.IndexOf(n)), 0);
            GameObject newNoticia = Instantiate(home_Panel.noticiaPrefab, Vector3.zero, Quaternion.identity, home_Panel.content.transform);
            newNoticia.GetComponent<RectTransform>().localPosition = nPos;
            Texture2D reconstructedImage = new Texture2D(1, 1);
            reconstructedImage.LoadImage(n.image);
            Texture image = reconstructedImage as Texture;
            newNoticia.GetComponent<noticia>().setNoticia(n.seccion, n.titulo, n.copete, n.cuerpo, image, image.width, image.height);
        }
        home_Panel.content.GetComponent<RectTransform>().sizeDelta = new Vector2(534.7f, 673 * (noticias.FindLastIndex(f => f != null) + 1) + 20);
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
