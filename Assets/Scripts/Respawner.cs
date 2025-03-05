
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Spawner spawner;

    private void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.Reinstanciar(gameObject);
        }
    }
}
