using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public Vector2 look;
    public float rotationPower = 3f;
    public Transform head;

    [SerializeField] bool isSelfRotate = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isSelfRotate = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            StartCoroutine(LerpRotation());
        }

        look = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        
        head.rotation *= Quaternion.AngleAxis(look.x * rotationPower, Vector3.up);
        head.rotation *= Quaternion.AngleAxis(-look.y * rotationPower, Vector3.right);

        if (!isSelfRotate)
        {
            //transform.localEulerAngles = Camera.main.transform.localEulerAngles.y * Vector3.up;
            transform.localEulerAngles =  head.localEulerAngles.y * Vector3.up;
            
        }
    }

    IEnumerator LerpRotation()
    {
        float rotateTime = 0f;
        while (rotateTime < 1.5f)
        {
            yield return new WaitForEndOfFrame();
            rotateTime += Time.deltaTime;
            transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, head.localEulerAngles.y * Vector3.up, 0.1f);
        }
        isSelfRotate = false;
    }
}
