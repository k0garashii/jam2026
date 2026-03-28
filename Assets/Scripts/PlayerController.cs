using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Transform MeshTransform;
    public InputAction moveAction;
    public InputAction agreeAction;
    public InputAction disagreeAction;
    public InputAction screenMapAction;
    public float moveSpeed = 5f;

    private Animator animator;
    private Vector2 move;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        transform.position = new Vector3(-1000, 0, -1000);
        moveAction.Enable();
    }
    
    private void FixedUpdate()
    {
        MovePlayer();
        HandleEndButton();
    }

    void MovePlayer()
    {
        
        move = moveAction.ReadValue<Vector2>() * moveSpeed;
        Vector3 direction = new Vector3(move.x, 0, move.y);
        transform.Translate(direction * Time.fixedDeltaTime);
        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            MeshTransform.rotation = Quaternion.Lerp(MeshTransform.rotation, targetRotation, 10f * Time.fixedDeltaTime);
        }
        bool isMoving = move.sqrMagnitude > 0.01f;
        animator.SetBool("isMoving", isMoving);
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
        BiomeHandler startingBiome = GameManager.instance.chosenBiomes[randIndex];
        transform.position = startingBiome.transform.position;
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        GameManager.instance.UpdatePlayerPosition(startingBiome);

        FootstepPlayer footstepPlayer = GetComponent<FootstepPlayer>();
        if (footstepPlayer != null)
        {
            footstepPlayer.ResetFootsteps();
        }
    }
}
