using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Transform launchIndicator;
    [SerializeField] private InputManager inputManager;

    private Rigidbody ballRB;
    private bool isLaunched;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;

        inputManager.OnSpacePressed.AddListener(LaunchBall);

        ResetBall();
    }

    public void ResetBall()
    {
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        launchIndicator.gameObject.SetActive(true);
        isLaunched = false;
        ballRB.isKinematic = true;
    }

    private void LaunchBall()
    {
        if (isLaunched) return;
        isLaunched = true;
        transform.parent = null;
        ballRB.isKinematic = false;
        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
        launchIndicator.gameObject.SetActive(false);
    }
}
