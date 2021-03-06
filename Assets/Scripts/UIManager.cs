using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour

{
    public static UIManager instance;

    public GameObject startMenu;
    public InputField usernameField;
    public InputField ipField;

    public GameObject colourUI;
    public GameObject hostMenu;
    public GameObject lobbyUI;
    public GameObject mainUI;
    public GameObject meetingScreen;
    public GameObject roleScreen;
    public TMP_Text roleText;
    public TMP_Text ejectText;

    public bool inMeeting = false;

    // Singleton Implementation
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }

        colourUI.SetActive(false);
    }

    /// <summary>Attempts to connect to the server.</summary>
    public void ConnectToServer()
    {
        Client.instance.ip = ipField.text;
        startMenu.SetActive(false);
        usernameField.interactable = false;
        colourUI.SetActive(true);
        Client.instance.ConnectToServer();
    }

    public void SelectColour(int colourID) 
    {
        ClientSend.PlayerSelectedColour(colourID);
        UIManager.instance.colourUI.SetActive(false);
    }

    public void SetLocalIP() 
    {
        ipField.text = "127.0.0.1";
    }

    public void ShowRole(string _role)
    {
        roleScreen.SetActive(true);
        if (_role == "Impostor")
        {
            roleText.text = "Impostor";
            roleScreen.GetComponent<Animator>().SetTrigger("ShowImpostor");
        }

        if (_role == "Crewmate")
        {
            roleText.text = "Crewmate";
            roleScreen.GetComponent<Animator>().SetTrigger("ShowCrewmate");
        }
    }
}