using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    
    public TextMeshProUGUI timerText;
    private float _elapsedTime;
    private bool _isRunning;
    
    public void StartTimer()
    {
        _elapsedTime = 0;
        _isRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isRunning)
        {
            _elapsedTime += Time.deltaTime;
            int minutes = (int)(_elapsedTime / 60);
            int seconds = (int)(_elapsedTime % 60);
            int milliseconds = (int)((_elapsedTime - (int)_elapsedTime) * 1000);

            string formatted = string.Format("{0:D2}:{1:D2}:{2:D3}", minutes, seconds, milliseconds);
            timerText.text = formatted;
        }
    }

    public void StopTimer()
    {
        _isRunning = false;
    }
}