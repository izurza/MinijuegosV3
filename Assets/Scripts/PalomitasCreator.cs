using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PalomitasCreator : MonoBehaviour
{
    public GameObject camara;
    public GameObject panel;

    private GameObject mj1;
    private GameObject mj2;
    private GameObject mj3;

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

        mj1 = (GameObject)GameObject.FindGameObjectWithTag("mj1");
        mj2 = (GameObject)GameObject.FindGameObjectWithTag("mj2");
        mj3 = (GameObject)GameObject.FindGameObjectWithTag("mj3");

        margenVertical = 30.0f;
        margenHorizontal = 30.0f;
        if (mj1 != null) InvokeRepeating("CrearPalomita", 3.0f, 0.4f);
        if (mj2 != null) InvokeRepeating("CrearPalomita2", 3.0f, 0.4f);
    }

    public void CrearPalomita()
    {
        ancho = Random.Range(margenHorizontal, Screen.width-margenHorizontal);
        alto = Random.Range(margenVertical, Screen.height-margenVertical-(Screen.height+panel.GetComponent<RectTransform>().sizeDelta.y));

        //Debug.Log(ancho + "--" + alto);
        posPalomitaWorld = camara.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(ancho, alto, camara.transform.position.z));
        posPalomitaWorld.z = 0.0f;

        palomitaRandom = Random.Range(0,100);
        if (palomitaRandom<=80){
          palomitaClon = (GameObject)Instantiate(palomita, posPalomitaWorld, Quaternion.identity);
        }
        else {
          palomitaRojaClon = (GameObject)Instantiate(palomitaRoja, posPalomitaWorld, Quaternion.identity);
        }



        if (General.GetSegundos() <= 0)
        {
            CancelInvoke("CrearPalomita");
        }
    }

    public void CrearPalomita2()
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
