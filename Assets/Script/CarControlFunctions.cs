using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControlFunctions : MonoBehaviour
{

    Rigidbody car;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float strengthCofficient = 2000f;

    [SerializeField] private float turnMagnitude;




    [SerializeField] Transform motor;

    [SerializeField] Transform wheels;


    Vector3 motorPos;
    Vector3 wheelsPos;
    private void Start()
    {
        motorPos = motor.position;
        wheelsPos = wheels.position;
        car = GetComponent<Rigidbody>();
    }


    public void Turn(float turnMagnigtude)
    {
        // car.transform.Translate(turnMagnigtude * turnSpeed * Time.deltaTime, 0, 0);

        car.AddForce(Vector3.back * turnMagnigtude * Time.deltaTime, ForceMode.Acceleration);
        car.transform.Rotate(Vector3.back, turnMagnigtude * 100 * Time.deltaTime);
    }


    public void Move()
    {


        car.AddRelativeForce(Vector3.down * Time.deltaTime * moveSpeed);
    }
}
