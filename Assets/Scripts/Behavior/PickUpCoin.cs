using System;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour {

    private PlayerBalance _playerBalance;
    private int _value;

    public static List<string> _deletedItemsNames = new List<string>();

    void Start () {
        _playerBalance = GameObject.FindGameObjectWithTag("Balance").GetComponent<PlayerBalance>();
        _value = new System.Random().Next(1, 11);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _playerBalance.Balance += _value;
        Destroy(gameObject);
    }
}
