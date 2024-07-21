using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPB;
    public float attackSpeed;
    public float bulletSpeed;
    private float lastFireTime;


    void Update()
    {
        Fire();
    }
    public void Fire()
    {
        if (Time.time - lastFireTime >= (3f / (attackSpeed * 10)))
        {
            var bulletClone = Instantiate(bulletPB, transform.position + Vector3.up, transform.rotation);
            bulletClone.GetComponent<Rigidbody2D>().velocity = Vector2.up * bulletSpeed;
            lastFireTime = Time.time;
            Destroy(bulletClone, 5);
        }


    }
}
