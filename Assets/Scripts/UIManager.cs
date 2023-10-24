using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private NoteManager theNoteManager = null;

    //박자 UI관련
    [SerializeField] private int bpm = 0;
    [SerializeField] private Image lineUI;

    //스코어 UI관련
    [SerializeField] private TextMeshProUGUI currentScoreText = null;
    public int currentScore = 0;
    public int bestScore = 0;
    private double currentTime = 0d;

    //게임오버 UI관련
    public TextMeshProUGUI currentScoreTMPro = null;
    public TextMeshProUGUI bestScoreTMPro = null;
    public Button retryButton = null;
    public Image backgroundImage = null;
    public GameObject gameOverUI = null;
    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("bestScore");
        currentScoreText.text = currentScore.ToString();

        retryButton.onClick.AddListener(() =>
        {
            // 현재 씬을 다시 로드합니다.
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
            Time.timeScale = 1;
        });
        gameOverUI.SetActive(false);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= 60d / bpm) // 60/bpm = 한 비트당 시간 (120bpm이라면 한 비트당 소요 시간은 0.5초)
        {
            if(theNoteManager.ntbit)
            {
                theNoteManager.ntbit = false;
                theNoteManager.TurnStart(0);
            }

            lineUI.enabled = true;
            lineUI.DOFade(0, 0.2f).SetEase(Ease.OutQuad).OnComplete(() =>
            {
                lineUI.enabled = false;
                lineUI.DOFade(1, 0);
            });
            currentTime -= 60d / bpm;
        }
    }

    // 몬스터 스코어 올리기
    public void ScoreUpdate(string monsterType)
    {
        if (monsterType == "Normal") { currentScore += 100; }
        else { currentScore += 500; }

        currentScoreText.text = currentScore.ToString();
        Sequence shakeSequence = DOTween.Sequence();
        shakeSequence.Append(currentScoreText.rectTransform.DOShakePosition(0.1f, new Vector3(10, 10, 0), 20, 90, false));

        // 최고 스코어 갱신
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("bestScore", bestScore);
        }
    }

    public void OnGameOver()
    {
        currentScoreTMPro.text = currentScore.ToString(); ;
        bestScoreTMPro.text = bestScore.ToString(); ;
        gameOverUI.SetActive(true);
    }
}
