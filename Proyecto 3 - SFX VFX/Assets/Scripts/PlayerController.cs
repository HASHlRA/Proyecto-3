using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public bool gameOver;

    public ParticleSystem explosionParticleSystem;
    public ParticleSystem dirtParticleSystem;

    public AudioClip jumpClip;
    public AudioClip crashClip;
    private AudioSource playerAudioSource;
    private AudioSource cameraAudioSource;

    private Rigidbody playerRigidbody;
    private Animator playerAnimator;
    [SerializeField] private float jumpForce = 400f;
    public float gravityModifier = 1;
    private bool isOnTheGround = true;
    private int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnTheGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            dirtParticleSystem.Stop();
            playerAudioSource.PlayOneShot(jumpClip, 1);
        }
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (!gameOver)
        {
            if (otherCollider.gameObject.CompareTag("Ground"))
            {
                isOnTheGround = true;
                dirtParticleSystem.Play();
            }

            if (otherCollider.gameObject.CompareTag("Obstacle"))
            {
                Destroy(otherCollider.gameObject);
                playerAnimator.SetTrigger("Crash Trig");
                lives--;
                if (lives <= 0)
                {
                    GameOver();
                }
                else
                {
                    playerAnimator.SetTrigger("Crash Trig");
                }

            }
        }
    }

    private void GameOver()
    {
        gameOver = true;
        dirtParticleSystem.Stop();
        int randomDeath = Random.Range(1, 3);
        playerAnimator.SetBool("Death_b", true);
        playerAnimator.SetInteger("DeathType_int", randomDeath);
        playerAudioSource.PlayOneShot(crashClip, 1);
        cameraAudioSource.volume = 0.01f;

        Vector3 offset = new Vector3(0, 1.5f, 0);

        ParticleSystem explosionEscena = Instantiate(explosionParticleSystem, transform.position + offset,
        explosionParticleSystem.transform.rotation);
        explosionEscena.Play();
    }
    





}
