using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public GameObject asteroidePrefab;

    private GameObject objeto1;
    private GameObject objeto2;

    private void Start()
    {
        InstanciarObjetos();
    }
    void InstanciarObjetos()
    {
        objeto1 = InstanciarObjeto(enemigoPrefab);
        objeto2 = InstanciarObjeto(enemigoPrefab);
    }
    GameObject InstanciarObjeto(GameObject prefab)
    {
        Vector2 spawnPosition = ObtenerPosicionAleatoria();
        GameObject objeto = Instantiate(prefab, spawnPosition, Quaternion.identity);
        objeto.AddComponent<Respawn>().spawner = this;
        return objeto;
    }
    public void Reinstanciar(GameObject objetoDestruido)
    {
        if (objetoDestruido == objeto1)
        {
            objeto1 = InstanciarObjeto(enemigoPrefab);
        }
        else if (objetoDestruido == objeto2)
        {
            objeto2 = InstanciarObjeto(enemigoPrefab);
        }
    }
    Vector2 ObtenerPosicionAleatoria()
    {
        float x = Random.value > 0.5f ? Random.Range(-18f, -16f) : Random.Range(16f, 18f);
        float y = Random.value > 0.5f ? Random.Range(7f, 8f) : Random.Range(-8f, -7f);
        return new Vector2(x, y);
    }    
}