using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;

namespace UnityEngine.XR.ARFoundation.Samples
{
    [RequireComponent(typeof(ARRaycastManager))]
    [RequireComponent(typeof(ARPlaneManager))]
    public class PlaceOnPlane : PressInputBase
    {
        [SerializeField]
        [Tooltip("Prefabs disponibles para instanciar.")]
        List<GameObject> m_PrefabOptions;

        [SerializeField]
        [Tooltip("Texto para mostrar el número de planos detectados.")]
        TMPro.TextMeshProUGUI planeCountText;

        [SerializeField]
        [Tooltip("Botón para borrar prefabs instanciados.")]
        UnityEngine.UI.Button clearButton;

        private GameObject m_PlacedPrefab;
        public GameObject placedPrefab
        {
            get { return m_PlacedPrefab; }
            set { m_PlacedPrefab = value; }
        }

        private List<GameObject> spawnedObjects = new List<GameObject>();
        private ARRaycastManager m_RaycastManager;
        private ARPlaneManager m_PlaneManager;

        bool m_Pressed;

        protected override void Awake()
        {
            base.Awake();
            m_RaycastManager = GetComponent<ARRaycastManager>();
            m_PlaneManager = GetComponent<ARPlaneManager>();

            // Configurar botón Clear
            if (clearButton != null)
            {
                clearButton.onClick.AddListener(ClearSpawnedObjects);
            }

            // Configurar prefab inicial
            if (m_PrefabOptions.Count > 0)
            {
                m_PlacedPrefab = m_PrefabOptions[0];
            }
        }

        void Update()
        {
            UpdatePlaneCount();

            if (Pointer.current == null || !m_Pressed)
                return;

            var touchPosition = Pointer.current.position.ReadValue();

            if (m_RaycastManager.Raycast(touchPosition, s_Hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
            {
                var hitPose = s_Hits[0].pose;

                GameObject spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, hitPose.rotation);
                spawnedObjects.Add(spawnedObject);
            }
        }

        private void UpdatePlaneCount()
        {
            if (planeCountText != null)
            {
                planeCountText.text = $"Planos detectados: {m_PlaneManager.trackables.count}";
            }
        }

        public void ClearSpawnedObjects()
        {
            foreach (var obj in spawnedObjects)
            {
                Destroy(obj);
            }
            spawnedObjects.Clear();
        }

        public void SetPrefabToInstantiate(int prefabIndex)
        {
            if (prefabIndex >= 0 && prefabIndex < m_PrefabOptions.Count)
            {
                m_PlacedPrefab = m_PrefabOptions[prefabIndex];
            }
        }

        protected override void OnPress(Vector3 position) => m_Pressed = true;

        protected override void OnPressCancel() => m_Pressed = false;

        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
    }
}
