using UnityEngine;

public class DeathBehaviour : MonoBehaviour
{
    [SerializeField] private PadBehaviour pad;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Ball"))
            pad.SpawnBall();
        Destroy(col.gameObject);
    }
}
