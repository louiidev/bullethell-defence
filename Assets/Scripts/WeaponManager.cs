using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager
{

    public int bulletAmount = 1;
    public enum Weapons {
        baseGun,
        highPoweredGun
    }

    struct WeaponInfo {
        public float speed;
        public string name;
    }

    WeaponInfo[] weapons = new WeaponInfo[] {
        new WeaponInfo(),
        new WeaponInfo()
    };

    
    Weapons currentWeapon = Weapons.baseGun;

    public void ChangeWeapon(Weapons newWeapon) {
        if (currentWeapon != newWeapon) {
            // logic to change weapon
            currentWeapon = newWeapon;
        }
    }

    public void AddBullets(int amount) {
        bulletAmount = amount;
    }


    public void MinusBulletAmount() {
        if (currentWeapon != Weapons.baseGun) {
            bulletAmount--;
        }
    }

}
