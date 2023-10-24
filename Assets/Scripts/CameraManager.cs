using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float cameraSpeed = 0.0f;
    [SerializeField] private float shakeDuration = 0.1f; // ��鸲 ���� �ð�
    [SerializeField] private float shakeSpeed = 0.5f; // ��鸲�� ����
    [SerializeField] private float yOffset = 0.0f;
    [SerializeField] private int bpm = 0;
    private double currentTime = 0d;
    private float nowShakeDuration = 0.0f;
    public bool bossMode = false;
    private Vector3 targetPosition;

    //ī�޶� ������
    void Update()
    {
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
        //{
        //    transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * CameraSpeed); // �̵� �� �̵�
        //}
    }

    public void ShakeCamera()
    {
        nowShakeDuration = shakeDuration;
    }
}