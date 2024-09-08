using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreenController : MonoBehaviour
{

    public GameObject ship;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void showDeathScreen()
    {
        gameObject.SetActive(true);
        Debug.Log("workss");

    }
    public void hideDeathScreen()
    {
        gameObject.SetActive(false);
    }

    public void Continue()
    {
        // watch ads
        Time.timeScale = 1;
        ship.GetComponent<ShipController>().health = ship.GetComponent<ShipController>().maxHealth / 2;
        hideDeathScreen();
    }
    public void GiveUp()
    {
        Time.timeScale = 1;
        hideDeathScreen();
        // go to main menu
    }
}
