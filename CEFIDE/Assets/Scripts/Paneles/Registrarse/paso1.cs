using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class paso1 : MonoBehaviour
{
    public InputField nombre;
    public InputField apellido;

    public Registrarse registrarse;


    public void procesarInfo()
    {
        if(string.IsNullOrEmpty(nombre.text) || string.IsNullOrEmpty(apellido.text))
        {
            Debug.Log("LLename los espacios querido");
        }
        else
        {
            userManager.Instance.newUserInfo.nombre = nombre.text + " " + apellido.text;
            registrarse.onClickPaso2();
        }
    }
}
