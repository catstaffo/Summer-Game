using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        playerRigidbody.velocity = new Vector2(horizontalMovement, verticalMovement);

        playerAnimator.SetFloat("movementX", playerRigidbody.velocity.x);
        playerAnimator.SetFloat("movementY", playerRigidbody.velocity.y);
    }
}
