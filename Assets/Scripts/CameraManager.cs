using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform Target;
    public float CameraSpeed;
    public float shakeDuration = 0.1f; // 흔들림 지속 시간
    public float shakeSpeed = 0.5f; // 흔들림의 세기

    private float NowShakeDuration;

    //카메라 움직임
    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);

        if (NowShakeDuration > 0)
        {
            Vector3 shakeOffset = Random.insideUnitSphere * shakeSpeed; // 랜덤한 위치 벡터 생성
            transform.localPosition = transform.position + shakeOffset; // 흔들림 효과로 카메라 위치 이동

            NowShakeDuration -= Time.deltaTime; // 흔들림 지속 시간 감소
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
