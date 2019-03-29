using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    public Transform spawnPos;

    void Start()
    {
       
      

        Invoke("Delete", 10);
    }

    void Delete()
    {
        Destroy(gameObject);
    }
}
