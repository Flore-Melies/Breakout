using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{
    private ScoreBehaviour score;

    private void Awake()
    {
        var scoreObject = GameObject.FindWithTag("Score");
        score = scoreObject.GetComponent<ScoreBehaviour>();
    }

    private void OnCollisionEnter2D()
    {
        score.value += 5;
        Destroy(gameObject);
    }
}
