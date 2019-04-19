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
    public void onClcikPaso3()
    {
        regisAnim.SetBool("backPaso3", false);
        regisAnim.SetBool("paso2", false);
        regisAnim.SetBool("paso3", true);
    }
    public void onClcikBackPaso3()
    {
        regisAnim.SetBool("paso3", false);
        regisAnim.SetBool("backPaso3", true);
    }
    public void onClickBackPaso2()
    {
        regisAnim.SetBool("paso2", false);
        regisAnim.SetBool("backPaso3", false);
        regisAnim.SetBool("backPaso2", true);
    }
}
