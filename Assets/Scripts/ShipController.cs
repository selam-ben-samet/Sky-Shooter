using System;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    #region Gun
    public GameObject bulletPB;
    public float bulletSpeed;
    private float lastFireTime;
    #endregion
    #region Attributes

    public float health;
    public float maxHealth;
    public float healthRegen;
    public float resistance;
    public float attackSpeed;
    public float attackDamage;
    #endregion
    private float lastRegenTime;
    public GameObject shipBody;
    public GameObject shipGun;
    public GameObject deathScreen;
    private Vector3 targetPosition; // Geminin hedef pozisyonu
    private bool isDragging = false;

    private bool canMove = true; // Geminin hareket edip edemeyeceğini kontrol eden bayrak

    void Awake()
    {
        string selectedShip = PlayerPrefs.GetString("SelectedShip", "Viper"); // Default to "Viper" if no selection was made
        setUpShip(selectedShip);

        // Start with the target position as the current position
        targetPosition = transform.position;
        Time.timeScale = 1;
    }


    void Update()
    {
        MoveShip();
        Fire();
        RegenHealth(1f);
    }
    void Die()
    {
        deathScreen.SetActive(true);
        Time.timeScale = 0;



    }
    void MoveShip()
    {
        // Sadece gemi hareket edebilirken dokunma ve sürükleme işlemlerini kontrol et
        if (canMove && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Dokunma başladığında hedef pozisyonu belirle
                targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));
                targetPosition.z = 0; // Z pozisyonunu sabit tut

                isDragging = true;
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                // Parmak hareket ettikçe hedef pozisyonu güncelle
                targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));
                targetPosition.z = 0; // Z pozisyonunu sabit tut
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isDragging = false;
            }
        }

        // Gemiyi hedef pozisyona doğru smooth bir şekilde kaydır
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10);
    }

    public void Fire()
    {
        if (Time.time - lastFireTime >= (3f / (attackSpeed * 10)))
        {

            var bulletClone = Instantiate(bulletPB, shipGun.transform.position + Vector3.up, shipGun.transform.rotation);
            bulletClone.GetComponent<Rigidbody2D>().velocity = Vector2.up * bulletSpeed;
            lastFireTime = Time.time;
            Destroy(bulletClone, 5);
        }
    }

    public void setUpShip(String tag)
    {

        shipBody = GameObject.FindGameObjectWithTag(tag);
        Instantiate(shipBody, this.transform);
        switch (tag)
        {
            case "Tyrant":

                health = 135f;
                maxHealth = 135f;
                healthRegen = 0.7f;
                resistance = 12f;
                attackSpeed = 0.4f;
                attackDamage = 27f;
                break;
            case "Viper":

                health = 90f;
                maxHealth = 90f;
                healthRegen = 0.5f;
                resistance = 9f;
                attackSpeed = 1.2f;
                attackDamage = 24f;
                break;
            case "Ravager":

                health = 112f;
                maxHealth = 112f;
                healthRegen = 0.6f;
                resistance = 10f;
                attackSpeed = 0.8f;
                attackDamage = 34f;
                break;
            default:
                break;
        }
    }

    public void skillUP(String skill)
    {

        switch (skill)
        {
            case "up_h":
                health += 100;
                break;
            case "up_hr":
                healthRegen += 0.5f;
                break;
            case "up_r":
                resistance += 1f;
                break;
            case "up_as":
                attackSpeed += 1f;
                break;
            case "up_ad":
                attackDamage += 5f;
                break;
            default:
                break;
        }
        GameObject.FindGameObjectWithTag("UpgradePanel").SetActive(false);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().UpdateStats();
        Time.timeScale = 1;
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }
    public void DecreaseHealth(int value)
    {

        health -= value - (value * (resistance / 100)) * 5;
        if (health <= 0)
        {
            Die();
        }
    }

    public void RegenHealth(float perSec)
    {
        if (health < maxHealth)
        {
            if (Time.time - lastRegenTime >= perSec)
            {
                health += healthRegen;
                lastRegenTime = Time.time;
            }

        }

    }

}
