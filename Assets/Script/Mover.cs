using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/**
 * This component moves its object in a fixed velocity.
 * NOTE: velocity is defined as speed+direction.
 *       speed is a number; velocity is a vector.
 */
public class Mover : MonoBehaviour
{
    [Tooltip("Movement vector in meters per second")]
    [SerializeField]
    Vector3 velocity;



    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    public void SetVelocity(Vector3 newVelocity)
    {

        this.velocity = newVelocity;
    }
}

