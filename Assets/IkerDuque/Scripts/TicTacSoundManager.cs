using UnityEngine;

public class TicTacSoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource ticTacAudio; // Asigna el AudioSource desde el Inspector.
    private float tiempoRestante;

    void Start()
    {
        // Obtén el tiempo configurado en el menú principal
        tiempoRestante = PlayerPrefs.GetInt("TiempoDeBusqueda");

        // Inicia el sonido en bucle
        if (ticTacAudio != null)
        {
            ticTacAudio.loop = true; // Asegúrate de que el sonido se repita
            ticTacAudio.Play();
        }
    }

    void Update()
    {
        // Reduce el tiempo restante
        tiempoRestante -= Time.deltaTime;

        // Detén el sonido cuando el tiempo se termine
        if (tiempoRestante <= 0 && ticTacAudio.isPlaying)
        {
            ticTacAudio.Stop();
        }
    }
}
