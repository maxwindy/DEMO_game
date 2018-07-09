using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai_woon : MonoBehaviour
{
    float speed = 1.0f;
    float rotateSpeed = 2.0f;
    float minDistance = -3.0f;
    float maxDistance = 3.0f;

    Animator anim;
    public GameObject wayPoint;
    GameObject WP;
    bool wayP = false;

    public MovementStates movementType;
    public enum MovementStates
    {
        Idle, Walk
    }

	void Awake ()
    {
        anim = GetComponent<Animator>();
	}

    void Start()
    {
        StartCoroutine ( ChooseAction() );
    }

    void Update ()
    {
        if (movementType == MovementStates.Idle)
        {
            anim.SetBool("isMove", false);
        }

        if (movementType == MovementStates.Walk)
        {
            anim.SetBool("isMove", true);
            CreateWayPoint();
        }

        if (wayP)
        {
            Move();
        }
    }

    private IEnumerator ChooseAction()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);

            if (!wayP)
            {
                int num = Random.Range(0, 2);

                if (num == 0)
                {
                    movementType = MovementStates.Idle;
                }
                else
                {
                    movementType = MovementStates.Walk;
                }
            }
        }
    }

    void CreateWayPoint()
    {
        if (!wayP)
        {
            wayP = true;
            float distanceX = transform.position.x + Random.Range(minDistance, maxDistance);
            float distanceZ = transform.position.z + Random.Range(minDistance, maxDistance);
            WP = Instantiate(wayPoint, new Vector3(distanceX, 0, distanceZ), Quaternion.identity) as GameObject;
        }
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, WP.transform.position, speed * Time.deltaTime);

        var rotation = Quaternion.LookRotation(WP.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider wayPoint)
    {
        wayP = false;
        Destroy(WP);
        movementType = MovementStates.Idle;
    }
}
