using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow2 : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (target.position + offset);
        target.localEulerAngles = Vector3.up * transform.localEulerAngles.y;
    }
}
