using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class noticia : MonoBehaviour
{
    public Text seccion, titulo, copete, cuerpo;
    public GameObject rawImage;


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
        homePanel home = GameObject.Find("Home_Panel").GetComponent<homePanel>();
        home.showImg(texture.texture, texture.texture.width, texture.texture.height);
    }
    public void showText()
    {
        userManager.Instance.leerTexto.SetActive(true);
        userManager.Instance.leerTexto.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = titulo.text;
        userManager.Instance.leerTexto.transform.GetChild(0).transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = cuerpo.text;
    }
}
