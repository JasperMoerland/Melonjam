using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource hit, charm, walk, gameOver, song1, song2;
    public void Hit()
    {
        hit.Play();
    }
    public void Charm()
    {
        charm.Play();
    }
    public void StartWalk()
    {
        walk.Play();
    }
    public void StopWalk()
    {
        walk.Stop();
    }
    public void GameOver()
    {
        gameOver.Play();
    }
    private void Start()
    {
        StartCoroutine(Songs());
    }
    private IEnumerator Songs()
    {
        while (true)
        {
            song1.Play();
            yield return new WaitForSeconds(song1.clip.samples / song1.clip.frequency + 1);
            song2.Play();
            yield return new WaitForSeconds(song2.clip.samples / song2.clip.frequency + 1);

        }
    }
}
