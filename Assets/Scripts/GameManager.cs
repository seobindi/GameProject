using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null; // 싱글톤 작업
    public List<GameObject> NoteList = new List<GameObject>(); // 생성 노트 리스트

    [SerializeField] Transform center = null; // 판정 중심
    [SerializeField] Transform[] judgmentRange = null; // 판정범위
    Vector2[] judgmentBoxs = null; // 판정 범위 최소값 x, 최대값 y
    void Awake() // 싱글톤 작업
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        judgmentBoxs = new Vector2[judgmentRange.Length];

        for (int i = 0; i < judgmentRange.Length; i++)
        {
            judgmentBoxs[i].Set(center.position.x - judgmentRange[i].localScale.x / 2,
                                center.position.x + judgmentRange[i].localScale.x / 2);
        }
    }

    public static GameManager Instance // 싱글톤 작업
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    } 

    public int CheckTiming(string keyTag)
    {
        if (NoteList[0].gameObject.tag == keyTag) // 노트태그과 키태그 비교
        {
            float notePosX = NoteList[0].transform.position.x; // 첫번째 노트 X위치 할당
            for (int i = 0; i < judgmentBoxs.Length; i++) // 모든 판정박스 체크
            {
                if (judgmentBoxs[i].x <= notePosX && notePosX <= judgmentBoxs[i].y) // 판정 범위에 속해있는지 체크
                {   
                    NoteList.RemoveAt(0);
                    switch (i)
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
                    if (keyTag != "Hit") { return 1; }
                    else                 { return 3; }
                }
            }
            Debug.Log("Judge Miss");
            return 2;
        }
        else { Debug.Log("Key Miss"); return 2; }
    }
}