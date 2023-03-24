using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ColisionLog : MonoBehaviour
{
    DeathManager dm;
    float LevelDelay = 0.8f;
    int MaxLevel = 10;
    [SerializeField] AudioClip FinishSound;
    [SerializeField] AudioClip CrashSound;

    [SerializeField] ParticleSystem FinishParticle;
    [SerializeField] ParticleSystem CrashParticle;

    AudioSource audioSource;

    ParticleSystem ParticleSystem;
    bool IsTransitioning = false;


    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
        ParticleSystem = GetComponent<ParticleSystem>();
        audioSource.volume = 1f;
    }

    private void Awake() 
    {
        dm = GameObject.FindObjectOfType<DeathManager>();
    }
        void OnCollisionEnter(Collision other) 
    {
        if (IsTransitioning) {return;}

        int  CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        switch (other.gameObject.tag)
        {
            case "Friend":
                break;

            case "Finish":
                Finish();
                break;

            case "Untagged":
                Crash();
                break;

        }
    }

    void Crash()
    {
        dm.IncreaseDeaths();
        IsTransitioning = true;
        CrashParticle.Play();
        GetComponent<Movement>().enabled = false;
        audioSource.Stop();
        audioSource.volume = 0.2f;
        audioSource.PlayOneShot(CrashSound);
        Invoke("ReloadLevel", LevelDelay);
    }

    private void ReloadLevel()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex);
    }

    void Finish()
    {
        IsTransitioning = true;
        FinishParticle.Play();
        GetComponent<Movement>().enabled = false;
        audioSource.Stop();
        audioSource.volume = 0.2f;
        audioSource.PlayOneShot(FinishSound);
        Invoke("IfFinish", LevelDelay);
    }
    void IfFinish()
    {
        int  CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        if(CurrentLevel > MaxLevel)
                {
                    
                    CurrentLevel = 0;
                    SceneManager.LoadScene(CurrentLevel);
                }

                else

                {
                    
                    CurrentLevel++;
                    SceneManager.LoadScene(CurrentLevel);
                }
    }

    void Update()
    {
        CheatCodeSkip();
    }
    void CheatCodeSkip()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Finish();
        }
    }

}