using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject target;
    public float followAhead;
    public float smoothing;
    private Vector3 targetPosition;


    // Start is called before the first frame update
    void Start()
    {
      targetPosition = new Vector3(target.transform.position.y, 0f, -10f );
    }

    // Update is called once per frame
    void Update()
    {

      targetPosition = new Vector3(target.transform.position.x, 0f, -10f );

      //move target of the camera ahead of the player
      if (target.transform.localScale.x >0f) {
        targetPosition = new Vector3(targetPosition.x + followAhead, 0f, -10f );
      } else {
        targetPosition = new Vector3(targetPosition.x - followAhead, 0f, -10f );
      }
      transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing*Time.deltaTime);
    }
}
