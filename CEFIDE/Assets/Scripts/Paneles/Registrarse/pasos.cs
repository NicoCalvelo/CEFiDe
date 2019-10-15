using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pasos : MonoBehaviour
{
    [SerializeField]
    private Text errorText;
    [SerializeField]
    private GameObject errorBar;

    public Registrarse registrarse;
    public userManager userManager;
    public GameObject panelDeCarga;

    [Header("Paso 1")]
    public InputField nombre;
    public InputField apellido;

    [Header("Paso 2")]
    public InputField mail;

    [Header("Paso 3")]
    public InputField DNI;
    public InputField dosDigitos;
    public InputField fraseRecuerdo;


    public void procesarInfo1()
    {
        if (string.IsNullOrEmpty(nombre.text) || string.IsNullOrEmpty(apellido.text))
        {
            errorBar.SetActive(true);
            errorText.text = "Todos los espacios deben ser rellenados";
        }
        else
        {
            userManager.Instance.newUserInfo.nombre = nombre.text;
            userManager.Instance.newUserInfo.apellido = apellido.text;
            registrarse.onClickPaso2();
        }
    }
    public void procesarInfo2()
    {
        if (string.IsNullOrEmpty(mail.text))
        {
            errorBar.SetActive(true);
            errorText.text = "Todos los espacios deben ser rellenados";
        }
        else
        {
            userManager.Instance.newUserInfo.mail = mail.text;
            registrarse.onClickPaso3();
        }
    }
    public void procesarInfo3()
    {
        if (string.IsNullOrEmpty(DNI.text) || string.IsNullOrEmpty(dosDigitos.text))
        {
            errorBar.SetActive(true);
            errorText.text = "Todos los espacios deben ser rellenados";
        }
        else
        {
            userManager.Instance.newUserInfo.DNI = DNI.text;
            userManager.Instance.newUserInfo.tresCaracteres = dosDigitos.text;
            userManager.Instance.newUserInfo.fraseRecuerdo = fraseRecuerdo.text;
            panelDeCarga.SetActive(true);
            userManager.submitUser();
        }
    } 
}
