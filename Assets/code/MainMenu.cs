using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void EscenaJuego(){
		SceneManager.LoadScene("SampleScene");
	}
	
	public void EscenaAbout(){
		SceneManager.LoadScene("about");
	}
	
	public void VolverMenu(){
		SceneManager.LoadScene("Menu");
	}
	
    // Cierra la aplicación
    public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
