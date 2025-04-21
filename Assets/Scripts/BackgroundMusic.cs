using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource music;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        music = GetComponent<AudioSource>();
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
