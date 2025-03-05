using UnityEngine;

// Esta clase representa una fuente de gravedad en el juego.
public class FuenteGravitatoria : MonoBehaviour
{
    public float masa = 10f;  // Define la masa de la fuente de gravedad.
    public float constanteG = 10f; // Define la constante gravitacional.

    // Se activa cuando el objeto se activa y lo agrega a la lista de fuentes gravitatorias.
    private void OnEnable()
    {
        CampoGravitatorio.fuentes.Add(this);
    }

    // Se activa cuando el objeto se desactiva y lo elimina de la lista de fuentes gravitatorias.
    private void OnDisable()
    {
        CampoGravitatorio.fuentes.Remove(this);
    }

    // Calcula la aceleraci�n gravitacional en una posici�n dada.
    public Vector3 CalcularAceleracion(Vector3 posicionReceptor)
    {
        Vector3 direccion = transform.position - posicionReceptor; //direcci�n hacia la fuente.
        float distancia = direccion.magnitude; //la distancia entre la fuente y el receptor.

        //f�rmula de la gravedad para calcular la aceleraci�n.
        float aceleracion = constanteG * masa / Mathf.Pow(distancia, 2);

        return direccion.normalized * aceleracion; //aceleraci�n en la direcci�n.
    }
}


