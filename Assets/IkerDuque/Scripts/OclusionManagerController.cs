using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class OclusionManagerController : MonoBehaviour
{
    private AROcclusionManager occlusionManager;

    void Start()
    {
        occlusionManager = FindObjectOfType<AROcclusionManager>();

        if (occlusionManager != null)
        {
            // Activar/desactivar oclusi�n seg�n el valor guardado en PlayerPrefs
            bool oclusionActiva = PlayerPrefs.GetInt("OclusionActivada", 0) == 1;
            occlusionManager.enabled = oclusionActiva;
        }
        else
        {
            Debug.LogWarning("No se encontr� un AROcclusionManager en la escena.");
        }
    }

    public void SetOclusion(bool isEnabled)
    {
        if (occlusionManager != null)
        {
            occlusionManager.enabled = isEnabled;

            // Guardar el estado en PlayerPrefs
            PlayerPrefs.SetInt("OclusionActivada", isEnabled ? 1 : 0);
        }
        else
        {
            Debug.LogWarning("No se encontr� un AROcclusionManager en la escena.");
        }
    }
}
