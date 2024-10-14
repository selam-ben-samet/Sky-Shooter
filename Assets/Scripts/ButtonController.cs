using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public ShipController shipController;

    public void OnPointerDown(PointerEventData eventData)
    {
        // Butona tıklandığında geminin hareketini durdurur
        shipController.SetCanMove(false);
        shipController.soundController.ClickSound();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Butondan el çekildiğinde geminin hareketine izin verir
        shipController.SetCanMove(true);
    }
}
