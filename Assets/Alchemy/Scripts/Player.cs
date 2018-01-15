using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float MovementSpeed;
    // private Animator anim;
    [SerializeField]
    private Stat health;
    private Rigidbody2D myrigidbody;
    private bool isMoving;
    private Vector2 lastMove;
    private static bool playerExists;
    protected bool isAttacking = false;
    protected Coroutine attackRoutine;
    private void Awake()
    {
        health.Initialize();
    }
    private void Start()
    {
     //   anim = GetComponent<Animator>();
        myrigidbody = GetComponent<Rigidbody2D>();
        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
            Destroy(gameObject);
    }
    private void Update()
    {
        isMoving = false;
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * MovementSpeed * Time.deltaTime, 0f, 0f));
            myrigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * MovementSpeed, myrigidbody.velocity.y);
            isMoving = true;
            StopAttack();
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            health.CurrentVal -= Input.GetAxisRaw("Horizontal");
        }
        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            myrigidbody.velocity = new Vector2(0f, myrigidbody.velocity.y);

        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * MovementSpeed * Time.deltaTime, 0f));
            myrigidbody.velocity = new Vector2(myrigidbody.velocity.x, Input.GetAxisRaw("Vertical") * MovementSpeed);
            isMoving = true;
            StopAttack();
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }
        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            myrigidbody.velocity = new Vector2(myrigidbody.velocity.x, 0f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isAttacking && !isMoving)
            {
                attackRoutine = StartCoroutine(Attack());
            }
        }
        //  anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        //    anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        //    anim.SetBool("PlayerMoving", playerMoving);
        //    anim.SetFloat("LastMoveX", lastMove.x);
        //    anim.SetFloat("LastMoveY", lastMove.y);
    }
    private IEnumerator Attack()
    { 
            isAttacking = true;
            yield return new WaitForSeconds(1);
            StopAttack();
    }
    public void StopAttack()
    {
        if (attackRoutine != null)
        {
            StopCoroutine(attackRoutine);
            isAttacking = false;
        }
    }
}
