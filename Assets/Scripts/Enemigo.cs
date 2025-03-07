using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float velocidad = 5f;
    public float amplitudOscilacion = 1f; 
    public float frecuenciaOscilacion = 2f; 
    public Spawner spawner;

    private Vector3 direccion;
    private Vector3 ejeOscilacion;
    private Camera cam;
    private float tiempoInicio;

    void Start()
    {
        cam = Camera.main;
        tiempoInicio = Time.time;
        
        direccion = new Vector3(-transform.position.x, -transform.position.y, 0).normalized;
        
        ejeOscilacion = new Vector3(-direccion.y, direccion.x, 0).normalized;
    }

    private void FixedUpdate()
    {
        
        Vector3 movimientoLineal = direccion * velocidad * Time.deltaTime;        
        float desplazamientoOscilatorio = Mathf.Sin((Time.time - tiempoInicio) * frecuenciaOscilacion) * amplitudOscilacion;
        Vector3 movimientoOscilatorio = ejeOscilacion * desplazamientoOscilatorio;        
        transform.position += movimientoLineal + movimientoOscilatorio * Time.deltaTime;
    }

    private void Update()
    {
        if (!DentroDeLaPantalla())
        {
            spawner.Reinstanciar(gameObject);
        }
    }

    bool DentroDeLaPantalla()
    {
        Vector3 posEnPantalla = cam.WorldToViewportPoint(transform.position);
        return posEnPantalla.x >= -0.1f && posEnPantalla.x <= 1.1f &&
               posEnPantalla.y >= -0.1f && posEnPantalla.y <= 1.1f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            Destroy(collision.gameObject);
            spawner.Reinstanciar(gameObject);
        }
    }
}
