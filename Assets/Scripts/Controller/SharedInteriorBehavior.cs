using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SharedInteriorBehavior : MonoBehaviour {

    private bool _displayMessage;
    private string _message = "Leave. (enter)";

    void OnTriggerStay2D(Collider2D collider)
    {
        _displayMessage = true;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _displayMessage = false;
    }

    private void OnGUI()
    {
        if (_displayMessage)
        {
            GUI.Label(new Rect(Screen.width / 2 + 50, Screen.height / 2, 150, 40), _message);
        }
    }
}
