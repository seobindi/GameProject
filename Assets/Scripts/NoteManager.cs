using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private Transform noteStartLocation = null;
    [SerializeField] private Transform noteEndLocation = null;
    [SerializeField] private GameObject[] notePattern = null;
    [SerializeField] private float noteSpeed = 0;

    private Transform currentPattern;
    private bool isChecking = false;
    void Start()
    {
        RandomNotePattern();
    }
    void Update()
    {
        transform.position += Vector3.right * noteSpeed * Time.deltaTime; // 노트 오른쪽으로 이동

        if (transform.position.x >= noteEndLocation.position.x)
        {
            transform.position = noteStartLocation.position;
            Destroy(currentPattern.gameObject); // 이전 노트 패턴 파괴
            RandomNotePattern(); // 새로운 노트 패턴 할당
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Kie");
            isChecking = true;
        }
    }

    void RandomNotePattern()
    {
        int randomIndex = Random.Range(0, notePattern.Length);
        GameObject selectedPattern = notePattern[randomIndex];

        // 현재위치에 노트 패턴을 생성하고 부모로 할당
        currentPattern = Instantiate(selectedPattern, transform.position, Quaternion.identity).transform;
        currentPattern.SetParent(transform);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("충돌");
        // 노트와 충돌한 경우
        if (isChecking)
        {
            // 1. 다른 콜라이더의 태그를 확인합니다.
            if (other.CompareTag("Perfect"))
            {
                // 2. 충돌한 콜라이더가 "Perfect" 태그인 경우, "Perfect" 판정을 출력합니다.
                Debug.Log("Perfect");
            }
            else if (other.CompareTag("Great"))
            {
                // 3. 충돌한 콜라이더가 "Cool" 태그인 경우, "Cool" 판정을 출력합니다.
                Debug.Log("Great");
            }
            else if (other.CompareTag("Good"))
            {
                // 4. 충돌한 콜라이더가 "Good" 태그인 경우, "Good" 판정을 출력합니다.
                Debug.Log("Good");
            }
            else if (other.CompareTag("Bad"))
            {
                // 5. 충돌한 콜라이더가 "Bad" 태그인 경우, "Bad" 판정을 출력합니다.
                Debug.Log("Bad");
            }
            else
            {
                // 6. 태그가 설정되어 있지 않은 경우 "Miss" 판정을 출력합니다.
                Debug.Log("Miss");
            }

            // 7. 충돌한 콜라이더를 비활성화하여 중복 판정을 방지합니다.
            other.enabled = false;
            isChecking = false;
        }
    }
}
