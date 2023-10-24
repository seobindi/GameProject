using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private MonsterController theMonsterController = null;

    [SerializeField] private Transform noteStartLocation = null;
    [SerializeField] private Transform noteEndLocation = null;
    [SerializeField] private GameObject[] normalNotePattern = null;
    [SerializeField] private GameObject[] bossNotePattern = null;
    private Transform[] noteObjects = null;
    private string[] keyTag = { "Up", "Down", "Left", "Right" };
    private string monsterType = "Normal";

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

        GameObject selectedPattern;

        if (GameManager.Instance.monsterKillCount > 10 && (GameManager.Instance.monsterKillCount % 10) < 3)
        {
            monsterType = "Boss";
            int randomIndex = Random.Range(0, bossNotePattern.Length); // + ����ȭ �ʿ� ����
            selectedPattern = bossNotePattern[randomIndex]; // + ����ȭ �ʿ� ����
        }
        else
        {
            monsterType = "Normal";
            int randomIndex = Random.Range(0, normalNotePattern.Length); // + ����ȭ �ʿ� ����
            selectedPattern = normalNotePattern[randomIndex]; // + ����ȭ �ʿ� ����
        }

        // ������ġ�� ��Ʈ ������ �����ϰ� �θ�� �Ҵ�
        currentPattern = Instantiate(selectedPattern, transform.position, Quaternion.identity).transform;
        currentPattern.SetParent(transform);

        noteObjects = currentPattern.GetComponentsInChildren<Transform>();

        // �� ��Ʈ�� �±� ���� �� ��Ʈ ����Ʈ�� �Ҵ�
        foreach (Transform noteObject in noteObjects)
        {
            if (noteObject != currentPattern.transform) // �θ� ��ü�� ����
            {
                if (noteObject.gameObject.tag == "Note") { noteObject.gameObject.tag = keyTag[Random.Range(0, keyTag.Length)]; }
                GameManager.Instance.NoteList.Add(noteObject.gameObject);
            }
        }

        transform.position = noteStartLocation.position;

        theMonsterController.MonsterSpawn(monsterType);
    }
}
