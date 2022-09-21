using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioClip pickUpSound1, pickUpSound2;

    [SerializeField]
    private AudioClip destorySound1, destorySound2;

    [SerializeField]
    private AudioClip hitSound1, hitSound2;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void PlayPickUpSound()
    {
        if (Random.Range(0, 2) > 0)
            AudioSource.PlayClipAtPoint(pickUpSound1, transform.position);
        else
            AudioSource.PlayClipAtPoint(pickUpSound2, transform.position);
    }

    public void PlayDestorySound()
    {
        if (Random.Range(0, 2) > 0)
            AudioSource.PlayClipAtPoint(destorySound1, transform.position);
        else
            AudioSource.PlayClipAtPoint(destorySound2, transform.position);
    }

    public void PlayHitSound()
    {
        if (Random.Range(0, 2) > 0)
            AudioSource.PlayClipAtPoint(hitSound1, transform.position);
        else
            AudioSource.PlayClipAtPoint(hitSound2, transform.position);
    }

}
