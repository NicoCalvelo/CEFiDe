using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class homePanel : MonoBehaviour
{

    [Header("Noticias panel")]
    public GameObject content;
    public GameObject noticiaPrefab;
    public GameObject load;

    public GameObject showImage;

    public void showImg(Texture texture, float w, float h)
    {
        showImage.SetActive(true);
        showImage.GetComponentInChildren<RawImage>().texture = texture;
        showImage.GetComponentInChildren<AspectRatioFitter>().aspectRatio = w / h;
    }
}
