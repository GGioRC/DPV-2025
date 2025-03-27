using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovimientoY : MonoBehaviour
{
    Rigidbody2D Rigidbody { get; set; }

    [field: Header("Configuraciones colisiones"), Space(5f), SerializeField, Tooltip("La capa donde se van a detectar las colisiones para saber si un objeto esta en el piso o no")]
    LayerMask CapaPiso { get; set; }
    [field: SerializeField]
    Vector2 PosicionRayo { get; set; }
    [field: SerializeField]
    float DistanciaRayo { get; set; }

    RaycastHit2D PieDerecho { get; set; }
    RaycastHit2D PieIzquierdo { get; set; }

    [field: Header("Configuraciones salto"), Space(5f), SerializeField]
    float FuerzaSalto { get; set; }


    void Awake() => Rigidbody = GetComponent<Rigidbody2D>();

    public bool EnPiso()
    {
        Vector2 InicioDerecho = new(transform.position.x + PosicionRayo.x, transform.position.y - PosicionRayo.y);
        Vector2 InicioIzquierdo = new(transform.position.x - PosicionRayo.x, transform.position.y - PosicionRayo.y);

        PieDerecho = Physics2D.Raycast(InicioDerecho, Vector2.down, DistanciaRayo, CapaPiso);
        PieIzquierdo = Physics2D.Raycast(InicioIzquierdo, Vector2.down, DistanciaRayo, CapaPiso);

        return PieDerecho || PieIzquierdo;
    }

    public void Saltar() => Rigidbody.AddForceY(FuerzaSalto, ForceMode2D.Impulse);

    void OnDrawGizmos()
    {
        Vector2 InicioDerecho = new(transform.position.x + PosicionRayo.x, transform.position.y - PosicionRayo.y);
        Vector2 InicioIzquierdo = new(transform.position.x - PosicionRayo.x, transform.position.y - PosicionRayo.y);

        Debug.DrawRay(InicioDerecho, Vector3.down * DistanciaRayo, Color.red, 0.0f);
        Debug.DrawRay(InicioIzquierdo, Vector3.down * DistanciaRayo, Color.red, 0.0f);
    }
}
