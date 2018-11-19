using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class EnemyManager : MonoBehaviour {
    JSONNode enemyJson;

    void Start()
    {
        TextAsset json = Resources.Load("json/enemies") as TextAsset;
        enemyJson = JSON.Parse(json.text);
    }

}
