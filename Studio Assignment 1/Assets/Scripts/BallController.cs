using UnityEngine;
using UnityEngine.Windows;


public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody sphereBody;
    [SerializeField] float ballSpeed = 2.0f;
    [SerializeField] float jumpHeight = 4.0f;
    [SerializeField] bool onGround = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveBall(Vector3 input)
    {
        Vector3 inputXZPlane = new(input.x, 0, input.z);
        if (onGround)
        {
            inputXZPlane.y = input.y * jumpHeight;
        }
        sphereBody.AddForce(inputXZPlane * ballSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.tag.Equals("Ground"))
        {
            onGround = true;
        }
    }

    private void OnCollisionExit(Collision collision) 
    { 
        if (collision.gameObject.tag.Equals("Ground"))
        {
            onGround = false;
        }
    }
}
