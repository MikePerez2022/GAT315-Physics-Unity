using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject spawnPrefab;
    [SerializeField] KeyCode key = KeyCode.LeftShift;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(key))
        {
            Instantiate(spawnPrefab,transform.position, transform.rotation);
        }
    }
}
