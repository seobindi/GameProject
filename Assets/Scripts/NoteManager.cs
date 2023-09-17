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
        transform.position += Vector3.right * noteSpeed * Time.deltaTime; // ��Ʈ ���������� �̵�

        if (transform.position.x >= noteEndLocation.position.x)
        {
            transform.position = noteStartLocation.position;
            Destroy(currentPattern.gameObject); // ���� ��Ʈ ���� �ı�
            RandomNotePattern(); // ���ο� ��Ʈ ���� �Ҵ�
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

        // ������ġ�� ��Ʈ ������ �����ϰ� �θ�� �Ҵ�
        currentPattern = Instantiate(selectedPattern, transform.position, Quaternion.identity).transform;
        currentPattern.SetParent(transform);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("�浹");
        // ��Ʈ�� �浹�� ���
        if (isChecking)
        {
            // 1. �ٸ� �ݶ��̴��� �±׸� Ȯ���մϴ�.
            if (other.CompareTag("Perfect"))
            {
                // 2. �浹�� �ݶ��̴��� "Perfect" �±��� ���, "Perfect" ������ ����մϴ�.
                Debug.Log("Perfect");
            }
            else if (other.CompareTag("Great"))
            {
                // 3. �浹�� �ݶ��̴��� "Cool" �±��� ���, "Cool" ������ ����մϴ�.
                Debug.Log("Great");
            }
            else if (other.CompareTag("Good"))
            {
                // 4. �浹�� �ݶ��̴��� "Good" �±��� ���, "Good" ������ ����մϴ�.
                Debug.Log("Good");
            }
            else if (other.CompareTag("Bad"))
            {
                // 5. �浹�� �ݶ��̴��� "Bad" �±��� ���, "Bad" ������ ����մϴ�.
                Debug.Log("Bad");
            }
            else
            {
                // 6. �±װ� �����Ǿ� ���� ���� ��� "Miss" ������ ����մϴ�.
                Debug.Log("Miss");
            }

            // 7. �浹�� �ݶ��̴��� ��Ȱ��ȭ�Ͽ� �ߺ� ������ �����մϴ�.
            other.enabled = false;
            isChecking = false;
        }
    }
}
