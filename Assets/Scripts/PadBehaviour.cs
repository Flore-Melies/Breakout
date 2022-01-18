using UnityEngine;
using UnityEngine.InputSystem;

public class PadBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private GameObject ballPrefab;

    private GameObject currentBall;
    private new Rigidbody2D rigidbody2D;
    private float inputAxis;

    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        SpawnBall();
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(inputAxis * speed, 0);
    }

    public void OnMove(InputAction.CallbackContext obj)
    {
        inputAxis = obj.ReadValue<float>();
    }

    public void OnFire(InputAction.CallbackContext obj)
    {
        if (currentBall == null) return;
        currentBall.GetComponent<BallBehaviour>().Launch();
        currentBall = null;
    }

    public void SpawnBall()
    {
        var myTransform = transform;
        var ballPosition = (Vector2)myTransform.position + Vector2.up * 0.35f;
        currentBall = Instantiate(ballPrefab, ballPosition, Quaternion.identity, myTransform);
    }
}
