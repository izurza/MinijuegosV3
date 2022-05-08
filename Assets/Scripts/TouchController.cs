using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public GameObject imagenTouch;
    private GameObject[] clonImagenTouch;
    public GameObject camara;
    private Vector3 posTouch;


    private Ray rayo;
    private RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        clonImagenTouch = new GameObject[10];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {

            rayo = camara.GetComponent<Camera>().ScreenPointToRay(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, camara.transform.position.z));
            hit = Physics2D.GetRayIntersection(rayo, 10000);
            if (hit.collider != null)
            {
                if (General.GetSegundos() > 0)
                {
                    General.SetNumPalomitasDestruidas(General.GetNumPalomitasDestruidas() + 1);
                    this.GetComponent<UIController>().SetNumPalomitas();
                    Destroy(hit.collider.gameObject);
                }
                
            }



            for (int i = 0; i < Input.touchCount; i++)
            {
                switch (Input.GetTouch(i).phase)
                {
                    case TouchPhase.Began:
                        posTouch = camara.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.GetTouch(i).position.x, Input.GetTouch(i).position.y, camara.transform.position.z));
                        posTouch.z = 0.0f;
                        clonImagenTouch[i] = (GameObject)Instantiate(imagenTouch, posTouch, Quaternion.identity);
                        Debug.Log(i + "Began");
                        break;
                    case TouchPhase.Moved:
                        posTouch = camara.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.GetTouch(i).position.x, Input.GetTouch(i).position.y, camara.transform.position.z));
                        posTouch.z = 0.0f;
                        if (clonImagenTouch[i].gameObject != null)
                        {
                            clonImagenTouch[i].transform.position = posTouch;
                        }

                        Debug.Log(i + "Moved");
                        break;
                    case TouchPhase.Ended:
                        Destroy(clonImagenTouch[i].gameObject);
                        Debug.Log(i + "Ended");
                        break;

                }
            }
        }
    }
}
