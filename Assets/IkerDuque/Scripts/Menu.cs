using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TMPro.TMP_InputField tiempoInput;
    public TMPro.TMP_InputField gemHorizontalInput;
    public TMPro.TMP_InputField gemVerticalInput;

    public static int tiempo;
    public static int gemVertical;
    public static int gemHorizontal;

    public void IniciarJuego()
    {
        tiempo = int.Parse(tiempoInput.text);
        gemVertical = int.Parse(gemVerticalInput.text);
        gemHorizontal = int.Parse(gemHorizontalInput.text);

        SceneManager.LoadScene("NivelJuego");

    }

}
