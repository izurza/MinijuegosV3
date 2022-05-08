﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PalomitasCreator : MonoBehaviour
{
    public GameObject camara;
    public GameObject panel;
    public GameObject palomita;
    private GameObject palomitaClon;

    private float ancho;
    private float alto;
    private float margenVertical;
    private float margenHorizontal;


    private Vector3 posPalomitaWorld;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Screen.height + panel.GetComponent<RectTransform>().sizeDelta.y);
        margenVertical = 30.0f;
        margenHorizontal = 30.0f;
        InvokeRepeating("CrearPalomita", 3.0f, 0.4f);
    }

    public void CrearPalomita()
    {
        ancho = Random.Range(margenHorizontal, Screen.width-margenHorizontal);
        alto = Random.Range(margenVertical, Screen.height-margenVertical-(Screen.height+panel.GetComponent<RectTransform>().sizeDelta.y));
     
        //Debug.Log(ancho + "--" + alto);
        posPalomitaWorld = camara.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(ancho, alto, camara.transform.position.z));
        posPalomitaWorld.z = 0.0f;
        palomitaClon = (GameObject)Instantiate(palomita, posPalomitaWorld, Quaternion.identity);

        if (General.GetSegundos() <= 0)
        {
            CancelInvoke();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}