using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerShip : MonoBehaviour
{
    float rotationSpeed = 100.0f;
    float thrustForce = 3f;

    public AudioClip crash;
    public AudioClip shoot;

    public GameObject bullet;
    public Transform shootPoint;

    private GameManager gameController;

    AudioSource mix;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mix = GameObject.Find("Game Manager").GetComponent<AudioSource>();
        // Get a reference to the game controller object and the script
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        gameController = gameControllerObject.GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);

        rb.AddForce(transform.up * thrustForce * Input.GetAxis("Vertical"));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ShootBullet();
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag != "Bullet")
        {

            mix.clip = crash;
            mix.Play();

            transform.position = new Vector3(0, 0, 0);

            rb.velocity = new Vector3(0, 0, 0);

            gameController.MinusLife();
        }
    }

    void ShootBullet()
    {
        Instantiate(bullet,new Vector3(shootPoint.transform.position.x, shootPoint.transform.position.y, 0),transform.rotation);

        mix.clip = shoot;
        mix.Play();
    }
}
