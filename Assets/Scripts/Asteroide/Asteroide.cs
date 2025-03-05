using UnityEngine;

public class Asteroide : MonoBehaviour
{
    public Vector3 direccion = Vector3.left;
    public float velocidad = 5f;
    private Camera cam;
    public Spawner spawner;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        transform.position += direccion.normalized * velocidad * Time.deltaTime;        
        if (!DentroDeLaPantalla())
        {
            DestruirAsteroide();
        }
    }
    bool DentroDeLaPantalla()
    {
        Vector3 posEnPantalla = cam.WorldToViewportPoint(transform.position);
        return posEnPantalla.x >= -0.1f && posEnPantalla.x <= 1.1f &&
               posEnPantalla.y >= -0.1f && posEnPantalla.y <= 1.1f;
    }
    private void DestruirAsteroide()
    {        
        Destroy(gameObject);
    }
}
