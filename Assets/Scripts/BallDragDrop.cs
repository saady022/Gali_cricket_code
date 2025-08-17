using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    private Vector3 touchStartPos;
    private Vector3 touchEndPos;
    private Rigidbody rb;
    private float forceMultiplier = 1.15f;
    private IEnumerator coroutine;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Reset velocity when the ball is instantiated
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void Update()
    {
       // BatsmanController.myAnimator.SetBool("Hit", false);
        // Check if there are any touches
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
                BatsmanController.myAnimator.SetBool("Hit", true); // Animation Activation
                StartCoroutine(ResetHitAnimation()); // Start coroutine to reset animation
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                touchEndPos = touch.position;
                Vector3 force = touchStartPos - touchEndPos;

                // Convert touch movement to world space direction
                Vector3 worldForce = new Vector3(force.x, force.y, force.y); // Adjust Z axis based on Y input
               
                Shoot(worldForce);
               // BatsmanController.myAnimator.SetBool("Hit", false);
            }
           
        }
    }

     public IEnumerator ResetHitAnimation()
    {
        // Wait until the current animation has finished
        yield return new WaitForSeconds(BatsmanController.myAnimator.GetCurrentAnimatorStateInfo(0).length);
        BatsmanController.myAnimator.SetBool("Hit", false); // Reset "Hit" to false
    }

    private void Shoot(Vector3 force)
    {
        // Apply force in the correct direction, considering upward movement
        Vector3 direction = force.normalized;
        float ballPositionZ = rb.transform.position.z;
        if (ballPositionZ < -2.65f)
        {
            rb.AddForce(direction * force.magnitude * forceMultiplier);
        }
        
    }
}
