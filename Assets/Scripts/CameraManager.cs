using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private float CameraSpeed;
    [SerializeField] private float shakeDuration = 0.1f; // ��鸲 ���� �ð�
    [SerializeField] private float shakeSpeed = 0.5f; // ��鸲�� ����
    [SerializeField] private int bpm = 0;
    private double currentTime = 0d;
    private float NowShakeDuration;

    //ī�޶� ������
    void Update()
    {
        currentTime += Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
        //transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * CameraSpeed); // �׻� �̵�

        if (currentTime >= 60d / bpm) // 60/bpm = �� ��Ʈ�� �ð� (120bpm�̶�� �� ��Ʈ�� �ҿ� �ð��� 0.5��)
        {
            ShakeCamera();
            currentTime -= 60d / bpm;
        }

        

        if (NowShakeDuration > 0)
        {
            Vector3 shakeOffset = Random.insideUnitSphere * shakeSpeed; // ������ ��ġ ���� ����
            transform.localPosition = transform.position + shakeOffset; // ��鸲 ȿ���� ī�޶� ��ġ �̵�
            NowShakeDuration -= Time.deltaTime; // ��鸲 ���� �ð� ����
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * CameraSpeed); // �̵� �� �̵�
        }
    }

    public void ShakeCamera()
    {
        NowShakeDuration = shakeDuration;
    }
}