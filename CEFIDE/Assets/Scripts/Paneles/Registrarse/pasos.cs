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

    [Header("Paso 4")]
    public InputField contraseña;
    public InputField repetirContra;


    public void procesarInfo1()
    {
        if (string.IsNullOrEmpty(nombre.text) || string.IsNullOrEmpty(apellido.text))
        {
            Debug.Log("LLename los espacios querido");
        }
        else
        {
            userManager.Instance.newUserInfo.nombre = nombre.text + " " + apellido.text;
            registrarse.onClickPaso2();
        }
    }
    public void procesarInfo2()
    {
        if (string.IsNullOrEmpty(mail.text))
        {
            Debug.Log("LLename los espacios querido");
        }
        else
        {
            userManager.Instance.newUserInfo.mail = mail.text;
            registrarse.onClickPaso3();
        }
    }
    public void procesarInfo3()
    {
        if (string.IsNullOrEmpty(DNI.text))
        {
            Debug.Log("LLename los espacios querido");
        }
        else
        {
            userManager.Instance.newUserInfo.DNI = DNI.text;
            panelDeCarga.SetActive(true);
            userManager.submitUser();
        }
    } 
}
