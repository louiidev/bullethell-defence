using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    Dictionary<string, GameObject> Prefabs = new Dictionary<string, GameObject>();

    GameObject LoadPrefab(string prefabToLoad) {
        return Resources.Load("Prefabs/" + prefabToLoad) as GameObject;
    }

    public GameObject GetPrefab(string prefabToGet) {
        if (!Prefabs.ContainsKey(prefabToGet)) {
            Prefabs.Add(prefabToGet, LoadPrefab(prefabToGet));
            if (!Prefabs.ContainsKey(prefabToGet)) {
                Debug.Log("Cant get prefab of type: " + prefabToGet);
            }
        }
        return Prefabs[prefabToGet];
    }

    // Start is called before the first frame update
    void Start()
    {

    }
}
