﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoPanel : MonoBehaviour
{

    [Header("Horarios")]
    public RawImage planillaHorarios;
    public GameObject showImage;
    [SerializeField]
    private RectTransform imgContent;
    public void Start()
    {
        AWSManager.Instance.buscarHorarios(() =>
        {
            Texture2D reconstructedImage = new Texture2D(1, 1);
            reconstructedImage.LoadImage(userManager.Instance.horarios);
            planillaHorarios.texture = reconstructedImage as Texture;
            float w = planillaHorarios.texture.width;
            float h = planillaHorarios.texture.height;
            planillaHorarios.GetComponent<AspectRatioFitter>().aspectRatio = w / h;
        });
    }
    public void onClickShow(RawImage texture)
    {
        showImg(texture.texture, texture.texture.width, texture.texture.height);
        FindObjectOfType<escapeEvents>().setBools("showImage");
    }
    private void showImg(Texture texture, float w, float h)
    {
        showImage.SetActive(true);
        showImage.GetComponentInChildren<RawImage>().texture = texture;
        showImage.GetComponentInChildren<AspectRatioFitter>().aspectRatio = w / h;
        FindObjectOfType<escapeEvents>().setBools("showImage");
    }
    public void openNH()
    {
        FindObjectOfType<escapeEvents>().setBools("nuestra historia");
    }
    public void openGalery()
    {
        imgContent.anchoredPosition = new Vector2(0,0);
        FindObjectOfType<escapeEvents>().setBools("galery");
    }
    public void openHorarios()
    {
        FindObjectOfType<escapeEvents>().setBools("horarios");
    }
    public void openContactenos()
    {
        FindObjectOfType<escapeEvents>().setBools("contactenos");
    }
    public void openMap()
    {
        Application.OpenURL("https://www.google.com/maps/place/CEFiDe/@-33.338361,-60.224463,17z/data=!3m1!4b1!4m5!3m4!1s0x95b767854e995313:0xe2a4ac4d1f881202!8m2!3d-33.338361!4d-60.222269");
    }
    public void openInstagram()
    {
        Application.OpenURL("https://www.instagram.com/cefide.gimnasio/");
    }
    public void openFacebook()
    {
        Application.OpenURL("https://www.facebook.com/CefideGim");
    }
}
