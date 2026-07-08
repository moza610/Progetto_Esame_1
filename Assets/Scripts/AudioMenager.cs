using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // l'audio source che fa partire la musica
    public AudioSource audioSource;

    // le 3 canzoni, le metto in ordine dentro Unity
    public AudioClip[] canzoni;

    // mi serve per ricordarmi a che canzone sono
    private int indice = 0;

    void Start()
    {
        // appena parte il gioco faccio partire la prima canzone
        audioSource.clip = canzoni[indice];
        audioSource.Play();
    }

    void Update()
    {
        // controllo ogni frame se la canzone è finita
        if (!audioSource.isPlaying)
        {
            // se è finita passo alla prossima
            indice++;

            // se ero all'ultima canzone torno alla prima (così non si blocca)
            if (indice >= canzoni.Length)
            {
                indice = 0;
            }

            // faccio partire la nuova canzone
            audioSource.clip = canzoni[indice];
            audioSource.Play();
        }
    }
}