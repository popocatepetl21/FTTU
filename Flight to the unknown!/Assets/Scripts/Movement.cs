using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float RocketThrust = 1000f;
    [SerializeField] int RocketRotate = 1; 
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem MainThurst; //Space
    [SerializeField] ParticleSystem RotateThrust1; //A
    [SerializeField] ParticleSystem RotateThrust; //D
        Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessRotate();
        ProcessThrust();
    }
   void ProcessThrust()
   {
       if(Time.timeScale == 1)
        {
            if (Input.GetKey(KeyCode.Space))
            {
            ForceStart();
            }
            else
            {
           
                MainThurst.Stop(); //Particles
                audioSource.Stop();
            }
        }
   }

    public void ForceStart()
    {
        rb.AddRelativeForce(0, RocketThrust * Time.deltaTime, 0);
        if (!audioSource.isPlaying)
        {
            MainThurst.Play(); //Particles
            audioSource.PlayOneShot(mainEngine);
        }
    }

    public void ProcessRotate()
   {
        if (Input.GetKey(KeyCode.D))
            RightMovement();
        else if (Input.GetKey(KeyCode.A))
            LeftMovement();
        else
        {
            RotateThrust.Stop();
            RotateThrust1.Stop();
        }

    }

    public void LeftMovement()
    {
        applyRotation(RocketRotate);
        if (!RotateThrust1.isPlaying)
        {
            RotateThrust1.Play(); //Particles
        }
    }

    public void RightMovement()
    {
        applyRotation(-RocketRotate);
        if (!RotateThrust.isPlaying)
        {
            RotateThrust.Play(); //Particles
        }
    }

    public void applyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true ; // freezing rotation
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false ;
    }
}


