using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    private float dirX = 0f;
    [SerializeField]private float moveSpeed = 7f;
    [SerializeField]private float jumpForce = 14f;

    private enum MovementState { andar, correr, saltar, cair}

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimationUpdate();
    }

    private void UpdateAnimationUpdate()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.correr;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.correr;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.andar;
        }

        if(rb.velocity.y > .1f)
        {
            state = MovementState.saltar;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.cair;
        }

        anim.SetInteger("state", (int)state);
    }
}
