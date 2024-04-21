using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject shipPrefab;
    public Animator animator;
    [SerializeField] private AnimationClip animationToAdd;

    public Vector3 firstShipPosition = new Vector3(147f, 75f, 110);
    public Vector3 secondShipPosition = new Vector3(157f, 75f, 110);

    private void Start()
    {
        animator = shipPrefab.GetComponent<Animator>();
        PhotonNetwork.Instantiate(shipPrefab.name, firstShipPosition, Quaternion.identity);
    }
}
