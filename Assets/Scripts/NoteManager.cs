using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private MonsterController theMonsterController = null;

    [SerializeField] private Transform noteStartLocation = null;
    [SerializeField] private Transform noteEndLocation = null;
    [SerializeField] private Transform turnStartLocation = null;
    [SerializeField] private GameObject[] normalNotePattern = null;
    [SerializeField] private GameObject[] bossNotePattern = null;

    private Transform[] noteObjects = null;
    private string[] keyTag = { "Up", "Down", "Left", "Right" };
    public string monsterType = "Normal";

    [SerializeField] private Transform currentPattern = null;
    [SerializeField] private float noteSpeed = 0;
<<<<<<< HEAD

    public bool Note = true;
=======
<<<<<<< Updated upstream
=======

    public int monsterKillCount = 0;
    public bool Note = true;
    public bool ntbit = false;
>>>>>>> Stashed changes
>>>>>>> seob
    void Start()
    {
        RandomNotePattern();
    }
    void Update()
    {
        if (Note) { transform.position += Vector3.right * noteSpeed * Time.deltaTime; } // 노트 오른쪽으로 이동

        if (transform.position.x >= noteEndLocation.position.x)
        {
            RandomNotePattern(); // 새로운 노트 패턴 할당
        }
    }
    public void RandomNotePattern()
    {
        GameManager.Instance.NoteList.Clear();
        Destroy(currentPattern.gameObject); // 이전 노트 패턴 파괴

        GameObject selectedPattern;

        if (monsterKillCount > 10 && (monsterKillCount % 10) < 3)
        {
            monsterType = "Boss";
            int randomIndex = Random.Range(0, bossNotePattern.Length);
            selectedPattern = bossNotePattern[randomIndex];
        }
        else
        {
            monsterType = "Normal";
            int randomIndex = Random.Range(0, normalNotePattern.Length);
            selectedPattern = normalNotePattern[randomIndex];
        }

        // 현재위치에 노트 패턴을 생성하고 부모로 할당
        currentPattern = Instantiate(selectedPattern, transform.position, Quaternion.identity).transform;
        currentPattern.SetParent(transform);

        noteObjects = currentPattern.GetComponentsInChildren<Transform>();

        // 각 노트를 태그 셋팅 후 노트 리스트에 할당
        foreach (Transform noteObject in noteObjects)
        {
            if (noteObject != currentPattern.transform) // 부모 자체는 제외
            {
                if (noteObject.gameObject.tag == "Note") { noteObject.gameObject.tag = keyTag[Random.Range(0, keyTag.Length)]; }
                GameManager.Instance.NoteList.Add(noteObject.gameObject);
            }
        }

        transform.position = new Vector3(-20, transform.position.y, transform.position.z);
        ntbit = true;

        theMonsterController.MonsterSpawn(monsterType);
    }

    public void TurnStart(int turn)
    {
        if(turn == 0)
            transform.position = noteStartLocation.position;
        else
            transform.position = turnStartLocation.position;
    }
}
