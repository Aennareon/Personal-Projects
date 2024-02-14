using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Camera : MonoBehaviour
{
    public List<Camera> cameras;
    private int currentCameraIndex = 0;

    public float moveSpeed = 5f;
    public float zoomSpeed = 5f;
    public float maxZoom = 5f;
    public float minZoom = 15f;
    public float edgeScrollingSpeed = 5f;

    private UniversalAdditionalCameraData cameraData;

    void Start()
    {
        if (cameras.Count > 0)
        {
            for (int i = 0; i < cameras.Count; i++)
            {
                cameras[i].gameObject.SetActive(false);
            }
            cameras[currentCameraIndex].gameObject.SetActive(true);

            if (cameras[currentCameraIndex].orthographic)
            {
                cameraData = cameras[currentCameraIndex].GetComponent<UniversalAdditionalCameraData>();
                if (cameraData == null)
                {
                    Debug.LogError("UniversalAdditionalCameraData not found on main camera.");
                }
            }
            else
            {
                Debug.LogError("Main camera is not orthographic.");
            }
        }
    }

    void Update()
    {
        // Cambiar de cámara si se presiona la tecla C
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera();
        }

        // Movimiento de la cámara con las teclas WASD
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Acercamiento y alejamiento de la cámara con la rueda del ratón
        if (cameraData != null)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            float newSize = cameraData.cameraSize - scroll * zoomSpeed * Time.deltaTime;
            cameraData.cameraSize = Mathf.Clamp(newSize, maxZoom, minZoom);
        }

        // Movimiento de la cámara al acercarse a los bordes de la pantalla
        Vector3 mousePosition = Input.mousePosition;
        Vector3 moveVector = Vector3.zero;

        if (mousePosition.x <= 0)
            moveVector.x = -1;
        else if (mousePosition.x >= Screen.width - 1)
            moveVector.x = 1;

        if (mousePosition.y <= 0)
            moveVector.y = -1;
        else if (mousePosition.y >= Screen.height - 1)
            moveVector.y = 1;

        // Aplicar movimiento de desplazamiento
        transform.Translate(moveVector * edgeScrollingSpeed * Time.deltaTime);
    }

    void SwitchCamera()
    {
        // Desactivar la cámara actual
        cameras[currentCameraIndex].gameObject.SetActive(false);

        // Avanzar al siguiente índice de la lista, si es el último, volver al primero
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Count;

        // Activar la nueva cámara
        cameras[currentCameraIndex].gameObject.SetActive(true);

        // Actualizar el componente UniversalAdditionalCameraData
        if (cameras[currentCameraIndex].orthographic)
        {
            cameraData = cameras[currentCameraIndex].GetComponent<UniversalAdditionalCameraData>();
            if (cameraData == null)
            {
                Debug.LogError("UniversalAdditionalCameraData not found on main camera.");
            }
        }
        else
        {
            Debug.LogError("Main camera is not orthographic.");
        }
    }
}
