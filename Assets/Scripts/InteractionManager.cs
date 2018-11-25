using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    CameraShake cameraShake;
    State state;
    PrefabManager prefabManager;

    void Start() {
        cameraShake = FindObjectOfType<CameraShake>();
        state = FindObjectOfType<State>();
        prefabManager = FindObjectOfType<PrefabManager>();
    }

    public void OnBulletHit(GameObject interactGO) {
        string type = interactGO.tag;
        switch(type) {
            case "Asteroid":
                AsteroidInteract(interactGO);
                break;
            default: 
                Destroy(interactGO);
                break;
        }
    }

    public void OnInteract(GameObject interactGO)
    {
        string type = interactGO.tag;
        switch (type)
        {
        case "Asteroid":
            state.DamagePlayer();
            // play player dmg animation
            AsteroidInteract(interactGO);
            break;
        case "HealthPickup":
            HealthPickupInteract(interactGO);
            break;
        case "BulletPickup":
            BulletPickupInteract(interactGO);
            break;
        default:
            Debug.Log("unknown interaction of type: " + type);
            break;
        }
    }

    void AsteroidInteract(GameObject asteroidGO)
    {
        asteroidGO.GetComponent<Enemy>().Damage();
    }

    void HealthPickupInteract(GameObject pickupGO)
    {
        Destroy(pickupGO);
    }

    void BulletPickupInteract(GameObject pickupGO)
    {
        state.UpGameSpeed();
        // replace with actual amount
        state.weaponManager.AddBullets(50);
        Destroy(pickupGO);
    }
}
