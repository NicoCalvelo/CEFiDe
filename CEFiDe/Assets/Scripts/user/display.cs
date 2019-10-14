using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class display : MonoBehaviour
{
    private user_Panel userPanel;

    public void onClickShow(RawImage texture)
    {
        userPanel = GameObject.Find("User_Panel").GetComponent<user_Panel>();
        userPanel.showImg(texture.texture, texture.texture.width, texture.texture.height);
    }
}
