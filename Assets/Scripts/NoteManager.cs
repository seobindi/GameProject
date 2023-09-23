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
        transform.position += Vector3.right * noteSpeed * Time.deltaTime; // 노트 오른쪽으로 이동

        if (transform.position.x >= noteEndLocation.position.x)
        {
            RandomNotePattern(); // 새로운 노트 패턴 할당
        }
    }
    public void RandomNotePattern()
    {
        
        GameManager.Instance.NoteList.Clear();
        Destroy(currentPattern.gameObject); // 이전 노트 패턴 파괴
        
        int randomIndex = Random.Range(0, notePattern.Length);
        GameObject selectedPattern = notePattern[randomIndex];

        // 현재위치에 노트 패턴을 생성하고 부모로 할당
        currentPattern = Instantiate(selectedPattern, transform.position, Quaternion.identity).transform;
        currentPattern.SetParent(transform);

        // 각 노트를 노트 리스트에 할당
        noteObjects = currentPattern.GetComponentsInChildren<Transform>();
        foreach (Transform noteObject in noteObjects)
        {
            if (noteObject != currentPattern.transform) // 부모 자체는 제외
            {
                noteObject.gameObject.tag = keyTag[Random.Range(0, keyTag.Length)];
                GameManager.Instance.NoteList.Add(noteObject.gameObject);
            }
        }

        transform.position = noteStartLocation.position;
    }
}
