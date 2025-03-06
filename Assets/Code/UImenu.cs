using UnityEngine;

public class UImenu : MonoBehaviour
{
    AudioManager audioManager;

    void Start()
    {
        audioManager.PlayWin(audioManager.winClip);
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
}
