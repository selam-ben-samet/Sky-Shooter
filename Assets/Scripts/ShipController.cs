using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Vector3 targetPosition; // Geminin hedef pozisyonu
    private bool isDragging = false;

    void Start()
    {
        // Başlangıçta hedef pozisyonu geminin mevcut pozisyonu olarak ayarla
        targetPosition = transform.position;
    }

    void Update()
    {
        MoveShip();
    }
    void MoveShip()
    {
        // Dokunma ve sürükleme işlemlerini kontrol et
        if (Input.touchCount > 0)
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
}
