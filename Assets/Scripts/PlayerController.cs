using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
