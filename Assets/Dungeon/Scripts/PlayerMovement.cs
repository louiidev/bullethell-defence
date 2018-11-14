using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour {

    PlayerData playerData;
    InteractManager interactManger;

    public Tilemap tilemap;
    public LayerMask interactLayer;

    void Start()
    {
        playerData = FindObjectOfType<State>().playerData;
        interactManger = FindObjectOfType<InteractManager>();
    }

    void Update()
    {
        Move();
    }


    bool CheckIfPlayerCanMove(Vector3 potentialPosToMove) {
        Vector3Int potentialPosToMove_int = new Vector3Int((int)potentialPosToMove.x, (int)potentialPosToMove.y, 0);
        Vector3Int nextPosition = potentialPosToMove_int + playerData.currentTilePos;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, potentialPosToMove, 1f, interactLayer);
        if (hit) {
            interactManger.HandlerInteraction(hit.transform.gameObject);
        }
        return tilemap.GetTile(nextPosition) && !hit;
    }

    void Move()
    {
        Vector3 positionToMove = new Vector3(0, 0);
        if (Input.GetKeyDown(KeyCode.A)) {
            positionToMove = new Vector3(-1, 0);
        } if (Input.GetKeyDown(KeyCode.D)) {
            positionToMove = new Vector3(1, 0);
        } if (Input.GetKeyDown(KeyCode.W)) {
            positionToMove = new Vector3(0, 1);
        } if (Input.GetKeyDown(KeyCode.S)) {
            positionToMove = new Vector3(0, -1);
        }
        if (positionToMove != new Vector3(0, 0)) {
            if (CheckIfPlayerCanMove(positionToMove)) {
                Vector3Int nextPosition = new Vector3Int((int)positionToMove.x, (int)positionToMove.y, 0) + playerData.currentTilePos;
                transform.position += positionToMove;
                playerData.currentTilePos = nextPosition;
            }
        } 


     }
}
