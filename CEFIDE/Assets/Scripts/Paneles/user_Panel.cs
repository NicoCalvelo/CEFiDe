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

    [Header("PerfilPhoto")]
    public RawImage photoTaken;
    public GameObject newPhotoButon;

    [Header("Divisor")]
    public Text user_name;

    public void isClient()
    {
        client.SetActive(true);
        noClient.SetActive(false);
        user_name.text = "Bienvenido " + userManager.Instance.newUserInfo.nombre;
        qrcode.generate();
    }


    public void takePhotoButon()
    {
        TakePicture(512);
    }

    private void TakePicture(int maxSize)
    {
        NativeCamera.Permission permission = NativeCamera.TakePicture((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                // Create a Texture2D from the captured image
                Texture2D texture = NativeCamera.LoadImageAtPath(path, maxSize);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }

                photoTaken.texture = texture;
                newPhotoButon.SetActive(false);
            }
        }, maxSize);

        Debug.Log("Permission result: " + permission);
    }
}
