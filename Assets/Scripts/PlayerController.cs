using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AnimationController ac;
    public float speed;
    public Rigidbody rigid;
    public Transform head;
    public Vector2 look;
    public float jumpPower;

    bool isGround = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;
        
        if (Input.GetKeyDown(KeyCode.V))
        {
            ac.PlayBoolAnim("IsField");
            speed *= (ac.GetBool("IsField") ? 2f : 0.5f);
        }

        if (!ac.isInteract)
        {
            var dirX = Input.GetAxisRaw("Horizontal");
            var dirZ = Input.GetAxisRaw("Vertical");

            if (dirX != 0 || dirZ != 0)
            {
                ac.PlayBoolAnim("IsMove", true);
                rigid.velocity = ((transform.forward * dirZ + transform.right * dirX).normalized * speed) + (Vector3.up * rigid.velocity.y);
            }
            else
            {
                ac.PlayBoolAnim("IsMove", false);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            ac.PlayTriggerAnim("Interact");
            StartCoroutine(ac.co_Interact());
        }

        if (isGround && Input.GetAxis("Jump") != 0)
        {
            Debug.Log("SPACE BAR");
            rigid.AddForce(Vector3.up * jumpPower);
        }

        look = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        head.rotation *= Quaternion.AngleAxis(look.x * 5, Vector3.up);
        head.rotation *= Quaternion.AngleAxis(-look.y * 5, Vector3.right);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
