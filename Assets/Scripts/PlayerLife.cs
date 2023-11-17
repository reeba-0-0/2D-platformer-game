using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rigidbody;

    [SerializeField] AudioSource deathAudio;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            deathAudio.Play();
            rigidbody.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("deathTrigger");

        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
