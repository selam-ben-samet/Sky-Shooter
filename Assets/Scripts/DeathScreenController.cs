using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreenController : MonoBehaviour
{
    public GameObject deathScreen;
    public GameObject ship;
    // Start is called before the first frame update
    void Start()
    {
        hideDeathScreen();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void showDeathScreen()
    {
        deathScreen.SetActive(true);

    }
    public void hideDeathScreen()
    {
        deathScreen.SetActive(false);
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
