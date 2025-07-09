using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public Timer timer;
    public float speed = 0;
    public TextMeshProUGUI scoreText;
    public GameObject winTextObject;
    
    private Rigidbody _rb;
    private int _score;
    private float _movementX;
    private float _movementY;
    private bool _moved;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _score = 0;
        _moved = false;
        
        SetScoreText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        if (!_moved)
        {
            timer.StartTimer();
        }
        Vector2 movementVector = movementValue.Get<Vector2>();
        
        _movementX = movementVector.x;
        _movementY = movementVector.y;
        _moved = true;
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + _score.ToString();
        if (_score >= 8)
        {
            timer.StopTimer();
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(_movementX, 0.0f, _movementY);
        
        _rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            _score++;
            SetScoreText();
        }
    }
}
