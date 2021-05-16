using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NerfGunScript : MonoBehaviour
{

    public bool canShoot = false;
    public bool automatic = true;

    private float shotDelta = 0.15f;

    public Rigidbody projectile;

    public GameObject dart;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireDart(Vector3 position)
    {
        if (canShoot)
        {
            // instantiate new bullet
            //GameObject firedDart = Instantiate(dart, position, Quaternion.identity);

            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();

            Rigidbody clone;

            clone = Instantiate(projectile, transform.position, transform.rotation);
            clone.transform.Translate(new Vector3(-0.13f, 0, 0.055f));
            clone.velocity = transform.TransformDirection(Vector3.left * 25);

            // set canShoot to false
            canShoot = false;

            // call function to set canShoot to true after X seconds
            StartCoroutine(ResetCanShoot());
        }
    }

    IEnumerator ResetCanShoot()
    {
        yield return new WaitForSeconds(shotDelta);

        // Code to execute after the delay
        canShoot = true;
    }
}
