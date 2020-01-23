using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class planNutri : MonoBehaviour
{

    public userManager user_manag;
    public GameObject display, textNo;
    [SerializeField]
    private RectTransform scrollScreen;

    void OnEnable()
    {
        if(user_manag.newUserEvaluaciones.planNutricional.Length > 1)
        {
            display.transform.GetChild(0).GetComponentInChildren<Text>().text = "Plan nutricional";
            display.GetComponent<display>().s = userManager.Instance.newUserEvaluaciones.planNutricional;
            display.GetComponent<display>().setDisplay();
            scrollScreen.sizeDelta = new Vector2(0, 640);
            textNo.SetActive(false);
        }
        else 
        {
            display.SetActive(false);
            textNo.SetActive(true);
        }
    }

}
