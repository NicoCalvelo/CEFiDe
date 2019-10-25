using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayManager : MonoBehaviour
{

    [SerializeField]
    private GameObject displayPrefab;
    [SerializeField]
    private RectTransform scrollScreen;
    public userEvaluaciones newUserEvaluaciones;

    public void OnEnable()
    {
        scrollScreen.sizeDelta = new Vector2(0, 211);
        newUserEvaluaciones = userManager.Instance.newUserEvaluaciones;
        int pos = 0;
        if (newUserEvaluaciones.resultadosEvaluacion.Length != 0)
        {
            Texture2D reconstructedImage = new Texture2D(1, 1);
            reconstructedImage.LoadImage(userManager.Instance.newUserEvaluaciones.resultadosEvaluacion);
            Texture image = reconstructedImage as Texture;
            Vector3 displayPos = new Vector3(0, 0 - pos, 0);
            GameObject newDisplay = Instantiate(displayPrefab, Vector3.zero, Quaternion.identity);
            newDisplay.transform.SetParent(gameObject.transform);
            newDisplay.GetComponent<RectTransform>().localPosition = displayPos;
            newDisplay.name = "Resultados Evaluaciones";
            newDisplay.transform.GetChild(3).GetComponentInChildren<Text>().text = newDisplay.name;
            newDisplay.transform.GetChild(1).GetComponentInChildren<RawImage>().texture = image;
            float w = image.width;
            float h = image.height;
            newDisplay.transform.GetChild(1).GetComponentInChildren<AspectRatioFitter>().aspectRatio = w / h;
            scrollScreen.sizeDelta += new Vector2(0, 640);
            pos += 640;
        }
        if (newUserEvaluaciones.gimnasio.Length != 0)
        {
            Texture2D reconstructedImage = new Texture2D(1, 1);
            reconstructedImage.LoadImage(userManager.Instance.newUserEvaluaciones.gimnasio);
            Texture image = reconstructedImage as Texture;
            Vector3 displayPos = new Vector3(0, 0 - pos, 0);
            GameObject newDisplay = Instantiate(displayPrefab, Vector3.zero, Quaternion.identity);
            newDisplay.transform.SetParent(gameObject.transform);
            newDisplay.GetComponent<RectTransform>().localPosition = displayPos;
            newDisplay.name = "Planilla Gimnasio";
            newDisplay.transform.GetChild(3).GetComponentInChildren<Text>().text = newDisplay.name;
            newDisplay.transform.GetChild(1).GetComponentInChildren<RawImage>().texture = image;
            float w = image.width;
            float h = image.height;
            newDisplay.transform.GetChild(1).GetComponentInChildren<AspectRatioFitter>().aspectRatio = w / h;
            scrollScreen.sizeDelta += new Vector2(0, 640);
            pos += 640;
        }
        if (newUserEvaluaciones.aerobico.Length != 0)
        {
            Texture2D reconstructedImage = new Texture2D(1, 1);
            reconstructedImage.LoadImage(userManager.Instance.newUserEvaluaciones.aerobico);
            Texture image = reconstructedImage as Texture;
            Vector3 displayPos = new Vector3(0, 0 - pos, 0);
            GameObject newDisplay = Instantiate(displayPrefab, Vector3.zero, Quaternion.identity);
            newDisplay.transform.SetParent(gameObject.transform);
            newDisplay.GetComponent<RectTransform>().localPosition = displayPos;
            newDisplay.name = "Planilla Aerobico";
            newDisplay.transform.GetChild(3).GetComponentInChildren<Text>().text = newDisplay.name;
            newDisplay.transform.GetChild(1).GetComponentInChildren<RawImage>().texture = image;
            float w = image.width;
            float h = image.height;
            newDisplay.transform.GetChild(1).GetComponentInChildren<AspectRatioFitter>().aspectRatio = w / h;
            scrollScreen.sizeDelta += new Vector2(0, 640);
            pos += 640;
        }
        if (newUserEvaluaciones.flexibilidad.Length != 0)
        {
            Texture2D reconstructedImage = new Texture2D(1, 1);
            reconstructedImage.LoadImage(userManager.Instance.newUserEvaluaciones.flexibilidad);
            Texture image = reconstructedImage as Texture;
            Vector3 displayPos = new Vector3(0, 0 - pos, 0);
            GameObject newDisplay = Instantiate(displayPrefab, Vector3.zero, Quaternion.identity);
            newDisplay.transform.SetParent(gameObject.transform);
            newDisplay.GetComponent<RectTransform>().localPosition = displayPos;
            newDisplay.name = "Planilla Flexibilidad";
            newDisplay.transform.GetChild(3).GetComponentInChildren<Text>().text = newDisplay.name;
            newDisplay.transform.GetChild(1).GetComponentInChildren<RawImage>().texture = image;
            float w = image.width;
            float h = image.height;
            newDisplay.transform.GetChild(1).GetComponentInChildren<AspectRatioFitter>().aspectRatio = w / h;
            scrollScreen.sizeDelta += new Vector2(0, 640);
            pos += 640;
        }
        if (newUserEvaluaciones.velocidad.Length != 0)
        {
            Texture2D reconstructedImage = new Texture2D(1, 1);
            reconstructedImage.LoadImage(userManager.Instance.newUserEvaluaciones.velocidad);
            Texture image = reconstructedImage as Texture;
            Vector3 displayPos = new Vector3(0, 0 - pos, 0);
            GameObject newDisplay = Instantiate(displayPrefab, Vector3.zero, Quaternion.identity);
            newDisplay.transform.SetParent(gameObject.transform);
            newDisplay.GetComponent<RectTransform>().localPosition = displayPos;
            newDisplay.name = "Planilla Velocidad";
            newDisplay.transform.GetChild(3).GetComponentInChildren<Text>().text = newDisplay.name;
            newDisplay.transform.GetChild(1).GetComponentInChildren<RawImage>().texture = image;
            float w = image.width;
            float h = image.height;
            newDisplay.transform.GetChild(1).GetComponentInChildren<AspectRatioFitter>().aspectRatio = w / h;
            scrollScreen.sizeDelta += new Vector2(0, 640);
        }
    }
}
