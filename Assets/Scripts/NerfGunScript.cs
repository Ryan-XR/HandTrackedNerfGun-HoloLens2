using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NerfGunScript : MonoBehaviour
{

    public bool canShoot = false;
    public bool automatic = true;

    private float shotDelta = 0.15f;

    public GameObject dart;

    Rigidbody projectile;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        projectile = dart.GetComponent<Rigidbody>();
    }

    public void FireDart(Vector3 position)
    {
        if (canShoot)
        {

            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();

            Rigidbody clone;
            clone = Instantiate(projectile, transform.position, transform.rotation);

            canShoot = false;

            // delay next dart shot
            StartCoroutine(ResetCanShoot());
        }
    }

    IEnumerator ResetCanShoot()
    {
        yield return new WaitForSeconds(shotDelta);
        canShoot = true;
    }
}
