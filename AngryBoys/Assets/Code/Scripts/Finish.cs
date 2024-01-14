using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    private Animator anim;
    private bool levelCompleted = false;
    [SerializeField] private AudioSource bgMusic;
    
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            DisablePlayerMovement(collision);
            AnimatePlayerFinish(collision);
            bgMusic.Stop();
            finishSound.Play();
            // anim.SetTrigger("finish");
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void DisablePlayerMovement(Collider2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

        if (playerController != null)
        {
            playerController.enabled = false;
        }
    
    }
    private void AnimatePlayerFinish(Collider2D collision)
    {
        Animator playerAnimator = collision.gameObject.GetComponent<Animator>();
        if (playerAnimator != null)
        {
            playerAnimator.SetTrigger("finish"); // Replace 'finish' with the name of your trigger
        }
    }
}
