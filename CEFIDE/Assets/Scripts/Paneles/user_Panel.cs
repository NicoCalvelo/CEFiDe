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

    [SerializeField]
    private GameObject errorBar;

    public GameObject showImage;
    [SerializeField]
    private RectTransform scrollScreen;
    [Header("Divisor")]
    public Text user_name;

    [Header("Barra_Costado")]
    public GameObject barraCostado;

    public void isClient()
    {
        client.SetActive(true);
        noClient.SetActive(false);
        user_name.text = "Bienvenido " + userManager.Instance.newUserInfo.nombre;
        qrcode.generate();
    }
    public void showImg(Texture texture, float w, float h)
    {
        showImage.SetActive(true);
        showImage.GetComponentInChildren<RawImage>().texture = texture;
        showImage.GetComponentInChildren<AspectRatioFitter>().aspectRatio = w / h;
        FindObjectOfType<escapeEvents>().setBools("showImage");
    }
    public void activarBarraCostado()
    {
        FindObjectOfType<escapeEvents>().setBools("barraCostado");
    }
    public void registrarse()
    {
        FindObjectOfType<escapeEvents>().setBools("registrarse");
    }
    public void ingresar()
    {
        FindObjectOfType<escapeEvents>().setBools("ingresar");
    }
    public void cambiarUser()
    {
        PlayerPrefs.SetString("userDNI", "");
    }
    public void activarBarraError(string error)
    {
        errorBar.SetActive(true);
        errorBar.GetComponentInChildren<Text>().text = error;
    }
    public void setScrollSize(int size)
    {
        scrollScreen.sizeDelta = new Vector2(0, size);
    }

}
