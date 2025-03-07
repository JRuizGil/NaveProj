using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class RocketShip : MonoBehaviour
{
    public Rigidbody rb;

    public GameObject BalaPrfb;

    public Transform puntoDisparo;

    public Material Mat;

    public float torque = 2f;
    public float Maxtorque = 5f;

    public float speed = 10f;
    public float maxSpeed = 5f;

    public float currentTorque;
    public float currentSpeed;

    public void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        Mat = rend.material;
        rb = GetComponent<Rigidbody>();
        Mat.SetColor("_Color", Color.cyan);
        
    }
    void FixedUpdate()
    {
        Rotacion();
        Movimiento();
        LimitarValores();                
    }
    public void Update()
    {
        Disparo();
    }
    public void Rotacion()
    {
        float rotateZ = Input.GetAxis("Horizontal");        
        if (rb.angularVelocity.magnitude < Maxtorque)
        {
            rb.AddTorque(Vector3.forward * -rotateZ * torque);
        }
    }
    public void Movimiento()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 forceDirection = transform.up;            
            float speedInDirection = Vector3.Dot(rb.linearVelocity, forceDirection);            
            if (speedInDirection < maxSpeed)
            {
                rb.AddForce(forceDirection * speed, ForceMode.Force);
            }
        }
    }
    public void LimitarValores()
    {
        currentTorque = rb.angularVelocity.magnitude;
        currentSpeed = rb.linearVelocity.magnitude;

        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
        if (rb.angularVelocity.magnitude > Maxtorque)
        {
            rb.angularVelocity = rb.angularVelocity.normalized * Maxtorque;
        }
    }
    public void Disparo()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject nuevaBala = Instantiate(BalaPrfb, puntoDisparo.position, puntoDisparo.rotation);
            Bala scriptBala = nuevaBala.GetComponent<Bala>();
            scriptBala.SetBulletSpeed(speed);
        }        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            Mat.SetColor("_Color", Color.red);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            Mat.SetColor("_Color", Color.cyan);
        }
    }

}

