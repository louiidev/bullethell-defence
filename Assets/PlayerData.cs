using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int health = 4;
    public int attack = 1;
    public bool alive = true;
    Vector3 currentPosition = new Vector3(0, 0);
    public Vector3Int currentTilePos = new Vector3Int(0, 0, 0);

    public void ApplyDamage(int incomingDmg)
    {
        if (health <= 0) {
            alive = false;
        } else {
            health -= incomingDmg;
        }
    }

}
