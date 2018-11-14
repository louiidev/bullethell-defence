using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject target;
    Vector3 posToMove;
    private void Start()
    {
        posToMove = target.transform.position;
        posToMove.z = -10;
        transform.position = posToMove;
    }

    private void Update()
    {
        posToMove = Vector3.MoveTowards(transform.position, target.transform.position, 0.5f);
        posToMove.z = -10;
        transform.position = posToMove;
    }

}
