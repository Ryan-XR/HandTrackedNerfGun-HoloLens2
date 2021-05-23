using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartScript : MonoBehaviour
{

    Vector3 gunBarrelOffset = new Vector3(-0.13f, 0, 0.055f);

    float velocity = 25f;

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * velocity);

        transform.Translate(gunBarrelOffset);

        Destroy(gameObject, 3);
    }

}
