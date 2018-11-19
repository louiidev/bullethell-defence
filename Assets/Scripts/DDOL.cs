using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL : MonoBehaviour
{

    private void Awake()
    {
        if (GameObject.Find(gameObject.name) != null && GameObject.Find(gameObject.name).GetInstanceID() != gameObject.GetInstanceID())
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
