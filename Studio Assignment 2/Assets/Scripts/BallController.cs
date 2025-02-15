using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;

    private Rigidbody ballRB;
    private bool isLaunched;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();

        inputManager.OnSpacePressed.AddListener(LaunchBall);
    }

    private void LaunchBall()
    {
        if (isLaunched) return;
        isLaunched = true;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
