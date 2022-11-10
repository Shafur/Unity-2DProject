using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour


{


    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public VectorValue startingPosition;


    // Start is called before the first frame update

    private void Start()
    {
        
            myRigidbody = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        change.y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        if (change != Vector3.zero)
        {
            transform.Translate(new Vector3(change.x, change.y));
        }
    }

    // Update is called once per frame
    void MoveCharacter()
    {
        myRigidbody.MovePosition(
                transform.position + change * speed * Time.deltaTime);
    }
}
