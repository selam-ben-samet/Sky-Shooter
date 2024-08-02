using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float fallSpeed = 1f; // Düşme hızı
    public float rotationSpeed = 10f; // Dönme hızı
    public float health;
    public int asteroidType;
    public float attackDamage;
    public GameObject ship;
    public LevelManager levelManager;
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        health = asteroidType * 100;
    }
    void Update()
    {
        ship = GameObject.Find("Ship");
        attackDamage = ship.GetComponent<ShipController>().attackDamage;
        // Asteroidin düşmesini sağla
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);

        // Asteroidin x ekseninde dönmesini sağla
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "bullet")
        {
            Destroy(col.gameObject);
            health -= attackDamage;
            if (health <= 0)
            {
                Destroy(gameObject);
                levelManager.IncreaseExp(asteroidType * 2);
            }
        }
    }
}
