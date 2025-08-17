using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    public bool death = false;
    public float ballSpeed = 10f;

    private int ballTouchCount = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rb.AddForce(Vector3.back * ballSpeed, ForceMode.Impulse);
        Invoke("DestroyBall", 6f);
    }

    // Update is called once per frame
    private void DestroyBall()
    {
        Destroy(this.gameObject);
    }
    public void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Bat"))
        //{
        //    float ballForce = Random.Range(1f, 8f); // Reduce the force range
        //    float ballHeight = Random.Range(3f, 9f);
        //    float ballAngle = Random.Range(0f, 180f);

        //    // Calculate a new direction using the random angle
        //    Vector3 newDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad * ballAngle) * ballForce,
        //                                      ballHeight,
        //                                      Mathf.Abs(Mathf.Sin(Mathf.Deg2Rad * ballAngle)) * ballForce);

        //    // Reset the ball's velocity
        //    rb.velocity = Vector3.zero;

        //    // Apply the new force in the new direction
        //    rb.AddForce(newDirection, ForceMode.Impulse);

        //    Debug.Log(newDirection);

        //}
        if (other.gameObject.CompareTag("Boundary"))
        {
            if (ballTouchCount > 2)
            {
                GameManager.Instance.UpdateRuns(4);
            }
            else
            {
                GameManager.Instance.UpdateRuns(6);
            }
        }
        if (other.gameObject.CompareTag("Out"))
        {
            GameManager.Instance.totalRuns = 0;
            GameManager.Instance.UpdateRuns(1); //gonna update this while making scenes
            death = true;
            if (death)
            {
                SceneManager.LoadSceneAsync(2);
            }
        }

    }
    public void OnCollisionEnter(Collision collision)
    {
        ballTouchCount++;
    }
}