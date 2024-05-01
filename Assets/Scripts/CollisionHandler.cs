using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] float nextLevelDelay = 1.0f;

    Scoreboard scoreBoard;
    [SerializeField] PhotonView view;

    void Start()
    {
        //scoreBoard = FindObjectOfType<Scoreboard>();
        //view = GetComponent<PhotonView>();
    }
    
    private void OnCollisionEnter(Collision other) {
        if (view.IsMine)
        {
            StartCrashSequence();
        }
        else { return; }
    }

    private void OnTriggerEnter(Collider other) {
        if (view.IsMine)
        {
            StartCrashSequence();
        }
        else { return; }
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
