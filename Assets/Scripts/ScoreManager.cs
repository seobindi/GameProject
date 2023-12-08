using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText = null;
    public int currentScore = 0;
    public int bestScore = 0;
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("bestScore");
        currentScoreText.text = "Score : " + currentScore.ToString();
    }

    // ���� ���ھ� �ø���
    public void ScoreUpdate(string monsterType)
    {
        if (monsterType == "Normal") { currentScore += 100; }
        else { currentScore += 500; }

        currentScoreText.text = "Score : " + currentScore.ToString();
        Sequence shakeSequence = DOTween.Sequence();
        shakeSequence.Append(currentScoreText.rectTransform.DOShakePosition(0.1f, new Vector3(10, 10, 0), 20, 90, false));
        
        // �ְ� ���ھ� ����
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("bestScore", bestScore);
        }
    }
}
