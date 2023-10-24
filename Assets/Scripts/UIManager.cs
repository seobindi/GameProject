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

    //���� UI����
    [SerializeField] private int bpm = 0;
    [SerializeField] private Image lineUI;

    //���ھ� UI����
    [SerializeField] private TextMeshProUGUI currentScoreText = null;
    public int currentScore = 0;
    public int bestScore = 0;
    private double currentTime = 0d;

    //���ӿ��� UI����
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
            // ���� ���� �ٽ� �ε��մϴ�.
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
            Time.timeScale = 1;
        });
        gameOverUI.SetActive(false);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= 60d / bpm) // 60/bpm = �� ��Ʈ�� �ð� (120bpm�̶�� �� ��Ʈ�� �ҿ� �ð��� 0.5��)
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

    // ���� ���ھ� �ø���
    public void ScoreUpdate(string monsterType)
    {
        if (monsterType == "Normal") { currentScore += 100; }
        else { currentScore += 500; }

        currentScoreText.text = currentScore.ToString();
        Sequence shakeSequence = DOTween.Sequence();
        shakeSequence.Append(currentScoreText.rectTransform.DOShakePosition(0.1f, new Vector3(10, 10, 0), 20, 90, false));

        // �ְ� ���ھ� ����
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
