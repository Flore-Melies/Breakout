using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;

    private ScoreBehaviour score;

    private void Awake()
    {
        var scoreObject = GameObject.FindWithTag("Score");
        score = scoreObject.GetComponent<ScoreBehaviour>();
    }

    private void OnCollisionEnter2D()
    {
        score.value += 5;
        if (score.value == 72)
        {
            Instantiate(winScreen);
        }

        Destroy(gameObject);
    }
}
