using UnityEngine;

public class Bala : MonoBehaviour
{
    private Rigidbody rb;
    public float bulletSpeed = 20f; 
    [SerializeField] private float torque = 50f; 

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * bulletSpeed, ForceMode.Impulse);
        rb.AddTorque(transform.up * torque, ForceMode.Impulse);
    }
    public void SetBulletSpeed(float speed)
    {
        bulletSpeed = speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            Destroy(gameObject);
        }
    }
}


