﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class user_Panel : MonoBehaviour
{
    [Header("Divisor")]
    public Text user_name;

    private void OnEnable()
    {
        user_name.text = userManager.Instance.newUserInfo.nombre;
    }
}
