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
        if (seccion.text == "Evaluaciones deportologicas")
        {
            logo.texture = home.logos[5];
        }else if (seccion.text == "Kinesiologia" || seccion.text == "Pilates reformer")
        {
            logo.texture = home.logos[3];
        }else if (seccion.text == "Spa / Estetica corporal" || seccion.text == "Yoga")
        {
            logo.texture = home.logos[4];
        }else if (seccion.text == "Muro de escalada")
        {
            logo.texture = home.logos[6];
        }
        else
        {
            logo.texture = home.logos[0];
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
        FindObjectOfType<escapeEvents>().setBools("showImage");
    }
    public void showText()
    {
        userManager.Instance.leerTexto.SetActive(true);
        userManager.Instance.leerTexto.GetComponent<leerTexto>().titulo.text = titulo.text;
        userManager.Instance.leerTexto.GetComponent<leerTexto>().cuerpo.text = cuerpo.text;
        FindObjectOfType<escapeEvents>().setBools("leerTexto");
    }
}
