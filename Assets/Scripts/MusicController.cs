using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource music;
    public AudioClip aud_readyFight;
    public AudioClip aud_hit;
    public AudioClip aud_victory;
    //public AudioClip bgm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMusic(string name)
    {
        music.PlayOneShot(GetClip(name));
    }

    public IEnumerator WaitForMusicFinished(string name)
    {
        yield return new WaitForSeconds(GetClip(name).length);
        yield return null;
    }

    private AudioClip GetClip(string name)
    {
        switch (name)
        {
            case "readyFight": return aud_readyFight;
            case "hit":return aud_hit;
            //case "bgm":return bgm;
            case "victory":return aud_victory;
        }
        return null;
    }
}
