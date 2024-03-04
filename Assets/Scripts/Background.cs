using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Transform player;

    public float backgroundX;

    public float backgroundY;

    Vector3 playerPos;

    private void Start()
    {
        playerPos=player.position;
    }

    private void Update()
    {
        float playerX = player.position.x-playerPos.x;
        float playerY = player.position.y - playerPos.y;

        transform.position+=new Vector3(playerX*backgroundX,playerY*backgroundY,0);

        playerPos = player.position;


    }
}
