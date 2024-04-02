using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitFX;
    [SerializeField] int scorePerHit = 20;
    [SerializeField] int hitPoints = 4;

    Scoreboard scoreBoard;
    Rigidbody rigidBody;
    GameObject parentGameObject;

    void Start()
    {
        scoreBoard = FindObjectOfType<Scoreboard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidbody();
    }

    private void AddRigidbody()
    {
        rigidBody = gameObject.AddComponent<Rigidbody>();
        rigidBody.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints < 1) KillEnemy();
    }

    private void KillEnemy()
    {
        scoreBoard.IncreaseScore(scorePerHit);
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        Vector3 destructionPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 4);
        GameObject vfx = Instantiate(hitFX, destructionPosition, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        hitPoints--;
    }
}
