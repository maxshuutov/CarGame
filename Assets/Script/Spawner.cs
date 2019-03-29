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
    Transform spawnPos;


    GameObject turnRigthPrefab;
    GameObject roadStraigthPrefab;
    GameObject turnLeftPrefab;


    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        carController = FindObjectOfType<Car2dController>();



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

    void CreateAtPosition(GameObject prefab)
    {
        Instantiate(prefab, spawnPos.position, spawnPos.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      

        spawnPos = collision.GetComponent<Block>().spawnPos;
        
        if (collision.tag == "Straight")
        {

            Debug.Log(collision.transform.localEulerAngles.z);

            if (collision.transform.localEulerAngles.z  >= 260f && collision.transform.localEulerAngles.z <= 280f)
            {
                Debug.Log("Here1");

                switch (Random.Range(1, 3))
                {
                    case 1:
                        CreateAtPosition(roadStraigthPrefab);
                        break;
                    case 2:
                        CreateAtPosition(turnRigthPrefab);
                        break;
                    default:
                        CreateAtPosition(roadStraigthPrefab);
                        break;
                }

            }
            else if (collision.transform.localEulerAngles.z >= 85f && collision.transform.localEulerAngles.z <= 95f)
            {
                switch (Random.Range(1, 3))
                {
                    case 1:
                        CreateAtPosition(roadStraigthPrefab);
                        break;
                    case 2:
                        CreateAtPosition(turnLeftPrefab);
                        break;
                    default:
                        CreateAtPosition(roadStraigthPrefab);
                        break;
                }
            }
            else
            {


                switch (Random.Range(1, 3))
                {
                    case 1:
                        CreateAtPosition(roadStraigthPrefab);
                        break;
                    case 2:
                        CreateAtPosition(turnLeftPrefab);
                        break;
                    case 3:
                        CreateAtPosition(turnRigthPrefab);
                        break;
                    default:
                        CreateAtPosition(roadStraigthPrefab);
                        break;
                }
            }
        }






        if (collision.tag == "TurnLeft")
        {

          


                switch (Random.Range(1, 3))
            {
                case 1:
                    CreateAtPosition(roadStraigthPrefab);
                    break;
                case 2:
                    CreateAtPosition(turnRigthPrefab);
                    break;
                default:
                    CreateAtPosition(roadStraigthPrefab);
                    break;
            }

        }



        if (collision.tag == "TurnRight")
        {


            switch (Random.Range(1, 3))
            {
                case 1:
                    CreateAtPosition(roadStraigthPrefab);
                    break;
                case 2:
                    CreateAtPosition(turnLeftPrefab);
                    break;
                default:
                    CreateAtPosition(roadStraigthPrefab);
                    break;
            }

        }


    }




}

    