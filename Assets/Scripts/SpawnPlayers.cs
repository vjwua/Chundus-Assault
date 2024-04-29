using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject shipPrefab;
    [SerializeField] public Animation animation;
    [SerializeField] private AnimationClip animationToAdd;

    //public Vector3 firstShipPosition = new Vector3(147f, 75f, 110);
    //public Vector3 secondShipPosition = new Vector3(157f, 75f, 110);

    private void Start()
    {
        Vector3 randomPosition = new Vector3(Random.Range(140f, 160f), 75f, 110f);
        animation = shipPrefab.GetComponent<Animation>();
        PhotonNetwork.Instantiate(shipPrefab.name, randomPosition, Quaternion.identity);
    }
}
