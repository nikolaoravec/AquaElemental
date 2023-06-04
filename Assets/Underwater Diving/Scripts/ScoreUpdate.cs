using UnityEngine;
using UnityEngine.UI;
using TMPro; // <= THIS

public class GlobalCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText; // Reference to the counter text component
    private void Update()
    {
        // Read the global variable 'count' and update the counter text
        counterText.text = GlobalState.coinCount.ToString();
    }
}
