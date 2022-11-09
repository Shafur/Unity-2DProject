using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public VectorValue startingPosition;


    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();


        transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        change.y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }
    }
    private IEnumerator AttackCo()

        { animator.SetBool("Attacking", true);
    currentState = PlayerState.attack; 
    yield return null;
    animator.SetBool("Attacking", false);
    yield return new WaitForSeconds(.23f);
    currentState = PlayerState.walk;
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)

        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
            transform.Translate(new Vector3(change.x, change.y));
            GetComponent<AudioSource>().UnPause();
        }
        else
        {
            animator.SetBool("moving", false);
            GetComponent<AudioSource>().Pause();
        }
    }
    void MoveCharacter()
    {
        myRigidbody.MovePosition(
                 transform.position + change * speed * Time.deltaTime);
    }
    public void Knock(float knockTime)
    {
        StartCoroutine(KnockCo(knockTime));
    }

    private IEnumerator KnockCo(float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;

            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }

}