using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovimientoX : MonoBehaviour
{
    Rigidbody2D Rigidbody { get; set; }

    [field: SerializeField] float VelocidadMaxima { get; set; }
    float VelocidadActual { get; set; }
    float DireccionX { get; set; }

    void Awake() => Rigidbody = GetComponent<Rigidbody2D>();

    public void CambiarDireccion(float direccionX) => DireccionX = direccionX;
    public void Desacelerar() => VelocidadActual = 0;
    public void Acelerar() => VelocidadActual = VelocidadMaxima;

    public void MoverX() => Rigidbody.linearVelocityX = VelocidadActual * DireccionX;
}
