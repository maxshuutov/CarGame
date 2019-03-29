using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{



    int SpawnCount;

    public GameObject[] prefabs;

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetSpawnCount(int value)
    {
        SpawnCount = value;
    }

    public int GetSpawnCount()
    {
        return SpawnCount;
    }

    public GameObject[] GetPrefabs()
    {
        return prefabs;
    }


   


}

