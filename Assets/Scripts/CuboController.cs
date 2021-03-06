using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount>0)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            pos.y = -3.5f;
            transform.position = pos;
        }
        

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (General.GetSegundos() > 0)
        {
            if (other.gameObject.tag == "Palomita")
            {
                General.SetNumPalomitasAtrapadas(General.GetNumPalomitasAtrapadas() + 1);
            }
            else
            {
                General.SetNumPalomitasAtrapadas(General.GetNumPalomitasAtrapadas() - 3);
            }

            Destroy(other.collider.gameObject);
        }
    }
}
