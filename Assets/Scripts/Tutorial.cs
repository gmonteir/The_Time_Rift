using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Prime31;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    // movement config
    public float gravity = -25f;
    public float runSpeed = 8f;
    public float groundDamping = 20f; // how fast do we change direction? higher means faster
    public float inAirDamping = 5f;
    public float jumpHeight = 3f;
    public Text jumpText;
    public Text shootText; 
    public GameObject jumpTextTrigger;
    public GameObject shootTextTrigger;
    public Sprite newSprite;
    public SpriteRenderer rend; 

    [HideInInspector]
    private bool jumpTextSeen = false;
    private bool shootTextSeen = false; 
    private float normalizedHorizontalSpeed = 0; 
    private CharacterController2D _controller;
    private RaycastHit2D _lastControllerColliderHit;
    private Vector3 _velocity;

    void Awake()
    {
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

    // the Update loop contains a very simple example of moving the character around and controlling the animation
    void Update()
    {
        if (_controller.isGrounded)
            _velocity.y = 0;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            normalizedHorizontalSpeed = 1;
            if (transform.localScale.x < 0f)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            normalizedHorizontalSpeed = -1;
            if (transform.localScale.x > 0f)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            normalizedHorizontalSpeed = 0;
        }


        // we can only jump whilst grounded
        if (_controller.isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            _velocity.y = Mathf.Sqrt(2f * jumpHeight * -gravity);
        }


        // apply horizontal speed smoothing it. dont really do this with Lerp. Use SmoothDamp or something that provides more control
        var smoothedMovementFactor = _controller.isGrounded ? groundDamping : inAirDamping; // how fast do we change direction?
        _velocity.x = Mathf.Lerp(_velocity.x, normalizedHorizontalSpeed * runSpeed, Time.deltaTime * smoothedMovementFactor);

        // apply gravity before moving
        _velocity.y += gravity * Time.deltaTime;

        // if holding down bump up our movement amount and turn off one way platform detection for a frame.
        // this lets us jump down through one way platforms
        if (_controller.isGrounded && Input.GetKey(KeyCode.DownArrow))
        {
            _velocity.y *= 3f;
            _controller.ignoreOneWayPlatformsThisFrame = true;
        }

        _controller.move(_velocity * Time.deltaTime);

        // grab our current _velocity to use as a base for all calculations
        _velocity = _controller.velocity;

        float distance = Vector3.Distance(this.transform.position, jumpTextTrigger.transform.position);
        if (distance < 30 && distance > 7 && !jumpTextSeen)
        {
            jumpText.enabled = true;
            jumpText.text = "\nUse '←' and '→' arrow keys to move. \nUse '↑' arrow key to jump";
        }
        else if (distance > 34)
        {
            jumpTextSeen = true;
            jumpText.enabled = false;
        }

        distance = Vector3.Distance(this.transform.position, shootTextTrigger.transform.position);
        if (distance < 30 && distance > 7 && !shootTextSeen)
        {
            shootText.enabled = true;
            shootText.text = "\nUse spacebar to shoot enemies";
        }
        else if (distance < 7)
        {
            shootTextSeen = true;
            shootText.enabled = false;
        }
    }

    //Player collects the egg 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Egg")
        {
            collision.gameObject.SetActive(false);
            rend.sprite = newSprite;
            //StartCoroutine(wait()); 
        }
    }

    //Wait to transition levels
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Jurassic", LoadSceneMode.Additive);

    }
}
