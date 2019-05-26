using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Registrarse : MonoBehaviour
{
    [SerializeField]
    private Animator regisAnim;


    public void onClickPaso2()
     {
        regisAnim.SetBool("backPaso2", false);
        regisAnim.SetBool("paso2", true);
     }
    public void onClickPaso3()
    {
        regisAnim.SetBool("backPaso3", false);
        regisAnim.SetBool("paso2", false);
        regisAnim.SetBool("paso3", true);
    }
    public void onClickPaso4()
    {
        regisAnim.SetBool("backPaso4", false);
        regisAnim.SetBool("paso3", false);
        regisAnim.SetBool("paso4", true);
    }

    public void onClickBackPaso2()
    {
        regisAnim.SetBool("paso2", false);
        regisAnim.SetBool("backPaso3", false);
        regisAnim.SetBool("backPaso2", true);
    }
    public void onClcikBackPaso3()
    {
        regisAnim.SetBool("paso3", false);
        regisAnim.SetBool("backPaso3", true);
    }
    public void onClickBackPaso4()
    {
        regisAnim.SetBool("paso4", false);
        regisAnim.SetBool("backPaso4", true);
    }
}
