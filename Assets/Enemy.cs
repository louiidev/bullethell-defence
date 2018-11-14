using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy {

    public int attack;
    public int health;
    public bool alive = true;

    public Enemy(int attack, int health) {
        this.attack = attack;
        this.health = health;
    }

    public void ApplyDamage(int incomingDmg) {
        health -= incomingDmg;
        if (health <= 0) {
            alive = false;
        }
    }

    public Enemy Clone () {
        return new Enemy(attack, health);
    }
}
