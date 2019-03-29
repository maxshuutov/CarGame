using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    CarControlFunctions carControl;
    MobileControl mobCon;
    GameManager gm;


    void Start()
    {
        mobCon = GetComponent<MobileControl>();
        gm = FindObjectOfType<GameManager>();
        carControl = GetComponent<CarControlFunctions>();
    }

    // Update is called once per frame

    private void Update()
    {


        if (mobCon.swipeDown || Input.GetKeyDown(KeyCode.R))
            gm.Restart();
    }



    void FixedUpdate()
    {





        if (Input.GetKey(KeyCode.A))
            carControl.Turn(Input.GetAxis("Horizontal"));
        else if (Input.GetKey(KeyCode.D))
            carControl.Turn(Input.GetAxis("Horizontal"));


      //  carControl.Move();
    }
}
