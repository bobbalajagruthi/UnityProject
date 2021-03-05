using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Declaring Variables

    public float speed = 4.0f;
    public float jumpSpeed = 20.0f;
    public bool isOnGround = true;
    public ParticleSystem crateExplosion;


    private Rigidbody playerBallRb;
    private float gravityModifier = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        playerBallRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        float forwardMovement = Input.GetAxis("Vertical");
        float sideMovement = Input.GetAxis("Horizontal");
        playerBallRb.AddForce(Vector3.forward * speed * forwardMovement);
        playerBallRb.AddForce(Vector3.right * speed * sideMovement);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) 
        {
            playerBallRb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Cube"))
        {
            crateExplosion.Play();
        }
    }
}
