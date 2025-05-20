using UnityEngine;

public class Gema : MonoBehaviour
{
    private JuegoUIManager uiManager;
    [SerializeField] private AudioClip sonidoRecoleccion; // Clip de sonido para recolectar
    private AudioSource audioSource;

    private void Awake()
    {
        // Añadir un AudioSource si no existe
        if (TryGetComponent(out AudioSource source))
        {
            audioSource = source;
        }
        else
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Configurar el AudioSource
        audioSource.playOnAwake = false;
    }

    public void SetUIManager(JuegoUIManager manager)
    {
        uiManager = manager;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el jugador tenga la etiqueta "Player"
        {
            // Reproducir sonido si se ha asignado un clip
            if (sonidoRecoleccion != null)
            {
                audioSource.PlayOneShot(sonidoRecoleccion);
            }

            uiManager.RecolectarGema();
            Destroy(gameObject, sonidoRecoleccion != null ? sonidoRecoleccion.length : 0f); // Destruir tras el sonido
        }
    }
}
