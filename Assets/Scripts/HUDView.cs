using DefaultNamespace;
using TMPro;
using UnityEngine;

public class HUDView : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private int _score;
    private void Start()
    {
        _score = 0;
        PlayerManager.instance.TargetCatched += UpdateScoreText;
    }

    private void UpdateScoreText()
    {
        _score++;
        _scoreText.text=_score.ToString();
    }
}
