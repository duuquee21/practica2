using UnityEngine;
using UnityEngine.XR.ARSubsystems;

public class Juego : MonoBehaviour
{
    public GameObject gemaPrefab; // Prefab de la gema

    void Start()
    {
        // Generar gemas verticales
        for (int i = 0; i < Menu.gemVertical; i++)
        {
            Vector3 posicion = new Vector3(0, i * 2, 0); // Cambia según tu diseño
            Instantiate(gemaPrefab, posicion, Quaternion.identity);
        }

        // Generar gemas horizontales
        for (int i = 0; i < Menu.gemHorizontal; i++)
        {
            Vector3 posicion = new Vector3(i * 2, 0, 0); // Cambia según tu diseño
            Instantiate(gemaPrefab, posicion, Quaternion.identity);
        }

        // Iniciar temporizador
        StartCoroutine(Temporizador(Menu.tiempo));
    }

    private System.Collections.IEnumerator Temporizador(int tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        Debug.Log("Tiempo finalizado");
        // Lógica para finalizar el juego
    }
}
