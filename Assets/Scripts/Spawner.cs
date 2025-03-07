using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public GameObject asteroidePrefab;

    private GameObject _enemigo;
    private GameObject _asteroide;

    private void Start()
    {
        InstanciarObjetos();
    }

    void InstanciarObjetos()
    {
        _enemigo = InstanciarObjeto(enemigoPrefab);
        _asteroide = InstanciarObjeto(asteroidePrefab);
    }

    GameObject InstanciarObjeto(GameObject prefab)
    {
        Vector2 spawnPosition = ObtenerPosicionAleatoria();
        GameObject objeto = Instantiate(prefab, spawnPosition, Quaternion.identity);
        
        if (objeto.TryGetComponent<Asteroide>(out Asteroide asteroide))
        {
            asteroide.spawner = this;
        }
        if (objeto.TryGetComponent<Enemigo>(out Enemigo enemigo))
        {
            enemigo.spawner = this;
        }

        return objeto;
    }
    public void Reinstanciar(GameObject objeto)
    {
        objeto.transform.position = ObtenerPosicionAleatoria();

        
        if (objeto.TryGetComponent<Asteroide>(out Asteroide asteroide))
        {
            asteroide.spawner = this;
            asteroide.RecalcularDireccion();
        }

        objeto.SetActive(true);
    }
    Vector2 ObtenerPosicionAleatoria()
    {
        float x = Random.value > 0.5f ? Random.Range(-18f, -16f) : Random.Range(16f, 18f);
        float y = Random.value > 0.5f ? Random.Range(7f, 8f) : Random.Range(-8f, -7f);
        return new Vector2(x, y);
    }

}
