using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public GameObject player;
    public Canvas mainMenu;
    public Button startButton;

    // Start is called before the first frame update
    void Start () {
        player.GetComponent<PlayerController>().enabled = false;
        mainMenu.enabled = true;
        startButton.onClick.AddListener (startClicked);

    }

    void startClicked()
    {
        player.GetComponent<PlayerController>().enabled = true;
        mainMenu.enabled = false;
    }
}