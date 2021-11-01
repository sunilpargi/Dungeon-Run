using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;
    public Vector3 animationVector;

    private float transition = 0f;
  [SerializeField]  private float animationDuration = 2f;
    private Vector3 animationOffset = new Vector3(0, 5, 5);
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = lookAt.position + startOffset;

        //x
        moveVector.x = 0;

        //y
        moveVector.y = Mathf.Clamp( moveVector.y,3, 5);

      
        if(transition > 1.0f)
        {
            transform.position = moveVector;
            transform.rotation = Quaternion.Euler(4f, 0, 0);
        }
        else
        {
            transform.position = Vector3.Lerp(animationVector, moveVector, transition);
            transition += Time.deltaTime / 1 * animationDuration; // after 3 sec value of transition will be 1
            transform.LookAt(lookAt.position + Vector3.up);
        }
    }
}
