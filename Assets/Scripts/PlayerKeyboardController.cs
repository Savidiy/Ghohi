using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardController : MonoBehaviour
{
    [SerializeField] float _rotateSpeed = 6f;
    [SerializeField] GameObject lookFrom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        inputDirection.Normalize();

        //lookFrom rotation

        Vector3 lookFromDirection = transform.position - lookFrom.transform.position;
        Vector3 lookAtPoint = transform.position + lookFromDirection;
        Vector3 lookAtPointStabilized = new Vector3(lookAtPoint.x, transform.position.y, lookAtPoint.z);
        //transform.LookAt(lookAtPointStabilized);

        //transform.rotation


    }
}
