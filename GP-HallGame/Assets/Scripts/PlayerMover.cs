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
    public GameObject gameOverMenu;
    public GameObject winMenu;
    public GameObject pauseMenu;

    public AudioSource musicSource;
    public AudioClip bgMusic;
    public AudioClip winMusic;
    public AudioClip jumpSound;

    public static bool isPaused = false;

    public int healthValue = 100;

    public Text lifeText;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;


    private void Start()
    {
        lifeText.text = "Health: " + healthValue.ToString();
        musicSource.clip = bgMusic;
        musicSource.Play();

    }
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
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
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
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
            gameOverMenu.SetActive(true);
            death.SetActive(false);
            speed = 0f;
            Cursor.lockState = CursorLockMode.None;

        }

    }

    void win()
    {
        winMenu.SetActive(true);
        musicSource.clip = winMusic;
        musicSource.Play();
        death.SetActive(false);
        speed = 0f;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }
}