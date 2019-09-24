using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class user_Panel : MonoBehaviour
{
    [SerializeField]
    private GameObject client, noClient;
    public userManager userManager;
    public QR_Codes qrcode;

    [Header("Divisor")]
    public Text user_name;

    public void isClient()
    {
        client.SetActive(true);
        noClient.SetActive(false);
        user_name.text = "Bienvenido " + userManager.Instance.newUserInfo.nombre;
        qrcode.generate();
    }
}
