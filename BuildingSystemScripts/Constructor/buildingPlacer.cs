using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingPlacer : MonoBehaviour
{
    public List<GameObject> prefabsEdificios;
    public int indicePrefabActual = 0;

    private GameObject previsualizacionEdificio;

    public float suavidadMovimiento = 5f;
    public float velocidadRotacion = 120f; // Ajusta la velocidad de rotación según sea necesario
    private float rotacionContinua = 0f;

    public LayerMask capaTerreno; // Asigna la capa del terreno en el Inspector

    public EconomyVault economy;

    void Start()
    {
        CrearPrevisualizacionEdificio();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Clic izquierdo
        {
            InstanciarEdificioEnPosicionObtenida();
        }

        ActualizarPrevisualizacionEdificio();
        RotarPrevisualizacionContinua();
        CambiarPrefabConTeclas();
    }

    void CrearPrevisualizacionEdificio()
    {
        previsualizacionEdificio = Instantiate(prefabsEdificios[indicePrefabActual], Vector3.zero, Quaternion.identity);
        DesactivarComponentes(previsualizacionEdificio);
        previsualizacionEdificio.SetActive(false);
    }

    void ActualizarPrevisualizacionEdificio()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, capaTerreno))
        {
            Vector3 posicionInstancia = hit.point;

            // Solo suaviza el movimiento si la previsualización estaba activa
            if (previsualizacionEdificio.activeSelf)
            {
                SmoothMove(previsualizacionEdificio.transform, new Vector3(posicionInstancia.x, previsualizacionEdificio.transform.position.y, posicionInstancia.z));
            }
            else
            {
                previsualizacionEdificio.transform.position = new Vector3(posicionInstancia.x, previsualizacionEdificio.transform.position.y, posicionInstancia.z);
            }

            previsualizacionEdificio.SetActive(true);
        }
        else
        {
            previsualizacionEdificio.SetActive(false);
        }
    }

    void RotarPrevisualizacionContinua()
    {
        if (previsualizacionEdificio.activeSelf)
        {
            // Rotar continuamente al presionar 'R'
            if (Input.GetKey(KeyCode.R))
            {
                rotacionContinua += velocidadRotacion * Time.deltaTime;
                previsualizacionEdificio.transform.rotation = Quaternion.Euler(0f, rotacionContinua, 0f);
            }
            // Rotar continuamente en sentido contrario al presionar 'E'
            else if (Input.GetKey(KeyCode.E))
            {
                rotacionContinua -= velocidadRotacion * Time.deltaTime;
                previsualizacionEdificio.transform.rotation = Quaternion.Euler(0f, rotacionContinua, 0f);
            }
        }
    }

    void SmoothMove(Transform target, Vector3 destination)
    {
        target.position = Vector3.Lerp(target.position, destination, suavidadMovimiento * Time.deltaTime);
    }

    void InstanciarEdificioEnPosicionObtenida()
    {
        if (previsualizacionEdificio.activeSelf)
        {
            InstanciarEdificio(previsualizacionEdificio.transform.position, previsualizacionEdificio.transform.rotation);
        }
    }

    void InstanciarEdificio(Vector3 posicion, Quaternion rotacion)
    {
        if (prefabsEdificios.Count > 0 && indicePrefabActual < prefabsEdificios.Count)
        {
            GameObject prefabSeleccionado = prefabsEdificios[indicePrefabActual];
            Instantiate(prefabSeleccionado, posicion, rotacion);
            // Puedes agregar más configuraciones o lógica aquí según sea necesario
        }
        else
        {
            Debug.LogWarning("No hay prefabs de edificios disponibles.");
        }
    }

    void CambiarPrefabConTeclas()
    {
        for (int i = 0; i < prefabsEdificios.Count; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                CambiarPrefab(i);
                break;
            }
        }
    }

    void CambiarPrefab(int indice)
    {
        if (indice >= 0 && indice < prefabsEdificios.Count)
        {
            indicePrefabActual = indice;
            Debug.Log("Prefab actual: " + prefabsEdificios[indicePrefabActual].name);
            Destroy(previsualizacionEdificio);
            CrearPrevisualizacionEdificio();
        }
    }

    void DesactivarComponentes(GameObject objeto)
    {
        // Obtén todos los componentes en el objeto y desactívalos
        Component[] componentes = objeto.GetComponentsInChildren<Component>();

        foreach (var componente in componentes)
        {
            // Asegúrate de no desactivar el Transform, ya que es esencial
            if (!(componente is Transform))
            {
                // Desactiva el componente si es un Behaviour
                if (componente is Behaviour)
                {
                    (componente as Behaviour).enabled = false;
                }
            }
        }
    }


}
