using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    private GameObject logo;

    public GameObject acumulador;
    public Text numPalomitas;
    public Text crono;
    public Text record;

    public GameObject panelFinal;
    public GameObject panelInicio;


    private void Awake()
    {
        logo = (GameObject)GameObject.FindGameObjectWithTag("Logo_Splash");
        if (logo != null)
        {
            Invoke("IrMenuPrincipal", 3.0f);
        }



    }

    public void SetNumPalomitas()
    {
        numPalomitas.text = "PALOMITAS:\n\n" + General.GetNumPalomitasDestruidas().ToString();
    }

    public void SetCrono()
    {
        crono.text = "TIMER:\n\n"+ General.GetSegundos().ToString();
    }

    public void SetRecord(int r)
    {
        record.text = "RECORD:\n\n" + r.ToString();
    }

    public void BorrarRecord()
    {
        record.text = "";
    }

    public void IrMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void IrMinijuego1()
    {
        SceneManager.LoadScene("Minijuego1");
    }
    public void IrMinijuego2()
    {
        SceneManager.LoadScene("Minijuego2");
    }
    public void IrMinijuego3()
    {
        SceneManager.LoadScene("Minijuego3");
    }
    // Start is called before the first frame update
    void Start()
    {
        General.SetSegundos(General.GetSegundosRestorer());
        General.SetSegundosInicio(General.GetSegundosInicioRestorer());
        if (panelInicio!=null) panelInicio.transform.GetChild(2).GetComponent<Text>().text = General.GetSegundosInicio().ToString();
        if (panelFinal!=null) {
          panelFinal.SetActive(false);
          InvokeRepeating("Crono", 4.0f, 1.0f);
          InvokeRepeating("CronoInicio", 1.0f, 1.0f);
        }
    }

    private void CronoInicio(){
        General.SetSegundosInicio(General.GetSegundosInicio()-1);
        panelInicio.transform.GetChild(2).GetComponent<Text>().text = General.GetSegundosInicio().ToString();
        if (General.GetSegundosInicio()<=0){
          CancelInvoke("CronoInicio");
          panelInicio.SetActive(false);
        }
    }

    private void Crono()
    {
        General.SetSegundos(General.GetSegundos()-1);
        this.GetComponent<UIController>().SetCrono();



        if (General.GetSegundos() <= 0)
        {
            panelFinal.SetActive(true);
            panelFinal.transform.GetChild(4).GetComponent<Text>().enabled = false;
            if (this.GetComponent<Persistencia>().ExisteRecord())
            {
                if (General.GetNumPalomitasDestruidas() > this.GetComponent<Persistencia>().GetRecord())
                {
                    this.GetComponent<Persistencia>().SetRecord(General.GetNumPalomitasDestruidas());
                    panelFinal.transform.GetChild(4).GetComponent<Text>().enabled = true;
                }
            }
            else
            {
                this.GetComponent<Persistencia>().SetRecord(General.GetNumPalomitasDestruidas());
                panelFinal.transform.GetChild(4).GetComponent<Text>().enabled = true;
            }
            CancelInvoke("Crono");
            panelFinal.transform.GetChild(3).GetComponent<Text>().text = "Palomitas:\n" + General.GetNumPalomitasDestruidas();


        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
