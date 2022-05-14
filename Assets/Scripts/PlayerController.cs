using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public Rigidbody rigid;
    public bool isInteract = false;


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
            animator.SetBool("IsField", !animator.GetBool("IsField"));
            speed *= (animator.GetBool("IsField") ? 2f : 0.5f);
        }

        if (!isInteract)
        {
            var dirX = Input.GetAxisRaw("Horizontal");
            var dirZ = Input.GetAxisRaw("Vertical");

            if (dirX != 0 || dirZ != 0)
            {
                animator.SetBool("IsMove", true);
                rigid.velocity = (transform.forward * dirZ + transform.right * dirX).normalized * speed;
            }
            else
            {
                animator.SetBool("IsMove", false);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Interact");
            StartCoroutine(co_Interact());
        }
    }

    IEnumerator co_Interact()
    {
        isInteract = true;
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        isInteract = false;
    }
}
