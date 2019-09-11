using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homePanel : MonoBehaviour
{
    [SerializeField]
    private Animator anim_homePanel;
    public userManager user;

    public void onClickNoticias()
    {
        anim_homePanel.SetBool("onClickNoticias", true);
    }
    public void onClcikNovedades()
    {
        anim_homePanel.SetBool("onClickNoticias", false);
    }
}
