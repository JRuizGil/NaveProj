using UnityEngine;

public class Asteroide : MonoBehaviour
{
    public float velocidad = 5f;
    private Camera cam;
    public Spawner spawner;
    private Vector3 direccion;

    void Start()
    {
        cam = Camera.main;
        direccion = new Vector3(-transform.position.x, -transform.position.y, 0).normalized;
    }
    void Update()
    {
        if (!DentroDeLaPantalla())
        {
            spawner.Reinstanciar(gameObject); 
        }
    }
    private void FixedUpdate()
    {
        transform.position += direccion * velocidad * Time.deltaTime;

    }
    bool DentroDeLaPantalla()
    {
        Vector3 posEnPantalla = cam.WorldToViewportPoint(transform.position);
        return posEnPantalla.x >= -0.1f && posEnPantalla.x <= 1.1f &&
               posEnPantalla.y >= -0.1f && posEnPantalla.y <= 1.1f;
    }
    public void RecalcularDireccion()
    {
        direccion = new Vector3(-transform.position.x, -transform.position.y, 0).normalized;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            Destroy(collision.gameObject); 
            spawner.Reinstanciar(gameObject); 
        }
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
}
