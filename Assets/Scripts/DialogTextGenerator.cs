using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextAnimator : MonoBehaviour
{
     public TextMeshProUGUI text;
    public float animationTime = 1f;
    public Button continueButton;
    
    private string originalText;
    private float timer;
    
    private void Awake()
    {
        originalText = text.text;
        text.text = "";
        continueButton.gameObject.SetActive(false);
    }
    
    private void Update()
    {
        if (timer <= animationTime)
        {
            timer += Time.deltaTime;
            
            int visibleCharacterCount = (int)(originalText.Length * (timer / animationTime));
            text.text = originalText.Substring(0, visibleCharacterCount);
        }
        else
        {
            continueButton.gameObject.SetActive(true);
        }
    }
}