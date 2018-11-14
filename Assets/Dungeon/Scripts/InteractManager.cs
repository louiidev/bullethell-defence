using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : MonoBehaviour {

    State state;

    void Start()
    {
        state = FindObjectOfType<State>();
    }

    public void HandlerInteraction(GameObject interactionGO) {

        string type = interactionGO.tag;
        switch(type) {
            case "Item": {
                    PickupItem(interactionGO);
                    break;
               }
            case "Enemy": {
                    state.battleManager.StartBattle(interactionGO);
                    break;
                }
        }
    }

    void PickupItem(GameObject itemGO) {
        itemGO.GetComponent<Chest>().Open();
    }
}
