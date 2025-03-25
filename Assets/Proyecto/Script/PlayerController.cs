using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public MovimientoX movimientoX;

    void Start()
    {
        movimientoX = GetComponent<MovimientoX>();
    }

    void Update()
    {
        movimientoX.MoverX();
    }

    public void Mover(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Iniciando");
            movimientoX.Acelerar();
        }
        if (context.performed)
        {
            Debug.Log("Manteniendo");
            Vector2 direccion = context.ReadValue<Vector2>();
            movimientoX.CambiarDireccion(direccion.x);
        }
        if(context.canceled)
        {
            Debug.Log("Terminado");
            movimientoX.Desacelerar();
            movimientoX.CambiarDireccion(0f);
        }
    }
}
