using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform Target;
    public float CameraSpeed;
    public float shakeDuration = 0.1f; // ��鸲 ���� �ð�
    public float shakeSpeed = 0.5f; // ��鸲�� ����

    private float NowShakeDuration;

    //ī�޶� ������
    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);

        if (NowShakeDuration > 0)
        {
            Vector3 shakeOffset = Random.insideUnitSphere * shakeSpeed; // ������ ��ġ ���� ����
            transform.localPosition = transform.position + shakeOffset; // ��鸲 ȿ���� ī�޶� ��ġ �̵�

            NowShakeDuration -= Time.deltaTime; // ��鸲 ���� �ð� ����
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * CameraSpeed);
        }

    }

    public void ShakeCamera()
    {
        NowShakeDuration = shakeDuration;
    }
}
