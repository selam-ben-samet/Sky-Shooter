using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    public ShipController ship;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "asteroid")
        {
            Destroy(col.gameObject);
            ship.DecreaseHealth(col.gameObject.GetComponent<Asteroid>().crashDamage);
        }
    }
}
