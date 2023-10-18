using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private ScoreManager theScoreManager = null;
    public TextMeshProUGUI currentScoreTMPro = null;
    public TextMeshProUGUI bestScoreTMPro = null;
    public Button retryButton = null;
    public Image backgroundImage = null;

    private void Start()
    {
        retryButton.onClick.AddListener(() =>
        {
            // 현재 씬을 다시 로드합니다.
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
            Time.timeScale = 1;
        });
        gameObject.SetActive(false);
    }



    public void OnGameOver()
    {
        currentScoreTMPro.text = "NOW : " + theScoreManager.currentScore.ToString(); ;
        bestScoreTMPro.text = "BEST : " + theScoreManager.bestScore.ToString(); ;
        gameObject.SetActive(true);
    }
}