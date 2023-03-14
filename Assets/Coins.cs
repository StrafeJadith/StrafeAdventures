using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int valor = 1;
    
    

    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameManager.Instance.SumarPuntos(valor);
        Destroy(this.gameObject);
    }
}
