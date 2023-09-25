using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null; // �̱��� �۾�
    public List<GameObject> NoteList = new List<GameObject>(); // ���� ��Ʈ ����Ʈ

    [SerializeField] Transform center = null; // ���� �߽�
    [SerializeField] Transform[] judgmentRange = null; // ��������
    Vector2[] judgmentBoxs = null; // ���� ���� �ּҰ� x, �ִ밪 y
    void Awake() // �̱��� �۾�
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

    public static GameManager Instance // �̱��� �۾�
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
        if (NoteList[0].gameObject.tag == keyTag) // ��Ʈ�±װ� Ű�±� ��
        {
            float notePosX = NoteList[0].transform.position.x; // ù��° ��Ʈ X��ġ �Ҵ�
            for (int i = 0; i < judgmentBoxs.Length; i++) // ��� �����ڽ� üũ
            {
                if (judgmentBoxs[i].x <= notePosX && notePosX <= judgmentBoxs[i].y) // ���� ������ �����ִ��� üũ
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