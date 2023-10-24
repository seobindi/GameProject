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
    [SerializeField] AudioSource[] sfxPlayer = null;

    //private void Awake()
    //{
    //    instance = this;
    //}
    private void Start()
    {
        PlayBGM("80BPM"); // BGM ����
    }
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
                for (int j = 0; j < sfxPlayer.Length; j++)
                {
<<<<<<< Updated upstream
=======
                    // SFXPlayer���� ��� ������ ���� Audio Source�� �߰��ߴٸ� 
>>>>>>> Stashed changes
                    if (!sfxPlayer[j].isPlaying)
                    {
                        sfxPlayer[j].clip = sfx[i].clip;
                        sfxPlayer[j].Play();
                        return;
                    }
                }
<<<<<<< Updated upstream
                Debug.Log("All audio is in use.");
                return;
=======
                Debug.Log("��� ����� �÷��̾ ������Դϴ�.");
                return;

                //if (!sfxPlayer.isPlaying)
                //{
                //    sfxPlayer.clip = sfx[i].clip;
                //    sfxPlayer.Play();
                //    return;
                //}
                //else
                //{
                //    sfxPlayer.Stop();
                //    sfxPlayer.clip = sfx[i].clip;
                //    sfxPlayer.Play();
                //    return;
                //}
>>>>>>> Stashed changes
            }
        }
        Debug.Log("The name could not be found.");
        return;
    }
}