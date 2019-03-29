using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

   
    [SerializeField] float spawnSpeed;


    GameManager gm;
    Car2dController carController;
    bool isTurn;
    GameObject whatToSpawn;


    GameObject turnRigthPrefab;
    GameObject roadStraigthPrefab;
    GameObject turnLeftPrefab;


    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        carController = FindObjectOfType<Car2dController>();

       // Invoke("Create", spawnSpeed*carController.GetSpeed() / 10);
        Invoke("Delete", 10);

        foreach (GameObject prefab in gm.GetPrefabs())
        {
            

            if (prefab.tag == "TurnLeft")
                turnLeftPrefab = prefab;


            if (prefab.tag == "TurnRight")
            {
              
                turnRigthPrefab = prefab;
               
            }


            if (prefab.tag == "Straight")
            {
                roadStraigthPrefab = prefab;
         
            }

        }

        Debug.Log(turnRigthPrefab.tag);
    }

    // Update is called once per frame
    void Update()
    {
        

    }


    void Delete()
    {
        Destroy(gameObject);
    }


    void CreateRoadStratigh()
    {
        Instantiate(WhatToSpawn(), gameObject.transform.position + new Vector3(0, -18), gameObject.transform.rotation);
        gm.SetSpawnCount(gm.GetSpawnCount() + 1);
    }

    void CreateTurnRight()
    {

        //if ((gameObject.transform.rotation.z >= 85 && gameObject.transform.rotation.z <= 95) || (gameObject.transform.rotation.z <= -85 && gameObject.transform.rotation.z >= -95))

        if ( gameObject.transform.rotation.z > -95f)
        {
            Instantiate(WhatToSpawn(), gameObject.transform.position + new Vector3(3.4f, -10f), new Quaternion(
                                    gameObject.transform.rotation.x,
                                    gameObject.transform.rotation.y,
                                    gameObject.transform.rotation.zw,
                                    gameObject.transform.rotation.w));


            Debug.Log("Here1");

        }
        else
        {

            Debug.Log("Here2");
            Instantiate(WhatToSpawn(), gameObject.transform.position + new Vector3(13.2f, -1.48f), new Quaternion(
                                         gameObject.transform.rotation.x,
                                         gameObject.transform.rotation.y,
                                         gameObject.transform.rotation.z + 1f,
                                         gameObject.transform.rotation.w));

        }

        gm.SetSpawnCount(gm.GetSpawnCount() + 1);
    }

    void CreateTurnLeft()
    {
        Instantiate(WhatToSpawn(), gameObject.transform.position + new Vector3(-14.7f, -3f), new Quaternion(
                                        gameObject.transform.rotation.x,
                                        gameObject.transform.rotation.y,
                                        gameObject.transform.rotation.z - 1,
                                        gameObject.transform.rotation.w));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Works@@" + gameObject.tag);

        if (gameObject.tag == "TurnRight")
        {
            CreateTurnRight();
        }
        else if(gameObject.tag == "Straight")
        {
            Debug.Log("Works@@");
            CreateRoadStratigh();
        }
        else if (gameObject.tag == "TurnLeft"){

            CreateTurnLeft();
        }

    }

    GameObject WhatToSpawn()
    {


        if (gameObject.tag == "TurnRight")
        {
          
            switch (Random.Range(1, 3))
            {
                case 1:
                    return turnLeftPrefab;
                case 2:
                    return roadStraigthPrefab;

            }
        }
        else if (gameObject.tag == "TurnLeft")
        {
            switch (Random.Range(1, 3))
            {
                case 1:
                    return turnRigthPrefab;

                case 2:
                    return roadStraigthPrefab;

            }
        }
        else if (gameObject.tag == "Straight")
        {
            Debug.Log("Works@@");
            switch (Random.Range(1, 4))
            {
                case 1:
                    return turnRigthPrefab;
                case 2:
                    return roadStraigthPrefab;
                case 3:
                    return turnLeftPrefab;
            }



        }
        






        return null;
    }

   
}
