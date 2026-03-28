using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    public float timer = 20f;
    public Slider slider;

    private GameManager gameManager;
    private float currentTime = 0f;

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timer)
        {
            gameObject.SetActive(false);
            currentTime = 0f;
            GameManager.instance.Play();
            return;
        }
        slider.value = currentTime / timer;
    }
}
