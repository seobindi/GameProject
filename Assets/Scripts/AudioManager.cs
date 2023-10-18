using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class AudioManager : MonoBehaviour
{
    //public static AudioManager instance; // �̱������� ���� �Ŀ� ����

    [SerializeField] Sound[] sfx = null;
    [SerializeField] Sound[] bgm = null;
    [SerializeField] AudioSource bgmPlayer = null;
    [SerializeField] AudioSource sfxPlayer = null;

    //private void Awake()
    //{
    //    instance = this;
    //}

    public void PlayBGM(string bgmName)
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            if (bgmName == bgm[i].name)
            {
                bgmPlayer.clip = bgm[i].clip;
                bgmPlayer.Play();
            }
        }
    }

    public void StopBGM()
    {
        bgmPlayer.Stop();
    }

    public void PlaySFX(string sfxName)
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            if (sfxName == sfx[i].name)
            {
                if (!sfxPlayer.isPlaying)
                {
                    sfxPlayer.clip = sfx[i].clip;
                    sfxPlayer.Play();
                    return;
                }
                else
                {
                    sfxPlayer.Stop();
                    sfxPlayer.clip = sfx[i].clip;
                    sfxPlayer.Play();
                    return;
                }
            }
        }
        Debug.Log("The name could not be found.");
        return;
    }

    //AudioManager.instance.PlayBGM("BGM0"); // BGM ����
}
