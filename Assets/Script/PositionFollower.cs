using UnityEngine;

/**
 * This component follows the position of a given object, but not its rotation.
 * Especially useful for cameras.
 */
public class PositionFollower : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void LateUpdate()
    {
        if (target.transform.position.y > transform.position.y)
        {
            Vector3 newPosition = new Vector3(transform.position.x, target.transform.position.y-5, transform.position.z);
            transform.position = newPosition;

        }
    }


  
}
