using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCollider : MonoBehaviour
{
    string status;

    private void OnCollisionEnter(Collision collision)
    {
        status = "Collision enter: " + collision.gameObject.name;
    }

    private void OnCollisionStay(Collision collision)
    {
        status = "Collision Stay: " + collision.gameObject.name;
    }

    private void OnCollisionExit(Collision collision)
    {
        status = "Collision exit: " + collision.gameObject.name;
    }

    private void OnTriggerEnter(Collider other)
    {
        status = "Trigger enter: " + other.name;
    }

    private void OnTriggerStay(Collider other)
    {
        status = "Trigger stay: " + other.name;
    }

    private void OnTriggerExit(Collider other)
    {
        status = "Trigger enter: " + other.name;
    }

    private void OnGUI()
    {
        GUI.skin.label.fontSize = 16;
        Vector3 screen = Camera.main.WorldToScreenPoint(transform.position);
        GUI.Label(new Rect(screen.x, Screen.height - screen.y, 250, 70), status);
    }
}
