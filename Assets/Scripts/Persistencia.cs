using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistencia : MonoBehaviour
{
    private GameObject mj1;
    private GameObject mj2;
    private GameObject mj3;
    private void Start()
    {
        mj1 = (GameObject)GameObject.FindGameObjectWithTag("mj1");
        mj2 = (GameObject)GameObject.FindGameObjectWithTag("mj2");
        mj3 = (GameObject)GameObject.FindGameObjectWithTag("mj3");

        if (mj1 != null)
        {
            if (ExisteRecord())
            {
                this.GetComponent<UIController>().SetRecord(GetRecord());
            }
            else
            {
                this.GetComponent<UIController>().BorrarRecord();
            }
        }
        if (mj2 != null)
        {
            if (ExisteRecord2())
            {
                this.GetComponent<UIController>().SetRecord(GetRecord2());
            }
            else
            {
                this.GetComponent<UIController>().BorrarRecord();
            }
        }
        if (mj3 != null)
        {
            if (ExisteRecord3())
            {
                this.GetComponent<UIController>().SetRecord(GetRecord3());
            }
            else
            {
                this.GetComponent<UIController>().BorrarRecord();
            }
        }

    }
    public int GetRecord()
    {
        return PlayerPrefs.GetInt("RECORD");
    }

    public void SetRecord(int r)
    {
        PlayerPrefs.SetInt("RECORD", r);
    }

    public bool ExisteRecord()
    {
        return PlayerPrefs.HasKey("RECORD");
    }

    public void DeleteRecord()
    {
        PlayerPrefs.DeleteKey("RECORD");
    }

    public int GetRecord2()
    {
        return PlayerPrefs.GetInt("RECORD2");
    }

    public void SetRecord2(int r)
    {
        PlayerPrefs.SetInt("RECORD2", r);
    }

    public bool ExisteRecord2()
    {
        return PlayerPrefs.HasKey("RECORD2");
    }

    public void DeleteRecord2()
    {
        PlayerPrefs.DeleteKey("RECORD2");
    }

    public int GetRecord3()
    {
        return PlayerPrefs.GetInt("RECORD3");
    }

    public void SetRecord3(int r)
    {
        PlayerPrefs.SetInt("RECORD3", r);
    }

    public bool ExisteRecord3()
    {
        return PlayerPrefs.HasKey("RECORD3");
    }

    public void DeleteRecord3()
    {
        PlayerPrefs.DeleteKey("RECORD3");
    }

    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }
}

