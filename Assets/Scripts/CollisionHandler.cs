using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] float nextLevelDelay = 1.0f;

    Scoreboard scoreBoard;

    void Start()
    {
        scoreBoard = FindObjectOfType<Scoreboard>();
    }
    
    private void OnCollisionEnter(Collision other) {
        StartCrashSequence();
    }

    private void OnTriggerEnter(Collider other) {
        StartCrashSequence();
    }

    private void StartCrashSequence()
    {
        explosionParticles.Play();
        //scoreBoard.CrashInfo(); //for handler
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
        Invoke(nameof(ReloadLevel), nextLevelDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void OnStateExit()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
        scoreBoard.EndScreen();
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
