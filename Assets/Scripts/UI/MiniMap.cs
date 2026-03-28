using System;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    public Slider slider;
    public Image backgroundImage;
    public GameObject mapParent;
    public float timer = 20f;

    private GameManager gameManager;
    private RectTransform rectTransform;
    private float currentTime = 0f;
    private bool firstDraw;
    private bool isBigMap = false;

    void OnEnable()
    {
        firstDraw = true;
        rectTransform = mapParent.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(firstDraw)
            UpdateMapTimer();
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
    void UpdateMapTimer()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timer)
        {
            firstDraw = false;
            currentTime = 0f;
            slider.value = 0f;
            SetMiniMapParameters();
            GameManager.instance.Play();
            return;
        }
        slider.value = currentTime / timer;
    }
}
