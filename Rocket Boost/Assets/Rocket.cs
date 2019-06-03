using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    Rigidbody rigidBody;
    AudioSource audioSource;

    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        Thrust();
        Rotate();
    }

    private void Rotate()
    {
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        rigidBody.freezeRotation = true;

        if (Input.GetKey(KeyCode.A))
        {


            transform.Rotate(Vector3.forward * rotationThisFrame);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotationThisFrame);
        }

        rigidBody.freezeRotation = false;
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * mainThrust);

            if (!audioSource.isPlaying)
            {

                audioSource.Play();
            }


        }
        else
        {

            audioSource.Stop();
        }
    }
}
