using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public bool isInteract = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayBoolAnim(string animName)
    {
        animator.SetBool(animName, !animator.GetBool(animName));

    }

    public void PlayBoolAnim(string animName, bool animValue)
    {
        animator.SetBool(animName, animValue);
    }

    public void PlayTriggerAnim(string animName)
    {
        animator.SetTrigger(animName);
    }

    public IEnumerator co_Interact()
    {
        isInteract = true;
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        isInteract = false;
    }

    public bool GetBool(string animName)
    {
        return animator.GetBool(animName);
    }
}
