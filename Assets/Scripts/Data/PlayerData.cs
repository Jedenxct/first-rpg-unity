using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData playerData;
    private int health;
    private int balance;

    private void Awake()
    {
        if (playerData == null)
        {
            DontDestroyOnLoad(gameObject);
            playerData = this;
        }
        else if (playerData != null)
        {
            Destroy(gameObject);
        }
    }

    private void OnGUI()
    {
        string content = String.Format("Health: {0} \nBalance: {1}", health, balance);
        GUI.Label(new Rect(10, 10, 100, 60), content);
    }
}
