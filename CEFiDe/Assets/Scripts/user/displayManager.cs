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
    public GameObject load2, textNo;

    public Texture disp1, disp2, disp3, disp4, disp5;

    public void setDisplays()
    {
        scrollScreen.sizeDelta = new Vector2(0, 211);
        newUserEvaluaciones = userManager.Instance.newUserEvaluaciones;
        int pos = 0;
        if (newUserEvaluaciones.resultadosEvaluacion.Length > 1)
        {
            Vector3 displayPos = new Vector3(0, -25 - pos, 0);
            GameObject newDisplay = Instantiate(displayPrefab, Vector3.zero, Quaternion.identity, gameObject.transform);
            newDisplay.GetComponent<RectTransform>().localPosition = displayPos;
            newDisplay.name = "Resultados Evaluaciones";
            newDisplay.transform.GetChild(0).GetComponentInChildren<Text>().text = newDisplay.name;
            newDisplay.GetComponent<RawImage>().texture = disp1;
            newDisplay.GetComponent<display>().s = newUserEvaluaciones.resultadosEvaluacion;
            newDisplay.GetComponent<display>().setDisplay();
            scrollScreen.sizeDelta += new Vector2(0, 205);
            pos += 180;
        }
        if (newUserEvaluaciones.gimnasio.Length > 1)
        {
            Vector3 displayPos = new Vector3(0, -25 - pos, 0);
            GameObject newDisplay = Instantiate(displayPrefab, Vector3.zero, Quaternion.identity, gameObject.transform);
            newDisplay.GetComponent<RectTransform>().localPosition = displayPos;
            newDisplay.name = "Planilla Gimnasio";
            newDisplay.transform.GetChild(0).GetComponentInChildren<Text>().text = newDisplay.name;
            newDisplay.GetComponent<RawImage>().texture = disp2;
            newDisplay.GetComponent<display>().s = newUserEvaluaciones.gimnasio;
            newDisplay.GetComponent<display>().setDisplay();
            scrollScreen.sizeDelta += new Vector2(0, 205);
            pos += 180;
        }
        if (newUserEvaluaciones.aerobico.Length > 1)
        {
            Vector3 displayPos = new Vector3(0, -25 - pos, 0);
            GameObject newDisplay = Instantiate(displayPrefab, Vector3.zero, Quaternion.identity, gameObject.transform);
            newDisplay.GetComponent<RectTransform>().localPosition = displayPos;
            newDisplay.name = "Planilla Aerobico";
            newDisplay.transform.GetChild(0).GetComponentInChildren<Text>().text = newDisplay.name;
            newDisplay.GetComponent<RawImage>().texture = disp3;
            newDisplay.GetComponent<display>().s = newUserEvaluaciones.aerobico;
            newDisplay.GetComponent<display>().setDisplay();
            scrollScreen.sizeDelta += new Vector2(0, 205);
            pos += 180;
        }
        if (newUserEvaluaciones.flexibilidad.Length > 1)
        {
            Vector3 displayPos = new Vector3(0, -25 - pos, 0);
            GameObject newDisplay = Instantiate(displayPrefab, Vector3.zero, Quaternion.identity, gameObject.transform);
            newDisplay.GetComponent<RectTransform>().localPosition = displayPos;
            newDisplay.name = "Planilla Flexibilidad";
            newDisplay.transform.GetChild(0).GetComponentInChildren<Text>().text = newDisplay.name;
            newDisplay.GetComponent<RawImage>().texture = disp4;
            newDisplay.GetComponent<display>().s = newUserEvaluaciones.flexibilidad;
            newDisplay.GetComponent<display>().setDisplay();
            scrollScreen.sizeDelta += new Vector2(0, 205);
            pos += 180;
        }
        if (newUserEvaluaciones.velocidad.Length > 1)
        {
            Vector3 displayPos = new Vector3(0, -25 - pos, 0);
            GameObject newDisplay = Instantiate(displayPrefab, Vector3.zero, Quaternion.identity, gameObject.transform);
            newDisplay.GetComponent<RectTransform>().localPosition = displayPos;
            newDisplay.name = "Planilla Velocidad";
            newDisplay.transform.GetChild(0).GetComponentInChildren<Text>().text = newDisplay.name;
            newDisplay.GetComponent<RawImage>().texture = disp5;
            newDisplay.GetComponent<display>().s = newUserEvaluaciones.velocidad;
            newDisplay.GetComponent<display>().setDisplay();
            scrollScreen.sizeDelta += new Vector2(0, 205);
        }
        load2.SetActive(false);
        textNo.SetActive(false);
    }
}
