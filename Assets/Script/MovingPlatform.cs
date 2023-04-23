using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * This component moves its object in fixed speead back and forth between two point in space.
 */
public class MovingPlatform : MonoBehaviour
{
    [Tooltip("The point vetween which the platform moves")]
    [SerializeField] public Transform startPoint = null, endPoint = null;
    [SerializeField] float speed = 1f;

    bool moveFromStartToEnd = true;
    // Start is called before the first frame update
    void Start()
    {
     
    }



    void FixedUpdate()
    {
        float deltX = speed * Time.fixedDeltaTime;

        // move from start to end
        if (moveFromStartToEnd)
        {
            // Calculate a position between the points specified by current and target, moving
            // no farther than the distance specified by deltX.
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, deltX);
        }
        else
        {// move from end to start
            transform.position = Vector3.MoveTowards(transform.position, startPoint.position, deltX);

        }
        if(transform.position == startPoint.position)
        {
            moveFromStartToEnd = true;
        }else if(transform.position == endPoint.position)
        {
            moveFromStartToEnd = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.transform.parent = this.transform;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.parent = null;
        }
    }
}
