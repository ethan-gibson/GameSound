using TMPro;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    public static HudManager Instance;
    
    [SerializeField] private TextMeshProUGUI textMesh;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetInteractionText(string _text)
    {
        textMesh.text = _text;
    }
}
