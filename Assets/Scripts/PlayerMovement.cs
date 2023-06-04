    using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float minJumpForce;
    [SerializeField] private float maxJumpForce;
    [SerializeField] private float maxJumpDuration;
    private Rigidbody2D body;
    private Animator anim;
    private bool isGrounded;
    private bool isJumping;
    private float jumpStartTime;
    private bool availableForSecondJump = true;
    
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
                jumpStartTime = Time.time;
            }
            else if (Input.GetKeyUp(KeyCode.Space) && isJumping)
            {
                float jumpDuration = Time.time - jumpStartTime;
                float jumpForce = CalculateJumpForce(jumpDuration);
                body.velocity = new Vector2(body.velocity.x, jumpForce);
                isJumping = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && availableForSecondJump)
        {
            body.velocity = Vector2.up * 10;
            availableForSecondJump = false;
        }

        anim.SetBool("brace", isJumping);
        anim.SetBool("jump", !isGrounded);
    }

    private float CalculateJumpForce(float jumpDuration)
    {
        float normalizedDuration = Mathf.Clamp01(jumpDuration / maxJumpDuration);
        float jumpForce = Mathf.Lerp(minJumpForce, maxJumpForce, normalizedDuration);
        return jumpForce * 1.5f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
             availableForSecondJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        Debug.Log("trigger player");
        if (trigger.gameObject.CompareTag("MineObstacle")) {
            Debug.Log(trigger.gameObject.tag);
            trigger.gameObject.GetComponent<Animator>().Play("Explosion");
            gameObject.GetComponent<Animator>().Play("Dead");
            Destroy(gameObject, 1);
            GlobalState.GameOver();
            return;
        }
        if (trigger.gameObject.CompareTag("Coin")) {
            GlobalState.coinCount += 1;
            Destroy(trigger.gameObject);
            Debug.Log(GlobalState.coinCount);
        }
    }
}
