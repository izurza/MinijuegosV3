using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    private GameObject logo;
    private GameObject mj1;
    private GameObject mj2;
    private GameObject mj3;

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

    public void SetNumPalomitas2()
    {
        numPalomitas.text = "PALOMITAS:\n\n" + General.GetNumPalomitasAtrapadas().ToString();
    }

    public void SetCrono()
    {
        crono.text = "TIMER:\n\n"+ General.GetSegundos().ToString();
    }
    public void SetCrono3()
    {
        crono.text = "TIMER:\n\n" + General.GetTimer().ToString();
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
        mj1 = (GameObject)GameObject.FindGameObjectWithTag("mj1");
        mj2 = (GameObject)GameObject.FindGameObjectWithTag("mj2");
        mj3 = (GameObject)GameObject.FindGameObjectWithTag("mj3");
        this.GetComponent<Persistencia>().DeleteAll();
        if (mj1!=null || mj2 != null)
        {
            General.SetSegundos(General.GetSegundosRestorer());
            General.SetSegundosInicio(General.GetSegundosInicioRestorer());
            General.ResetPalomitas();
        }
        if (mj3 != null)
        {
            General.SetTimer(General.GetTimerRestorer());
            General.ResetWin();
        }
       
        if (panelInicio!=null) panelInicio.transform.GetChild(2).GetComponent<Text>().text = General.GetSegundosInicio().ToString();

        if (panelFinal != null)
        {
            panelFinal.SetActive(false);

            InvokeRepeating("CronoInicio", 1.0f, 1.0f);
            if (mj1 != null) InvokeRepeating("Crono1", 4.0f, 1.0f);
            if (mj2 != null) InvokeRepeating("Crono2", 4.0f, 1.0f);
            if (mj3 != null) InvokeRepeating("Crono3", 4.0f, 1.0f);
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

    private void Crono1()
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
            CancelInvoke("Crono1");
            panelFinal.transform.GetChild(3).GetComponent<Text>().text = "Palomitas:\n" + General.GetNumPalomitasDestruidas();


        }
    }

    private void Crono2()
    {
        General.SetSegundos(General.GetSegundos() - 1);
        this.GetComponent<UIController>().SetCrono();



        if (General.GetSegundos() <= 0)
        {
            panelFinal.SetActive(true);
            panelFinal.transform.GetChild(4).GetComponent<Text>().enabled = false;
            if (this.GetComponent<Persistencia>().ExisteRecord2())
            {
                if (General.GetNumPalomitasAtrapadas() > this.GetComponent<Persistencia>().GetRecord2())
                {
                    this.GetComponent<Persistencia>().SetRecord2(General.GetNumPalomitasAtrapadas());
                    panelFinal.transform.GetChild(4).GetComponent<Text>().enabled = true;
                }
            }
            else
            {
                this.GetComponent<Persistencia>().SetRecord2(General.GetNumPalomitasAtrapadas());
                panelFinal.transform.GetChild(4).GetComponent<Text>().enabled = true;
            }
            CancelInvoke("Crono2");
            panelFinal.transform.GetChild(3).GetComponent<Text>().text = "Palomitas:\n" + General.GetNumPalomitasAtrapadas();


        }
    }

    private void Crono3()
    {
        General.SetTimer(General.GetTimer() + 1);
        this.GetComponent<UIController>().SetCrono3();



        if (General.GetWin())
        {
            panelFinal.SetActive(true);
            panelFinal.transform.GetChild(4).GetComponent<Text>().enabled = false;
            if (this.GetComponent<Persistencia>().ExisteRecord3())
            {
                if (General.GetTimer() < this.GetComponent<Persistencia>().GetRecord3())
                {
                    this.GetComponent<Persistencia>().SetRecord3(General.GetTimer());
                    panelFinal.transform.GetChild(4).GetComponent<Text>().enabled = true;
                }
            }
            else
            {
                this.GetComponent<Persistencia>().SetRecord3(General.GetTimer());
                panelFinal.transform.GetChild(4).GetComponent<Text>().enabled = true;
            }
            CancelInvoke("Crono3");
            panelFinal.transform.GetChild(3).GetComponent<Text>().text = "Tiempo:\n" + General.GetTimer();


        }
    }


    // Update is called once per frame
    void Update()
    {
        if (mj2 != null) SetNumPalomitas2();
    }
}
