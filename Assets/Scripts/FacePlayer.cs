using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    private Vector3 playerPos;
    private Vector3 npcPos;

    void Update()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        npcPos = gameObject.transform.position;
        Vector3 delta = new Vector3(playerPos.x - npcPos.x, 0.0f, playerPos.z - npcPos.z);
        Quaternion rotation = Quaternion.LookRotation(delta);
        gameObject.transform.rotation = rotation;
    }
}
