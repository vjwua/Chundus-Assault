using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject shipPrefab;
    PhotonView view;
    [SerializeField] public AnimationClip circularFlyClip;

    private void Start()
    {
        Animation animation = shipPrefab.GetComponent<Animation>();
        if (animation == null)
        {
            animation = shipPrefab.AddComponent<Animation>();
        }

        Vector3 randomPosition = new Vector3(Random.Range(140f, 160f), 75f, 110f);
        PhotonNetwork.Instantiate(shipPrefab.name, randomPosition, Quaternion.identity);
        
        animation.AddClip(circularFlyClip, "Circular Animation");
    }
}
