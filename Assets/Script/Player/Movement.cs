using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    private Collider _collider;
    private float maxXValue = 1;
    private bool movePlayer;

    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float forwardSpeed;

    [Header("Partcical System")]
    public ParticleSystem deadEfect;
    public ParticleSystem airEfect;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    void Update()
    {
        MoveController();
    }

    void MoveController()
    {
        if (GameManager.GameManagerInstance.gameState)
        {
            float horizontalInput = Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(horizontalInput * horizontalSpeed * Time.deltaTime, 0f, forwardSpeed * Time.deltaTime);

            transform.position += movement;

            // check if ball is within  limit
            float clampedXPosition = Mathf.Clamp(transform.position.x, -maxXValue, maxXValue);
            transform.position = new Vector3(clampedXPosition, transform.position.y, transform.position.z);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("obstacle"))
        {
            Instantiate(deadEfect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            GameManager.GameManagerInstance.gameState = false;
            GameManager.GameManagerInstance.GameOver();
        }
        if (other.CompareTag("pickable"))
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            Instantiate(deadEfect, transform.position, Quaternion.identity);
            scoreManager.score += scoreManager.scoreAmount;
            Destroy(other.gameObject); // The object to destroy.
        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("path"))
        {
            rb.isKinematic = _collider.isTrigger = false;
            rb.velocity = new Vector3(0f, 8f, 0f);

            var airEfectMain = airEfect.main;
            airEfectMain.simulationSpeed = 10f;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("path"))
        {
            rb.isKinematic = _collider.isTrigger = true;
            forwardSpeed = forwardSpeed + 5;

            var airEfectMain = airEfect.main;
            airEfectMain.simulationSpeed = 5f;
        }
    }


}
