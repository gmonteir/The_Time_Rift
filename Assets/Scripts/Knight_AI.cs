using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Prime31;
using UnityEngine.SceneManagement;


public class Knight_AI : MonoBehaviour
{
    public Transform Player;
    public int MoveSpeed = 4;
    public int MaxDist = 10;
    public int MinDist = 7;
    public GameObject bullet_right;
    public GameObject bullet_left;
    public Transform shotSpawn;
    public float bulletSpeed;

    public float gravity = -25f;
    public float runSpeed = 8f;
    public float groundDamping = 20f; // how fast do we change direction? higher means faster
    public float inAirDamping = 5f;
    public float jumpHeight = 3f;

    public float fireRate;
    public float nextFire = 0;


    private float total_fire_time;
    private Rigidbody2D rbb;

    private CharacterController2D _controller;
    private RaycastHit2D _lastControllerColliderHit;
    private Vector3 _velocity;
    //private Animator anim;
    private bool facingRight = true;
    private float normalizedHorizontalSpeed = 0;
    private bool move_cd = false;

    public int delay = 50;
    private int curr_delay = 0;


    void Awake()
    {
        rbb = GetComponent<Rigidbody2D>();
        _controller = GetComponent<CharacterController2D>();

        // listen to some events for illustration purposes
        _controller.onControllerCollidedEvent += onControllerCollider;
        _controller.onTriggerEnterEvent += onTriggerEnterEvent;
        _controller.onTriggerExitEvent += onTriggerExitEvent;
    }
    #region Event Listeners

    void onControllerCollider(RaycastHit2D hit)
    {
        // bail out on plain old ground hits cause they arent very interesting
        if (hit.normal.y == 1f)
            return;

        // logs any collider hits if uncommented. it gets noisy so it is commented out for the demo
        //Debug.Log( "flags: " + _controller.collisionState + ", hit.normal: " + hit.normal );
    }


    void onTriggerEnterEvent(Collider2D col)
    {
        Debug.Log("onTriggerEnterEvent: " + col.gameObject.name);
    }


    void onTriggerExitEvent(Collider2D col)
    {
        Debug.Log("onTriggerExitEvent: " + col.gameObject.name);
    }

    #endregion


    // Update is called once per frame
    void Update()
    {
        Vector3 lTemp = transform.localScale;
        //if grounded dont move in y
        if (_controller.isGrounded)
            _velocity.y = 0;

        if ((Vector3.Distance(transform.position, Player.position) >= MinDist &&
            Vector3.Distance(transform.position, Player.position) <= MaxDist)
            && !move_cd)
        {
            //enemy move right
            if (transform.position.x < (Player.position.x))
            {
                if (!facingRight && curr_delay < delay)
                {
                    curr_delay++;
                }
                else
                {
                    normalizedHorizontalSpeed = 1;
                    if (transform.localScale.x < 0f)
                        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    //if enemy facing left, start facing right 
                    if (lTemp.x < 0)
                    {
                        lTemp.x *= -1;
                        transform.localScale = lTemp;
                        facingRight = true;
                    }
                    curr_delay = 0;
                }

            }
            //enemy move left
            else
            {
                if (facingRight && curr_delay < delay)
                {
                    curr_delay++;
                }
                else
                {
                    normalizedHorizontalSpeed = -1;
                    if (transform.localScale.x > 0f)
                        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    //if enemy facing right, start facing left
                    if (lTemp.x > 0)
                    {
                        lTemp.x *= -1;
                        transform.localScale = lTemp;
                        facingRight = false;
                    }
                    curr_delay = 0;
                }
            }
        }

        else
        {
            normalizedHorizontalSpeed = 0;
        }

        // apply horizontal speed smoothing it. dont really do this with Lerp. Use SmoothDamp or something that provides more control
        var smoothedMovementFactor = _controller.isGrounded ? groundDamping : inAirDamping; // how fast do we change direction?
        _velocity.x = Mathf.Lerp(_velocity.x, normalizedHorizontalSpeed * runSpeed, Time.deltaTime * smoothedMovementFactor);

        // apply gravity before moving
        _velocity.y += gravity * Time.deltaTime;

        _controller.move(_velocity * Time.deltaTime);

        // grab our current _velocity to use as a base for all calculations
        _velocity = _controller.velocity;


    }

    //If enemy gets shot by player's bullet 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            print("GOT TO KNIGHT COLLISION");
            StartCoroutine("wait");
        }
    }

    IEnumerator wait()
    {
        move_cd = true;
        yield return new WaitForSeconds(1.0f);
        move_cd = false;
    }
}

