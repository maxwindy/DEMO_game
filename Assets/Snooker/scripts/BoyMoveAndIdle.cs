using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyMoveAndIdle : MonoBehaviour
{
    public enum actionStates
    {
        Walk, Idle
    }

    public actionStates actionType;
    float speed = 6f;
    float rotateSpeed = 2f;
    float minDistance = -15f;
    float maxDistance = 12f;

    public GameObject wayPoint;
    GameObject wp;
    bool wP = true;
    Animator anim;

	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	void Update ()
    {
        CreateWayPoint();
    }

    void CreateWayPoint()
    {
        if (!wP)
        {
            float distanceX = transform.position.x + Random.Range(minDistance, maxDistance);
            //float distanceZ = transform.position.z + Random.Range(minDistance, maxDistance);
            wP = false;
            wp = Instantiate(wayPoint, new Vector3(distanceX, 0, 0), Quaternion.identity) as GameObject;
        }
    }
}
