using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private Transform noteStartLocation = null;
    [SerializeField] private Transform noteEndLocation = null;
    [SerializeField] private GameObject[] notePattern = null;
    private Transform[] noteObjects = null;
    private string[] keyTag = { "Up", "Down", "Left", "Right" };

    [SerializeField] private Transform currentPattern = null;
    [SerializeField] private float noteSpeed = 0;



    void Start()
    {
        RandomNotePattern();
    }
    void Update()
    {
        transform.position += Vector3.right * noteSpeed * Time.deltaTime; // ��Ʈ ���������� �̵�

        if (transform.position.x >= noteEndLocation.position.x)
        {
            RandomNotePattern(); // ���ο� ��Ʈ ���� �Ҵ�
        }
    }
    public void RandomNotePattern()
    {
        
        GameManager.Instance.NoteList.Clear();
        Destroy(currentPattern.gameObject); // ���� ��Ʈ ���� �ı�
        
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
                noteObject.gameObject.tag = keyTag[Random.Range(0, keyTag.Length)];
                GameManager.Instance.NoteList.Add(noteObject.gameObject);
            }
        }

        transform.position = noteStartLocation.position;
    }
}
