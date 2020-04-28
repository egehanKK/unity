using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float speed;
    private bool hasPowerUp = false;

    public GameObject powerUpIndicator;


    private float powerUpStrength = 15.0f;
    private GameObject focalPoint;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");



    }

    // Update is called once per frame
    void Update()
    {
        float verticalInp = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * verticalInp);
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDownRoutine());
            powerUpIndicator.gameObject.SetActive(true);
        }
    }
    IEnumerator PowerUpCountDownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRb = collisionInfo.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collisionInfo.gameObject.transform.position - transform.position);

            Debug.Log("Touched");

            enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }
}
