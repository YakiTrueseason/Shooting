//スコア表示

using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Update()
    {
        scoreText.text = "Score: " + ScoreManager.Instance.GetScore();
    }
}
