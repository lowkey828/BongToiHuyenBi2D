using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource sfxApple;
    public AudioSource sfxJump;
    public AudioSource sfxDead;
    public AudioSource sfxBulletPlayer;
    public AudioSource sfxWin;

    public AudioClip appleClip;
    public AudioClip jumpClip;
    public AudioClip deadClip;
    public AudioClip bulletPlayer;
    public AudioClip winClip;

    void Start()
    {
        
    }

    public void PlayAppleSFX(AudioClip sfxClip)
    {
        sfxApple.clip = sfxClip;
        sfxApple.PlayOneShot(sfxClip);
    }

    public void PlayJumpSFX(AudioClip sfxClip)
    {
        sfxJump.clip = sfxClip;
        sfxJump.PlayOneShot(sfxClip);
    }

    public void PlayDead(AudioClip sfxClip)
    {
        sfxDead.clip = sfxClip;
        sfxDead.PlayOneShot(sfxClip);
    }

    public void PlayBullet(AudioClip sfxClip)
    {
        sfxBulletPlayer.clip = sfxClip;
        sfxBulletPlayer.PlayOneShot(sfxClip);
    }

    public void PlayWin(AudioClip sfxClip)
    {
        sfxWin.clip = sfxClip;
        sfxWin.PlayOneShot(sfxClip);
    }
}
