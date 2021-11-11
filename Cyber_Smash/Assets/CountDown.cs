
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    private float currentTime = 0f;
    private float startingTime = 10f;

    public Text countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }
}
