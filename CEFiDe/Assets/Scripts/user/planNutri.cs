using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class planNutri : MonoBehaviour
{

    public userManager user_manag;
    public GameObject display;
    [SerializeField]
    private RectTransform scrollScreen;

    void OnEnable()
    {
        if(user_manag.newUserEvaluaciones.planNutricional != null)
        {
            Texture2D reconstructedImage = new Texture2D(1, 1);
            reconstructedImage.LoadImage(userManager.Instance.newUserEvaluaciones.planNutricional);
            Texture image = reconstructedImage as Texture;
            display.transform.GetChild(3).GetComponentInChildren<Text>().text = "Plan nutricional";
            display.transform.GetChild(1).GetComponentInChildren<RawImage>().texture = image;
            float w = image.width;
            float h = image.height;
            display.transform.GetChild(1).GetComponentInChildren<AspectRatioFitter>().aspectRatio = w / h;
            scrollScreen.sizeDelta = new Vector2(0, 640);
        }
    }

}
