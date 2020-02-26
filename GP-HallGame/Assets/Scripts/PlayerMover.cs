using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMover : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public GameObject death;

    public int healthValue = 100;

    public Text lifeText;
    public Text endText;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;


    private void Start()
    {
        lifeText.text = "Health: " + healthValue.ToString();
        endText.text = "";
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            healthValue -= 20;
            lifeText.text = "Health: " + healthValue.ToString();
            die();
        }
        if (other.gameObject.CompareTag("Win"))
        {
            other.gameObject.SetActive(false);
            win();
        }
    }
    void die()
    {
        if (healthValue <= 0)
        {
            endText.text = "You lose! Press 'U' for restart!";
            death.SetActive(false);

        }

    }
    void win()
    {
        endText.text = "You Win! Press 'U' for restart!";
        death.SetActive(false);
    }
}