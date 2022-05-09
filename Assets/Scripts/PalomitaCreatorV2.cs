using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PalomitaCreatorV2 : MonoBehaviour
{
    public GameObject camara;
    public GameObject panel;

    public GameObject palomita;
    private GameObject palomitaClon;

    public GameObject palomitaRoja;
    private GameObject palomitaRojaClon;

    private float ancho;
    private float alto;
    private float margenVertical;
    private float margenHorizontal;

    private int palomitaRandom;

    private Vector3 posPalomitaWorld;
    // Start is called before the first frame update
    void Start()
    {
        margenVertical = 30.0f;
        margenHorizontal = 30.0f;
        InvokeRepeating("CrearPalomita", 3.0f, 0.4f);
    }


    public void CrearPalomita()
    {
        ancho = Random.Range(margenHorizontal, Screen.width - margenHorizontal);
        alto = Screen.height - margenVertical - (Screen.height + panel.GetComponent<RectTransform>().sizeDelta.y);

        posPalomitaWorld = camara.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(ancho, alto, camara.transform.position.z));
        posPalomitaWorld.z = 0.0f;

        palomitaRandom = Random.Range(0, 100);
        if (palomitaRandom <= 80)
        {
            palomitaClon = (GameObject)Instantiate(palomita, posPalomitaWorld, Quaternion.identity);
        }
        else
        {
            palomitaRojaClon = (GameObject)Instantiate(palomitaRoja, posPalomitaWorld, Quaternion.identity);
        }


        if (General.GetSegundos() <= 0)
        {
            CancelInvoke("CrearPalomita");
        }
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
