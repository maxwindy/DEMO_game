using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freeBoy : MonoBehaviour
{
    public Transform[] wayPoint;
    public float speed;
    private int current;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (transform.position != wayPoint[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, wayPoint[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else
        {
            current = (current + 1) % wayPoint.Length;
            transform.Rotate(Vector3.up * 90);
        }
	}
}
