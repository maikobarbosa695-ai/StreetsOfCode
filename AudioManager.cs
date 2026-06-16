using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [System.Serializable]
    public class Som
    {
        public string nome;
        public AudioClip clip;
    }

    public List<Som> sons;
    public AudioSource sfxSource;
    public AudioSource musicSource;
    public AudioClip trilhaSonora;

    void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); return; }

        if (trilhaSonora != null)
        {
            musicSource.clip = trilhaSonora;
            musicSource.loop = true;
            musicSource.volume = 0.4f;
            musicSource.Play();
        }
    }

    public void PlaySFX(string nome)
    {
        Som s = sons.Find(x => x.nome == nome);
        if (s != null) sfxSource.PlayOneShot(s.clip);
    }
}
