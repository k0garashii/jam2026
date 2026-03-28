using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction moveAction;
    public InputAction agreeAction;
    public InputAction disagreeAction;
    public InputAction screenMapAction;
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private Vector2 move;
    void Start()
    {
        transform.position = new Vector3(-1000, 0, -1000);
        moveAction.Enable();
        rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        MovePlayer();
        HandleEndButton();
    }

    void MovePlayer()
    {
        move = moveAction.ReadValue<Vector2>() * moveSpeed;
        transform.Translate(new Vector3(move.x, 0, move.y) * Time.fixedDeltaTime);
    }

    void HandleEndButton()
    {
        if(agreeAction.IsPressed())
        {
            Debug.Log("Agree");
        }

        if (disagreeAction.IsPressed())
        {
            Debug.Log("Disagree");
        }
    }

    public void Activate()
    {
        int randIndex = Random.Range(0, GameManager.instance.chosenBiomes.Count);
        transform.position = GameManager.instance.chosenBiomes[randIndex].transform.position;
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }
}
