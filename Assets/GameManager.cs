using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    public static GameManager Instance { get; private set; }

    public HUD hud;
    public int PuntosTotales {get { return puntosTotales;}}
    private int puntosTotales;
    private int vidas = 3;
    

    void Awake(){
        if(Instance == null){
            Instance = this;

        }
        else{
            Debug.Log("Mas de un Game Manager en escena!");
        }
    }
    public void SumarPuntos(int puntosASumar)
    {

        puntosTotales = puntosTotales + puntosASumar;
        hud.ActualizarPuntos(puntosTotales);
        
    }
    
    public void PerderVida(){
        vidas -= 1;
        hud.DesactivarVida(vidas);
    }

    public void RecuperarVida(){
        
        hud.ActivarVida(vidas);
        vidas += 1;
    }
}
