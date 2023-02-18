using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private GameController gameController;
    public float speed = 100;
    private Rigidbody rb;
    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float horAxis = Input.GetAxis("Horizontal");
        float verAxis = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horAxis, 0.0f, verAxis);
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
        gameController.playerPos.text = transform.position.ToString();
        gameController.playerVelocity.text = rb.velocity.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            gameController.count++;
            gameController.SetCountText();
            gameController.pickUps.Remove(other.gameObject);
        }
    }

}
