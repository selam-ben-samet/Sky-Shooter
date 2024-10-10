using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startmenu : MonoBehaviour
{
    public GameObject[] shipImages; // Array of ship images to display on the start menu
    private int currentShipIndex = 1; // Default starting ship index
    public Image shipNameImage; // UI image that shows the ship's name
    public Sprite[] shipNameSprites; // Ship name images corresponding to the ships

    void Start()
    {
        // Update the menu with the default ship
        UpdateShipDisplay();
    }

    public void OnLeftArrowClick()
    {
        currentShipIndex--;
        if (currentShipIndex < 0)
        {
            currentShipIndex = shipImages.Length - 1;
        }
        UpdateShipDisplay();
    }

    public void OnRightArrowClick()
    {
        currentShipIndex++;
        if (currentShipIndex >= shipImages.Length)
        {
            currentShipIndex = 0;
        }
        UpdateShipDisplay();
    }

    // Method to update the ship display when the player navigates through the menu
    private void UpdateShipDisplay()
    {
        // Set active only the currently selected ship image
        for (int i = 0; i < shipImages.Length; i++)
        {
            shipImages[i].SetActive(i == currentShipIndex); // Show the current ship image
        }

        // Update the ship name image
        shipNameImage.sprite = shipNameSprites[currentShipIndex];
    }

    // Method to start the game with the selected ship
    public void OnStartGameClick()
    {
        // Store the selected ship's name in PlayerPrefs so it can be accessed in the next scene
        PlayerPrefs.SetString("SelectedShip", shipImages[currentShipIndex].name);
        PlayerPrefs.Save();

        // Load the next scene (where the actual game starts)
        SceneManager.LoadScene("main"); // Make sure this matches the name of your actual gameplay scene
    }
}
