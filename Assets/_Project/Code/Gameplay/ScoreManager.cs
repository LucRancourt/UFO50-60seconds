using _Project.Code.Core.Patterns;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _score = 0;

    private void Start()
    {
        _scoreText.gameObject.SetActive(false);
        SceneManager.activeSceneChanged += ShowScore;
    }

    public void UpdateScore()
    {
        _score++;
        _scoreText.text = "Tasks Complete - " + _score.ToString();
    }

    public void ResetScore()
    {
        _score = 0;
    }

    public void ShowScore(Scene scene, Scene newScene)
    {
        if (newScene.name == "WinScreen")
            _scoreText.gameObject.SetActive(true);
        else
            _scoreText.gameObject.SetActive(false);

        ResetScore();
    }
}
