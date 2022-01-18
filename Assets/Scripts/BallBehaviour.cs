using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float positionImpact;

    private Vector2 lastFrameVelocity;

    private new Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rigidbody2D.velocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        lastFrameVelocity = rigidbody2D.velocity;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        var collisionNormal = col.GetContact(0).normal;
        var newVelocity = Vector2.Reflect(lastFrameVelocity.normalized, collisionNormal) * speed;
        if(col.gameObject.CompareTag("Pad"))
        {
            var padTransform = col.transform;
            var posDiff = transform.position.x - padTransform.position.x;
            newVelocity.x += posDiff * positionImpact;
            newVelocity = newVelocity.normalized * speed;
        }

        rigidbody2D.velocity = newVelocity;
    }

    public void Launch()
    {
        transform.SetParent(null);
        rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        var direction = Random.insideUnitCircle.normalized;
        direction.x = Mathf.Abs(direction.x);
        direction.y = Mathf.Abs(direction.y);
        rigidbody2D.velocity = direction * speed;
    }
}
