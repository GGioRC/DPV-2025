using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyController : MonoBehaviour
{
    public MovimientoX movimientoX;

    [field: Header("Configuraciones colisiones"), Space(5f), SerializeField, Tooltip("La capa donde se van a detectar las colisiones para saber si un objeto esta en el piso o no")]
    LayerMask CapaPiso { get; set; }
    [field: SerializeField]
    Vector2 PosicionRayo { get; set; }
    [field: SerializeField]
    float DistanciaRayo { get; set; }

    bool Direccion { get; set; }

    void Start()
    {
        movimientoX = GetComponent<MovimientoX>();
        movimientoX.Acelerar();
        Direccion = false;
        movimientoX.CambiarDireccion(-1);
    }

    void Update()
    {
        movimientoX.MoverX();

        if (!EnPiso())
        {
            CambiarDireccion();
            return;
        }
    }

    public bool EnPiso()
    {
        Vector2 Inicio = new(Direccion ? transform.position.x + PosicionRayo.x : transform.position.x - PosicionRayo.x, transform.position.y - PosicionRayo.y);

        return Physics2D.Raycast(Inicio, Vector2.down, DistanciaRayo, CapaPiso);
    }

    public void CambiarDireccion()
    {
        Direccion = !Direccion;
        movimientoX.CambiarDireccion(Direccion ? 1 : -1);
    }

    void OnDrawGizmos()
    {
        Vector2 Inicio = new(Direccion ? transform.position.x + PosicionRayo.x : transform.position.x - PosicionRayo.x, transform.position.y - PosicionRayo.y);

        Debug.DrawRay(Inicio, Vector3.down * DistanciaRayo, Color.red, 0.0f);
    }

}
