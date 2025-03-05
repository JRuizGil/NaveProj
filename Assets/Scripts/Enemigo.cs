using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 startPos;
    private float freqX, freqY, ampX, ampY;
    private float timeOffset;

    public Spawner spawner;  

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;

        GetComponent<BoxCollider>().isTrigger = true;

        startPos = transform.position;

        freqX = Random.Range(0.5f, 2f);
        freqY = Random.Range(0.5f, 2f);
        ampX = Random.Range(0.5f, 2f);
        ampY = Random.Range(0.5f, 2f);
        timeOffset = Random.Range(0f, Mathf.PI * 2);
    }

    private void FixedUpdate()
    {
        float newX = startPos.x + Mathf.Sin(Time.time * freqX + timeOffset) * ampX;
        float newY = startPos.y + Mathf.Sin(Time.time * freqY + timeOffset) * ampY;
        transform.position = new Vector3(newX, newY, startPos.z);
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
