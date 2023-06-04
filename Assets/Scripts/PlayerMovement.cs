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

        anim.SetBool("jump", !isGrounded);
    }

    private float CalculateJumpForce(float jumpDuration)
    {
        float normalizedDuration = Mathf.Clamp01(jumpDuration / maxJumpDuration);
        float jumpForce = Mathf.Lerp(minJumpForce, maxJumpForce, normalizedDuration);
        return jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("trigger player");
        if (coll.gameObject.CompareTag("MineObstacle")) {
            Debug.Log(coll.gameObject.tag);
            coll.gameObject.GetComponent<Animator>().Play("Explosion");
        }
        if (coll.gameObject.CompareTag("Coin")) {
            GlobalState.coinCount += 1;
            Destroy(coll.gameObject);
            Debug.Log(GlobalState.coinCount);
        }
    }
}
