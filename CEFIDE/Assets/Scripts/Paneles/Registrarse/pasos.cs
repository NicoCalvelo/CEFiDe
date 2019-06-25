using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pasos : MonoBehaviour
{

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
            registrarse.onClickPaso4();
        }
    } 
    public void procesarInfo4()
    {
        if (string.IsNullOrEmpty(contraseña.text) || string.IsNullOrEmpty(repetirContra.text))
        {
            Debug.Log("LLename los espacios querido");
        }
        else if (contraseña.text != repetirContra.text)
        {
            Debug.Log("Las contras no coinciden querido");
        }
        else
        {
            userManager.Instance.newUserInfo.contraseña = contraseña.text;
            panelDeCarga.SetActive(true);
            userManager.checkMail();
        }
    }
    public void userAlreadyExist(string userMail)
    {

    } 

}
