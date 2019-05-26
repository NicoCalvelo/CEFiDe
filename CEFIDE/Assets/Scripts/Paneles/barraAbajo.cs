using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barraAbajo : MonoBehaviour
{
    [SerializeField]
    private Animator barraAbajo_anim;

    public GameObject socioYes;
    public GameObject socioNo;


    public void onClickHome()
    {
        barraAbajo_anim.SetBool("funciones", false);
        barraAbajo_anim.SetBool("user", false);
        barraAbajo_anim.SetBool("home", true);
    }
    public void onClcikFunciones()
    {
        barraAbajo_anim.SetBool("home", false);
        barraAbajo_anim.SetBool("user", false);
        barraAbajo_anim.SetBool("funciones", true);
    }
    public void onClickUser()
    {


        barraAbajo_anim.SetBool("home", false);
        barraAbajo_anim.SetBool("funciones", false);
        barraAbajo_anim.SetBool("user", true);
    }
}
