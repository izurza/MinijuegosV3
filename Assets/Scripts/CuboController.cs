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
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Palomita")
        {
            Debug.Log("+1");
        }
        else
        {
            Debug.Log("-3");
        }
        Destroy(other.collider.gameObject);
    }
}
