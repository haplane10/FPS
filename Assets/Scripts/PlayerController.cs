using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AnimationController ac;
    public float speed;
    public Rigidbody rigid;

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
                rigid.velocity = (transform.forward * dirZ + transform.right * dirX).normalized * speed;
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

        if (Input.GetAxis("Jump") != 0)
        {

        }
    }

    
}
