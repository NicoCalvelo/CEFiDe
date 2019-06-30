using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ingresar : MonoBehaviour
{
    [SerializeField]
    private GameObject loadPanel;
    [SerializeField]
    private InputField mail, contraseña;

    [SerializeField]
    private Text errorText;
    [SerializeField]
    private GameObject errorBar;

    public void onClickLogIn()
    {
        loadPanel.SetActive(true);

        AWSManager.Instance.getList(mail.text, false);
    }

    public void succesfulyLogedIn()
    {
        //fijarme si hay algun archivo con el nombre del mail
        //if not desactivar el panel de carga y mostrar cartel de que no se ha encontrado el usuario
        //descargar la contraseña de ese archivo
        //fijarme si las contraseñas coinciden
        //de no ser asi desactivar el panel de carga y mostrar que las contraseñas no coinciden
        //de ser asi guardar datos necesarios en archivo binario
        //reiniciar la escena y ejecutar el awake method de user Manager
    }
    public void errorLogIn()
    {
        errorBar.SetActive(true);
        errorText.text = "No se ha encontrado el usuario";
    }

}
