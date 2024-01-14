
using UnityEngine;

public class BounceScript : MonoBehaviour
{
    
    public Animator anim;
    public float jumpForce = 10f;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = other.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

                if (anim != null)
                {
                    anim.SetBool("IsBouncing", true);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (anim != null)
            {
                anim.SetBool("IsBouncing", false);
            }
        }
    }
}
