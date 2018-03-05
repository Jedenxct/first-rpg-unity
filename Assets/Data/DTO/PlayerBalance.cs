using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBalance : MonoBehaviour
{

    private int _balance;

    public int Balance {
        get { return _balance; }
        set { _balance = value; }
    }

    void Start()
    {
        _balance = 0;
    }
}
