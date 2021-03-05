using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRB;
    Animator playerAnim;
    AudioSource playerAudioSrc;
    public ParticleSystem death_ps;
    public ParticleSystem dirt_ps;
    public AudioClip jump_sfx;
    public AudioClip crash_sfx;

    public float jumpPower = 10;
    public float gravityModifier = -15.0f;

    private bool isOnGround = true;
    private bool canJump = true;
    public bool gameOver { get; protected set; }

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        // get components
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudioSrc = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        // space key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // jump
            Jump();
        }
        // apply gravity mod
        playerRB.AddForce(Vector3.up * gravityModifier, ForceMode.Acceleration);
    }

    // uses impulse force to make the player jump
    void Jump()
    {
        if (!canJump || gameOver) return;
        playerAnim.SetTrigger("Jump_trig");
        // apply jump force
        playerRB.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        playerAudioSrc.PlayOneShot(jump_sfx);
        // if not on ground set can jump to false
        if (isOnGround)
        {
            canJump = true;
            if (dirt_ps != null) dirt_ps.Stop();
        } else
        {
            canJump = false;
            playerAnim.SetTrigger("doubleJump_trig");
        }
        canJump = isOnGround ? true : false;
        isOnGround = false;
    }
    // detect collider collision
    private void OnCollisionEnter(Collision collision)
    {
        if (gameOver) return;
        // if our ground collider
        if (collision.gameObject.CompareTag("Ground"))
        {
            // reset jump params
            isOnGround = true;
            canJump = true;
            if (dirt_ps != null) dirt_ps.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }
    void GameOver()
    {
        if (death_ps != null) death_ps.Play();
        if (dirt_ps != null) dirt_ps.Stop();
        playerAudioSrc.PlayOneShot(crash_sfx);
        gameOver = true;
        playerAnim.SetBool("Death_b", true);
        playerAnim.SetInteger("DeathType_int", 1);
        Debug.LogWarning("GameOver!");
    }
}
