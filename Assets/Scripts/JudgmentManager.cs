using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgmentManager : MonoBehaviour
{
    public List<GameObject> NoteList = new List<GameObject>(); // 생성 노트 리스트

    [SerializeField] Transform center = null; // 판정 중심
    [SerializeField] Transform[] judgmentRect = null; // 판정범위
    Vector2[] judgmentBoxs = null; // 판정 범위 최소값 x, 최대값 y

    void Start()
    {
        judgmentBoxs = new Vector2[judgmentRect.Length];

        for (int i = 0; i < judgmentRect.Length; i++)
        {
            judgmentBoxs[i].Set(center.localPosition.x - judgmentRect[i].localScale.x / 2,
                                center.localPosition.x + judgmentRect[i].localScale.x / 2);
        }
    }

    void Update()
    {
        
    }

    public void CheckTiming()
    {
        for (int i = 0; i < NoteList.Count; i++)
        {
            float notePosX = NoteList[i].transform.position.x;

            for (int j = 0; j < judgmentBoxs.Length; j++)
            {
                if (judgmentBoxs[j].x <= notePosX && notePosX <= judgmentBoxs[j].y)
                {
                    Destroy(NoteList[i].gameObject);
                    NoteList.Remove(NoteList[i]);
                    switch (j)
                    {
                        case 0:
                            Debug.Log("Perfect");
                            break;
                        case 1:
                            Debug.Log("Cool");
                            break;
                        case 2:
                            Debug.Log("Good");
                            break;
                        case 3:
                            Debug.Log("Bad");
                            break;
                    }
                    return;
                }
            }
        }
        Debug.Log("Miss");
    }
}
