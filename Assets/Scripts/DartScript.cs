using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartScript : MonoBehaviour
{

    //private float velocity = 50f;

    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, 3);
    }

    private void Update()
    {
        //transform.Translate(0, 0, Time.deltaTime * velocity);
    }

}
