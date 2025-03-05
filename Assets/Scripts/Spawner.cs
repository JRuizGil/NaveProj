using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public GameObject asteroidePrefab;

    private void Start()
    {
        InstanciarObjeto();
    }

    void InstanciarObjeto()
    {
        GameObject objetoAInstanciar = Random.value > 0.5f ? enemigoPrefab : asteroidePrefab;
        Vector2 spawnPosition = ObtenerPosicionAleatoria();
        GameObject objeto = Instantiate(objetoAInstanciar, spawnPosition, Quaternion.identity);

        if (objeto.CompareTag("Asteroide"))
        {
            Asteroide asteroide = objeto.AddComponent<Asteroide>();
            asteroide.spawner = this; // Referencia para volver a instanciar al destruirse
        }
        else
        {
            Enemigo enemigo = objeto.AddComponent<Enemigo>();
            enemigo.spawner = this; // Referencia para volver a instanciar al destruirse
        }
    }

    Vector2 ObtenerPosicionAleatoria()
    {
        float x = Random.value > 0.5f ? Random.Range(-18f, -16f) : Random.Range(16f, 18f);
        float y = Random.value > 0.5f ? Random.Range(7f, 8f) : Random.Range(-8f, -7f);
        return new Vector2(x, y);
    }

    public void Reinstanciar()
    {
        InstanciarObjeto();
    }
}
