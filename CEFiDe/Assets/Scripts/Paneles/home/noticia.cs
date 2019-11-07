using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class noticia : MonoBehaviour
{
    public Text seccion, titulo, copete, cuerpo;
    public RawImage logo;
    public GameObject rawImage;
    private homePanel home;

    private void Start()
    {
        home = GameObject.Find("Home_Panel").GetComponent<homePanel>();
        if (seccion.text == "CEFiDe")
        {
            logo.texture = home.logos[0];
        }
        if (seccion.text == "Nutrición")
        {
            logo.texture = home.logos[1];
        }
        if (seccion.text == "Gimnasio")
        {
            logo.texture = home.logos[2];
        }
        if (seccion.text == "Kinesiología")
        {
            logo.texture = home.logos[3];
        }
        if (seccion.text == "Spa")
        {
            logo.texture = home.logos[4];
        }
        if (seccion.text == "Fitness")
        {
            logo.texture = home.logos[5];
        }
        if (seccion.text == "Escalada")
        {
            logo.texture = home.logos[6];
        }
    }
    public void setNoticia(string secc, string tit, string cope, string cuerp, Texture img, float w, float h)
    {
        seccion.text = secc;
        titulo.text = tit;
        copete.text = cope;
        cuerpo.text = cuerp;
        rawImage.GetComponent<RawImage>().texture = img;
        rawImage.GetComponent<AspectRatioFitter>().aspectRatio = w / h;
    }
    public void onClickShow(RawImage texture)
    {
        home.showImg(texture.texture, texture.texture.width, texture.texture.height);
    }
    public void showText()
    {
        userManager.Instance.leerTexto.SetActive(true);
        userManager.Instance.leerTexto.GetComponent<leerTexto>().titulo.text = titulo.text;
        userManager.Instance.leerTexto.GetComponent<leerTexto>().cuerpo.text = cuerpo.text;
    }
}
