using UnityEngine;
using System.Collections.Generic;

//Gestion de todas las fuentes gravitatorias en la escena.
public class CampoGravitatorio : MonoBehaviour
{
    public static List<FuenteGravitatoria> fuentes = new List<FuenteGravitatoria>(); //Lista de todas las fuentes de gravedad.

    
    private void Awake()
    {
        //Encuentra todas las fuentes gravitatorias en la escena y las añade a la lista.
        FuenteGravitatoria[] todasLasFuentes = FindObjectsByType<FuenteGravitatoria>(FindObjectsSortMode.None);
        fuentes.AddRange(todasLasFuentes);
    }
}
