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
            display.transform.GetChild(3).GetComponentInChildren<Text>().text = "Plan nutricional";
            display.GetComponent<display>().s = userManager.Instance.newUserEvaluaciones.planNutricional;
            display.GetComponent<display>().setDisplay();
            scrollScreen.sizeDelta = new Vector2(0, 640);
        }
    }

}
