using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 destination;
    private bool isShooting;

    public float fireRate = 0.2f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    public AudioSource shootSFX;

    void Start()
    {
        isShooting = true;
    }

    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // di chuyen nhan vat
        if (Input.GetMouseButton(0))
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector3.Lerp(transform.position, new Vector3(destination.x, destination.y, transform.position.z), 0.1f);
        }
        // xu li viec ban
        if (isShooting)
        {
            StartCoroutine(Shoot());
        }    
    }

    IEnumerator Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        shootSFX.Play();
        isShooting = false;
        yield return new WaitForSeconds(fireRate);
        isShooting = true;
    }
}
