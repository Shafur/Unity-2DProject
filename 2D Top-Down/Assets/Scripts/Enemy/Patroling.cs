using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroling : EnemyMovement
{
    // Start is called before the first frame update
    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;
    private Rigidbody2D myRigidBody;
    public Transform target;

    [SerializeField]
    private int moveSpeed = 4;


    private void Start()
    {
        
        myRigidBody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    public void CheckDistance()
    {
        if(Vector3.Distance(transform.position, target.position) < roundingDistance)
        {
            if(Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, moveSpeed * Time.deltaTime);
            }
            
        }
        else
        {
            ChangeGoal();
        }
    }

    private void ChangeGoal()
    {
        if(currentPoint == path.Length - 1)
        {
            currentPoint = 0;
            currentGoal = path[0];
        }
        else
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }

}
