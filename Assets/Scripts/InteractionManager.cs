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

    public void OnInteract(GameObject interactGO)
    {
        string type = interactGO.tag;
        switch (type)
        {
        case "Asteroid":
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
        asteroidGO.GetComponent<Enemy>().TriggerDeath();
    }

    void HealthPickupInteract(GameObject pickupGO)
    {
        Destroy(pickupGO);
    }
    void BulletPickupInteract(GameObject pickupGO)
    {
        state.UpGameSpeed();
        // replace with actual amount
        state.SetBulletAmount(50);
        Destroy(pickupGO);
    }
}
