using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Canvas mainScreen;
    private static GameManager instance;

    void Awake()
    {
        if (!instance)
            instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
