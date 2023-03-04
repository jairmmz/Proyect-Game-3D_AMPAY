using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashController : MonoBehaviour
{
	
	public GameObject trash;
	public Text txtPoints;
	public Text txtDuration;
	
	public float timeGame=500;
	
	int points = 0;

    // Update is called once per frame
    void Update(){
		
		timeGame -= Time.deltaTime;
		txtDuration.text = timeGame.ToString ("f0");
		
        if (Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f)){
                if (hit.transform != null){

                    Rigidbody rb;

                    if (rb = hit.transform.GetComponent<Rigidbody>()){                        
						CollectTrash(hit.transform.gameObject);
                    }
                }
            }
        }
    }
	
	private void CollectTrash(GameObject go){
		points++;
		txtPoints.text = "Puntos obtenidos: " + points;
		//print("Puntos: " + points);
		Destroy(go);
	}
}
