using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject player;
    public GameObject campFire;
    public GameObject torch;
    public Canvas mainMenu;
    public Canvas credits;
    public Button startButton;
    public Button returnButton;


    // Start is called before the first frame update
    void Start () {
        player.GetComponent<PlayerController>().enabled = false;
        campFire.GetComponent<FireController>().enabled = false;
        torch.GetComponent<Torch>().enabled = false;
        mainMenu.enabled = true;
        startButton.onClick.AddListener (startClicked);
        returnButton.onClick.AddListener(returnClicked);
        credits.enabled = false;

    }

    void startClicked()
    {
        player.GetComponent<PlayerController>().enabled = true;
        campFire.GetComponent<FireController>().enabled = true;
        torch.GetComponent<Torch>().enabled = true;
        mainMenu.enabled = false;
    }

    void returnClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    private void Update()
    {
        if (player.GetComponent<PlayerController>().isDead)
        {
            Debug.Log("You're dead");
            credits.enabled = true;
        }
    }
}