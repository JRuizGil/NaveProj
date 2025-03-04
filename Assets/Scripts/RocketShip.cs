using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class RocketShip : MonoBehaviour
{
    [SerializeField] public Rigidbody rb;

    [SerializeField] public GameObject Bala;

    [SerializeField] public Transform puntoDisparo;

    [SerializeField] public Material Mat;

    [SerializeField] public float torque = 2f;
    [SerializeField] public float Maxtorque = 5f;

    [SerializeField] public float speed = 10f;
    [SerializeField] public float maxSpeed = 5f;

    [SerializeField] public float currentTorque;
    [SerializeField] public float currentSpeed;



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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Disparo();
        }
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
        if (Bala != null && puntoDisparo != null)
        {            
            GameObject nuevaBala = Instantiate(Bala, puntoDisparo.position, puntoDisparo.rotation);            
            Rigidbody rb = nuevaBala.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(puntoDisparo.forward);
            }
        }
    }
}

