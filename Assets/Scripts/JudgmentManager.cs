using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgmentManager : MonoBehaviour
{
    public List<GameObject> NoteList = new List<GameObject>(); // ���� ��Ʈ ����Ʈ

    [SerializeField] Transform center = null; // ���� �߽�
    [SerializeField] Transform[] judgmentRange = null; // ��������
    Vector2[] judgmentBoxs = null; // ���� ���� �ּҰ� x, �ִ밪 y
    void Start()
    {
        judgmentBoxs = new Vector2[judgmentRange.Length];

        for (int i = 0; i < judgmentRange.Length; i++)
        {
            judgmentBoxs[i].Set(center.localPosition.x - judgmentRange[i].localScale.x / 2,
                                center.localPosition.x + judgmentRange[i].localScale.x / 2);
        }
    }

    public void CheckTiming(string keyTag)
    {
        for (int i = 0; i < NoteList.Count; i++)
        {
            float notePosX = NoteList[i].transform.position.x;

            for (int j = 0; j < judgmentBoxs.Length; j++)
            {
                if (NoteList[i].gameObject.tag == keyTag && 
                           judgmentBoxs[j].x <= notePosX && notePosX <= judgmentBoxs[j].y)
                {
                    NoteList.RemoveAt(i);
                    switch (j)
                    {
                        case 0:
                            Debug.Log("Perfect");
                            break;
                        case 1:
                            Debug.Log("Great");
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
        Debug.Log("Dead");
    }
}
