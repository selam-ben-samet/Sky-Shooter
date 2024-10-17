using System.Collections;
using TMPro;
using UnityEngine;

public class FPS : MonoBehaviour
{
    public TextMeshProUGUI fpsText;
    private float deltaTime;
    void Awake()
    {
        QualitySettings.vSyncCount = 0; // VSync'yi kapat
        Application.targetFrameRate = 120; // 120 FPS'ye ayarla
    }

    void Update()
    {
        // Delta time hesaplaması
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;

        // FPS hesaplaması
        float fps = 1.0f / deltaTime;

        // TextMeshPro'da FPS güncellemesi
        fpsText.text = Mathf.Ceil(fps).ToString() + " FPS";
    }
}

