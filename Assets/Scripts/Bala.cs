using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 10f;      
    void Update()
    {        
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }
}

