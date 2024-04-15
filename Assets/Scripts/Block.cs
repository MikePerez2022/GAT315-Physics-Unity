using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Block : MonoBehaviour
{
    [SerializeField] int points = 100;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource audioSourcePoints;
    [SerializeField] TMP_Text ScoreUI;
    [SerializeField] IntVariable score;

    Rigidbody rb;
    bool destroyed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(rb.velocity.magnitude > 2 || rb.angularVelocity.magnitude > 2)
        {
            audioSource.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(!destroyed && other.CompareTag("Kill") && rb.velocity.magnitude == 0 && rb.angularVelocity.magnitude == 0)
        {
            destroyed = true;
            audioSourcePoints.Play();
            score.value += points;
            ScoreUI.text = "Score: " + score.value;
            Destroy(gameObject, 2);
        }
    }
}
