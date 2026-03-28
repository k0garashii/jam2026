using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public Transform MeshTransform;
    public InputAction moveAction;
    public InputAction blueShrineAction;
    public InputAction redShrineAction;
    public InputAction screenMapAction;
    public float moveSpeed = 5f;

    private Animator animator;
    private Rigidbody rb;
    private Vector2 move;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        transform.position = new Vector3(-1000, 0.7f, -1000);
        moveAction.Enable();
        blueShrineAction.Enable();
        redShrineAction.Enable();
    }
    
    private void FixedUpdate()
    {
        MovePlayer();
        HandleEndButton();
    }

    void MovePlayer()
    {
        move = moveAction.ReadValue<Vector2>();
        Debug.Log(move);
        Vector3 direction = new Vector3(move.x, 0, move.y);
        rb.linearVelocity = new Vector3(move.x, 0, move.y) * moveSpeed;
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
        if(blueShrineAction.IsPressed())
        {
            if(GameManager.instance.CurrentBiome.biomeType == BiomeType.RedShrine)
                GameManager.instance.Win();
            else if(GameManager.instance.CurrentBiome.biomeType == BiomeType.BlueShrine)
                GameManager.instance.Lose();
        }

        if (redShrineAction.IsPressed())
        {
            if(GameManager.instance.CurrentBiome.biomeType == BiomeType.RedShrine)
                GameManager.instance.Lose();
            else if(GameManager.instance.CurrentBiome.biomeType == BiomeType.BlueShrine)
                GameManager.instance.Win();
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
        if (footstepPlayer)
        {
            footstepPlayer.ResetFootsteps();
        }
    }
    
    public void Deactivate()
    {
        enabled = false;
    }
}
