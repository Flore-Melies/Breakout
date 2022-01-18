using TMPro;
using UnityEngine;

public class ScoreBehaviour : MonoBehaviour
{
    public int value;

    private TextMeshProUGUI textMesh;

    // Update is called once per frame
    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        textMesh.text = value.ToString();
    }
}
