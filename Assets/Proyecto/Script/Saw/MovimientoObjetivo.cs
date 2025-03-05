using System;
using System.Collections;
using UnityEngine;

public class MovimientoObjetivo : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 posicionInicial;    // Posicion donde comienza la sierra
    [Header("Movimiento"), SerializeField, Tooltip("Duracion del movimiento en una direccion")]
    float tiempo = 1;
    [SerializeField, Tooltip("Posicion donde se va a mover la sierra")]
    Vector2 posicionFinal;
    Vector2 vectorDireccion;   //  La direccion donde se mueve la sierra
    bool direccion; //  Valor que nos dice a que direccion debe moverse el objeto
    Coroutine coroutine;

    private void Start()
    {
        //  Movimiento
        rb = GetComponent<Rigidbody2D>();
        posicionInicial = transform.position;
        vectorDireccion = posicionFinal - posicionInicial;

        //  Activar comportamiento
        Activar();
    }

    private void FixedUpdate() => rb.linearVelocity = direccion ? -vectorDireccion / tiempo : vectorDireccion / tiempo;

    IEnumerator CambiarDireccion()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempo);
            direccion = !direccion;
        }
    }

    private void Activar()
    {
        coroutine ??= StartCoroutine(nameof(CambiarDireccion));
    }

    private void Desactivar()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }
}
