using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCollider : MonoBehaviour
{
    [SerializeField] GameObject fx;

    string status;

    Vector3 contact;
    Vector3 normal;

    private void OnCollisionEnter(Collision collision)
    {
        status = "Collision enter: " + collision.gameObject.name;

        contact = collision.GetContact(0).point;
        normal = collision.GetContact(0).normal;

        Instantiate(fx, contact, Quaternion.LookRotation(normal));
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


        Instantiate(fx, transform.position, transform.rotation);
    }

    private void OnTriggerStay(Collider other)
    {
        status = "Trigger stay: " + other.name;
    }

    private void OnTriggerExit(Collider other)
    {
        status = "Trigger exit: " + other.name;
    }

    private void OnGUI()
    {
        GUI.skin.label.fontSize = 16;
        Vector3 screen = Camera.main.WorldToScreenPoint(transform.position);
        GUI.Label(new Rect(screen.x, Screen.height - screen.y, 250, 70), status);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(contact, 0.1f);
        Gizmos.DrawLine(contact, contact + normal);
    }
}
