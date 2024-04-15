using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class SwitchContoller : MonoBehaviour
{
    [SerializeField] List<GameObject> controllableGameObjects = new List<GameObject>();
    [SerializeField] CinemachineVirtualCamera cm;
    [SerializeField] private int type = 1;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (type)
            {
                case 1:
                    controllableGameObjects[0].SetActive(true);
                    controllableGameObjects[1].SetActive(false);

                    cm.Follow = controllableGameObjects[0].transform;
                    cm.LookAt = controllableGameObjects[0].transform;
                    break;
                case 2:
                    controllableGameObjects[0].SetActive(false);
                    controllableGameObjects[1].SetActive(true);

                    var transRot = controllableGameObjects[1].transform.rotation;

                    controllableGameObjects[1].transform.rotation = (transRot.x != 0 || transRot.y != 0) ? Quaternion.LookRotation(controllableGameObjects[1].transform.forward, Vector3.up) : transRot;


                    cm.Follow = controllableGameObjects[1].transform;
                    cm.LookAt = controllableGameObjects[1].transform;
                    break;
            }
        }
        if (Input.GetKey(KeyCode.R))
        {
            type = (type == 1) ? 2 : 1;
        }
    }

}
