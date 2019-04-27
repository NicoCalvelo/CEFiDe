using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userManager : MonoBehaviour
{
    private static userManager _instance;
    public static userManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("The UI Manager is NULL");
            }

            return _instance;
        }
    }

    public userInfo newUserInfo;
    public GameObject registrarse_Panel;

    private void Awake()
    {
        _instance = this;
    }

    public void createNewUser()
    {
        newUserInfo = new userInfo();

        registrarse_Panel.gameObject.SetActive(true);
    }
}
