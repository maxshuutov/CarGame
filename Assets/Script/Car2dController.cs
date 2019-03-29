using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2dController : MonoBehaviour
{


    Rigidbody2D car;
    [SerializeField] float turnSpeed;
    [SerializeField]Transform wheels;
    [SerializeField] Transform motor;
    [SerializeField] float moveSpeed = 20f;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<GameManager>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            gm.Restart();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        car.AddForceAtPosition(-transform.up * moveSpeed, motor.position);
        car.AddForceAtPosition(-transform.up * moveSpeed, wheels.position);

     
            Turn(Input.GetAxis("Horizontal")); 
        

    }


    void Turn(float turnValue)
    {
        car.AddTorque(turnValue * turnSpeed);
    }

    public float GetSpeed()
    {
        return moveSpeed;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        car.simulated = false;
        Invoke("GG", 1f);
    }

    void GG()
    {
        gm.Restart(); ;
    }



}
