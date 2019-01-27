using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public GameObject player;
    public GameObject campFire;
    public GameObject torch;
    public Canvas mainMenu;
    public Canvas credits;
    public Button startButton;


    // Start is called before the first frame update
    void Start () {
        player.GetComponent<PlayerController>().enabled = false;
        campFire.GetComponent<FireController>().enabled = false;
        torch.GetComponent<Torch>().enabled = false;
        mainMenu.enabled = true;
        startButton.onClick.AddListener (startClicked);

    }

    void startClicked()
    {
        player.GetComponent<PlayerController>().enabled = true;
        campFire.GetComponent<FireController>().enabled = true;
        torch.GetComponent<Torch>().enabled = true;
        mainMenu.enabled = false;
    }

    private void Update()
    {
        if (player.GetComponent<PlayerController>().isDead)
        {
            credits.enabled = true;
        }
    }
}