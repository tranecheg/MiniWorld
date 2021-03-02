using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Animator anim;
	private Rigidbody rb;
    private AudioSource audio;
    public AudioSource audioJump;
    public float speed = 600.0f, jumpForce = 450f, turnSpeed = 400.0f;
	private float moveDirection;
    

		void Start () {
        rb = GetComponent<Rigidbody>();
        anim = gameObject.GetComponentInChildren<Animator>();
        audio = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (!PlayerHealth.death)
        {
            if (Input.GetKey("w"))
            {
                anim.SetInteger("AnimationPar", 1);
                if(!audio.isPlaying)
                    audio.Play();
            }

            else
            {
                anim.SetInteger("AnimationPar", 0);
                if (audio.isPlaying)
                    audio.Pause();
            }
                
            if (rb.velocity.y == 0)
                anim.SetBool("isJump", false);

            if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
            {
                rb.AddForce(Vector3.up * jumpForce);
                anim.SetTrigger("Jumping");
                anim.SetBool("isJump", true);
                audioJump.Play();
            }


            moveDirection = Input.GetAxis("Vertical") * speed * Time.deltaTime;

            rb.MovePosition(transform.position + transform.forward * moveDirection);


            float turn = Input.GetAxis("Horizontal");
            transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);

        }
    }
}
