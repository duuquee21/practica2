using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdownTiempo;
    [SerializeField] private TMP_Dropdown dropdownVerticales;
    [SerializeField] private TMP_Dropdown dropdownHorizontales;
    [SerializeField] private Toggle toggleOclusion;

    private int tiempoDeBusqueda;
    private int gemasVerticales;
    private int gemasHorizontales;

    public void StartGame()
    {
        // Obtener valores seleccionados en los Dropdowns
        tiempoDeBusqueda = int.Parse(dropdownTiempo.options[dropdownTiempo.value].text);
        gemasVerticales = int.Parse(dropdownVerticales.options[dropdownVerticales.value].text);
        gemasHorizontales = int.Parse(dropdownHorizontales.options[dropdownHorizontales.value].text);

        // Guardar los valores seleccionados usando PlayerPrefs
        PlayerPrefs.SetInt("TiempoDeBusqueda", tiempoDeBusqueda);
        PlayerPrefs.SetInt("GemasVerticales", gemasVerticales);
        PlayerPrefs.SetInt("GemasHorizontales", gemasHorizontales);
        PlayerPrefs.SetInt("OclusionActivada", toggleOclusion.isOn ? 1 : 0);

        // Cambiar a la escena de juego
        SceneManager.LoadScene("NivelPrincipal");
    }
}
