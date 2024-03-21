using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletDamage = 10.0f;

    private GameObject hitting;
    private AudioSource hittingSound;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * bulletSpeed);
        hitting = GameObject.FindWithTag("audio");
        hittingSound = hitting.GetComponent<AudioSource>();
    }

    // xu li va cham giua dan va block
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Block"))
        {
            hittingSound.Play();
            other.SendMessageUpwards("OnDamaged", bulletDamage);
            Destroy(gameObject);
        }
    }

    // pha huy dan khi dan ra khoi man hinh
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}