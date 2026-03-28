using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    public Button readyButton;
    public Image backgroundImage;
    public GameObject mapParent;

    private RectTransform rectTransform;
    private float currentTime = 0f;
    private bool isBigMap = true;

    void OnEnable()
    {
        rectTransform = mapParent.GetComponent<RectTransform>();
        EventSystem.current.SetSelectedGameObject(readyButton.gameObject);
    }

    public void UpdateMapView()
    {
        if(isBigMap)
            SetMiniMapParameters();
        else
            SetBigMapParameters();
        isBigMap = !isBigMap;
    }
    private void SetBigMapParameters()
    {
        rectTransform.position = new Vector3(960, 540, 0);
        rectTransform.localScale = new Vector3(1, 1, 1);
        backgroundImage.color = new Color(255, 255, 255, 0.4f);
    }    
    private void SetMiniMapParameters()
    {
        rectTransform.position = new Vector3(200, 850, 0);
        rectTransform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        backgroundImage.color = new Color(255, 255, 255, 0f);
    }

    public void LaunchGame()
    {
        UpdateMapView();
        GameManager.instance.Play();
        readyButton.gameObject.SetActive(false);
    }
}
