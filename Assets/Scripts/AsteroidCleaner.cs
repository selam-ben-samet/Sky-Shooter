using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidCleaner : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        // Get the collider component (assuming a BoxCollider2D for a 2D object)
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        if (collider == null)
        {
            Debug.LogError("BoxCollider2D not found on the object.");
            return;
        }

        // Get the screen width in world units
        float screenWidthInWorldUnits = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;

        // Set the collider width to the screen width
        collider.size = new Vector2(screenWidthInWorldUnits * 2, collider.size.y);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }


}