using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controles : MonoBehaviour
{
    public Camera mainCamera;
    public List<Entidad> entidadesEncontradas = new List<Entidad>();

    void Start()
    {
        Entidad[] entidades = FindObjectsOfType<Entidad>();
        entidadesEncontradas.Capacity = entidades.Length;

        foreach (Entidad entidad in entidades)
        {
            entidadesEncontradas.Add(entidad);
        }
    }

    private void Update()
    {
        selectCharacter();
    }

    public void selectCharacter()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector3.zero, 100);

            if (hit.collider != null)
            {
                desselecionarEntidades();
                Entidad entidad = hit.collider.GetComponentInParent<Entidad>();
                Debug.Log("Entidad detectada");

                if (entidad != null)
                {
                    SpriteRenderer spriteRenderer = entidad.GetComponentInChildren<SpriteRenderer>();
                    entidad.seleccionado = true;
                    spriteRenderer.color = Color.green;
                    Debug.Log("Personaje seleccionado: " + entidad.gameObject.name);
                }
                else
                {
                    Debug.Log("Seleccionada no accesible");
                }
            }
            else
            {
                Debug.Log("No hay colision");
                desselecionarEntidades();
            }
        }
    }

    public void desselecionarEntidades()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (var entidad in entidadesEncontradas)
            {
                entidad.seleccionado = false;
                SpriteRenderer spriteRenderer = entidad.GetComponentInChildren<SpriteRenderer>();
                spriteRenderer.color = Color.white;
            }
        }
    }
}
