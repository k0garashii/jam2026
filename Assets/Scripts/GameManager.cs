using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerController controller;
    public List<Button> mainScreenButtons = new List<Button>();

    public static GameManager instance { get; private set; }
    void Awake()
    {
        if (!instance)
            instance = this;
        EventSystem.current.SetSelectedGameObject(mainScreenButtons[0].gameObject);
    }
    void Start()
    {
        controller.enabled = false;
    }

    public void Play()
    {
        controller.enabled = true;
    }
}
