using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoPanel : MonoBehaviour
{
    public void openMap()
    {
        Application.OpenURL("http://maps.google.com/maps/place/CEFiDe/@-33.338361,-60.224463,17z/data=!3m1!4b1!4m5!3m4!1s0x95b767854e995313:0xe2a4ac4d1f881202!8m2!3d-33.338361!4d-60.222269");
    }
    public void openInstagram()
    {
        Application.OpenURL("https://www.instagram.com/cefidesannicolas/?hl=es-la");
    }
    public void openFacebook()
    {
        Application.OpenURL("https://www.facebook.com/CefideGim");
    }
}
