using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class user_Panel : MonoBehaviour
{
    [SerializeField]
    private GameObject client, noClient;

    [Header("Divisor")]
    public Text user_name;
    public void isClient()
    {
        client.SetActive(true);
        noClient.SetActive(false);
    }
}
