using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private MonsterController theMonsterController = null;
    [SerializeField] private Camera mainCamera;
<<<<<<< Updated upstream
    [SerializeField] private float cameraSpeed = 0.0f;
    [SerializeField] private float shakeDuration = 0.1f; // ��鸲 ���� �ð�
    [SerializeField] private float shakeSpeed = 0.5f; // ��鸲�� ����
    [SerializeField] private float yOffset = 0.0f;
    [SerializeField] private int bpm = 0;
    private double currentTime = 0d;
    private float nowShakeDuration = 0.0f;
    public bool bossMode = false;
    private Vector3 targetPosition;
=======
    //[SerializeField] private bool bossMode = false;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform[] cameraPosition_R = null;
    [SerializeField] private Transform[] cameraPosition_L = null;
>>>>>>> Stashed changes

    //ī�޶� ������
    void Update()
    {
<<<<<<< Updated upstream
        currentTime += Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);

        if(!bossMode) // �񺸽� ���
        {
            targetPosition = Target.position;
            targetPosition.y += yOffset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraSpeed); // �׻� �̵�
            mainCamera.orthographicSize = 5.0f;
        }
        else // ���� ���
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraSpeed);
            mainCamera.orthographicSize = 7.0f;
        }

        if (currentTime >= 60d / bpm) // 60/bpm = �� ��Ʈ�� �ð� (120bpm�̶�� �� ��Ʈ�� �ҿ� �ð��� 0.5��)
        {
            ShakeCamera();
            currentTime -= 60d / bpm;
        }

        //ī�޶� ��鸲
        if (nowShakeDuration > 0)
        {
            Vector3 shakeOffset = Random.insideUnitSphere * shakeSpeed; // ������ ��ġ ���� ����
            transform.localPosition = transform.position + shakeOffset; // ��鸲 ȿ���� ī�޶� ��ġ �̵�
            nowShakeDuration -= Time.deltaTime; // ��鸲 ���� �ð� ����
        }
        //else
=======
        //if(!bossMode) // �񺸽� ���
        //{
        //    targetPosition.y += yOffset;
        //    transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraSpeed); // �׻� �̵�
        //    mainCamera.orthographicSize = 5.0f;
        //}
        //else // ���� ���
>>>>>>> Stashed changes
        //{
        //    transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraSpeed);
        //    mainCamera.orthographicSize = 7.0f;
        //}
    }

<<<<<<< Updated upstream
    public void ShakeCamera()
    {
        nowShakeDuration = shakeDuration;
=======
    public void CameraMove(int turn)
    {
        if (turn == 0)
        {
            if(GameManager.Instance.NoteList.Count < 5)
            {
                if (theMonsterController.Right_dir)
                {
                    transform.DOMove(cameraPosition_R[GameManager.Instance.NoteList.Count - 1].position, 0.1f).SetEase(Ease.OutQuad);
                }
                else
                {
                    transform.DOMove(cameraPosition_L[GameManager.Instance.NoteList.Count - 1].position, 0.2f).SetEase(Ease.OutQuad);
                }
            }
            else
            {
                if (theMonsterController.Right_dir)
                {
                    transform.DOMove(cameraPosition_R[GameManager.Instance.NoteList.Count - 2].position, 0.1f).SetEase(Ease.OutQuad);
                }
                else
                {
                    transform.DOMove(cameraPosition_L[GameManager.Instance.NoteList.Count - 2].position, 0.2f).SetEase(Ease.OutQuad);
                }
            }
        }
        else if (turn == 1)
        {
            if (GameManager.Instance.NoteList.Count < 5)
            {
                if (theMonsterController.Right_dir)
                {
                    transform.DOMove(cameraPosition_R[0].position, 0.2f).SetEase(Ease.OutQuad);
                }
                else
                {
                    transform.DOMove(cameraPosition_L[0].position, 0.2f).SetEase(Ease.OutQuad);
                }
            }
            else
            {
                if (theMonsterController.Right_dir)
                {
                    transform.DOMove(cameraPosition_R[1].position, 0.2f).SetEase(Ease.OutQuad);
                }
                else
                {
                    transform.DOMove(cameraPosition_L[1].position, 0.2f).SetEase(Ease.OutQuad);
                }
            }
        }


        //transform.DOShakePosition(duration, new Vector3(strength, strength, 0), 20, 90, false)
        //    .OnStart(() => {
        //    })
        //    .OnComplete(() => {
        //    });

>>>>>>> Stashed changes
    }
}