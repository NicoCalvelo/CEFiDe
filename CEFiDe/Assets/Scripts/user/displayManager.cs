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
        if (newUserEvaluaciones.resultadosEvaluacion.Length > 1)
        {
            Vector3 displayPos = new Vector3(0, 0 - pos, 0);
            GameObject newDisplay = Instantiate(displayPrefab, Vector3.zero, Quaternion.identity, gameObject.transform);
            newDisplay.GetComponent<RectTransform>().localPosition = displayPos;
            newDisplay.name = "Resultados Evaluaciones";
            newDisplay.transform.GetChild(0).GetComponentInChildren<Text>().text = newDisplay.name;
            newDisplay.GetComponent<display>().s = newUserEvaluaciones.resultadosEvaluacion;
            newDisplay.GetComponent<display>().setDisplay();
            scrollScreen.sizeDelta += new Vector2(0, 100);
            pos += 100;
        }
        if (newUserEvaluaciones.gimnasio.Length > 1)
        {
            Vector3 displayPos = new Vector3(0, 0 - pos, 0);
            GameObject newDisplay = Instantiate(displayPrefab, Vector3.zero, Quaternion.identity, gameObject.transform);
            newDisplay.GetComponent<RectTransform>().localPosition = displayPos;
            newDisplay.name = "Planilla Gimnasio";
            newDisplay.transform.GetChild(0).GetComponentInChildren<Text>().text = newDisplay.name;
            newDisplay.GetComponent<display>().s = newUserEvaluaciones.gimnasio;
            newDisplay.GetComponent<display>().setDisplay();
            scrollScreen.sizeDelta += new Vector2(0, 100);
            pos += 100;
        }
        if (newUserEvaluaciones.aerobico.Length > 1)
        {
            Vector3 displayPos = new Vector3(0, 0 - pos, 0);
            GameObject newDisplay = Instantiate(displayPrefab, Vector3.zero, Quaternion.identity, gameObject.transform);
            newDisplay.GetComponent<RectTransform>().localPosition = displayPos;
            newDisplay.name = "Planilla Aerobico";
            newDisplay.transform.GetChild(0).GetComponentInChildren<Text>().text = newDisplay.name;
            newDisplay.GetComponent<display>().s = newUserEvaluaciones.aerobico;
            newDisplay.GetComponent<display>().setDisplay();
            scrollScreen.sizeDelta += new Vector2(0, 100);
            pos += 100;
        }
        if (newUserEvaluaciones.flexibilidad.Length > 1)
        {
            Vector3 displayPos = new Vector3(0, 0 - pos, 0);
            GameObject newDisplay = Instantiate(displayPrefab, Vector3.zero, Quaternion.identity, gameObject.transform);
            newDisplay.GetComponent<RectTransform>().localPosition = displayPos;
            newDisplay.name = "Planilla Flexibilidad";
            newDisplay.transform.GetChild(0).GetComponentInChildren<Text>().text = newDisplay.name;
            newDisplay.GetComponent<display>().s = newUserEvaluaciones.flexibilidad;
            newDisplay.GetComponent<display>().setDisplay();
            scrollScreen.sizeDelta += new Vector2(0, 100);
            pos += 100;
        }
        if (newUserEvaluaciones.velocidad.Length > 1)
        {
            Vector3 displayPos = new Vector3(0, 0 - pos, 0);
            GameObject newDisplay = Instantiate(displayPrefab, Vector3.zero, Quaternion.identity, gameObject.transform);
            newDisplay.GetComponent<RectTransform>().localPosition = displayPos;
            newDisplay.name = "Planilla Velocidad";
            newDisplay.transform.GetChild(0).GetComponentInChildren<Text>().text = newDisplay.name;
            newDisplay.GetComponent<display>().s = newUserEvaluaciones.velocidad;
            newDisplay.GetComponent<display>().setDisplay();
            scrollScreen.sizeDelta += new Vector2(0, 100);
        }
    }
}
