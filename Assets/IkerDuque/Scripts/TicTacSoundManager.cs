using UnityEngine;

public class TicTacSoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource ticTacAudio; // Asigna el AudioSource desde el Inspector.
    private float tiempoRestante;

    void Start()
    {
        // Obt�n el tiempo configurado en el men� principal
        tiempoRestante = PlayerPrefs.GetInt("TiempoDeBusqueda");

        // Inicia el sonido en bucle
        if (ticTacAudio != null)
        {
            ticTacAudio.loop = true; // Aseg�rate de que el sonido se repita
            ticTacAudio.Play();
        }
    }

    void Update()
    {
        // Reduce el tiempo restante
        tiempoRestante -= Time.deltaTime;

        // Det�n el sonido cuando el tiempo se termine
        if (tiempoRestante <= 0 && ticTacAudio.isPlaying)
        {
            ticTacAudio.Stop();
        }
    }
}
