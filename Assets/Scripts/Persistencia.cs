using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistencia : MonoBehaviour
{
    private void Start()
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

    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }
}
