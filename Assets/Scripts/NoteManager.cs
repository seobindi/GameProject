using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private Transform noteStartLocation = null;
    [SerializeField] private Transform noteEndLocation = null;
    [SerializeField] private GameObject[] notePattern = null;
    private Transform[] noteObjects = null;
    [SerializeField] private float noteSpeed = 0;

    [SerializeField] JudgmentManager theJudgmentManager;

    private Transform currentPattern;


    void Start()
    {
        RandomNotePattern();
    }
    void Update()
    {
        transform.position += Vector3.right * noteSpeed * Time.deltaTime; // ��Ʈ ���������� �̵�

        if (transform.position.x >= noteEndLocation.position.x)
        {
            transform.position = noteStartLocation.position;
            theJudgmentManager.NoteList.Clear();
            Destroy(currentPattern.gameObject); // ���� ��Ʈ ���� �ı�
            RandomNotePattern(); // ���ο� ��Ʈ ���� �Ҵ�
        }
    }

    void RandomNotePattern()
    {
        int randomIndex = Random.Range(0, notePattern.Length);
        GameObject selectedPattern = notePattern[randomIndex];

        // ������ġ�� ��Ʈ ������ �����ϰ� �θ�� �Ҵ�
        currentPattern = Instantiate(selectedPattern, transform.position, Quaternion.identity).transform;
        currentPattern.SetParent(transform);

        // �� ��Ʈ�� ��Ʈ ����Ʈ�� �Ҵ�
        noteObjects = currentPattern.GetComponentsInChildren<Transform>();
        foreach (Transform noteObject in noteObjects)
        {
            if (noteObject != currentPattern.transform) // �θ� ��ü�� ����
            {
                theJudgmentManager.NoteList.Add(noteObject.gameObject);
            }
        }
    }
}
