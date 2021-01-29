using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{    
    public float speed;
    public Text countText;
    public Text winText;
    public Text timerText;
    public GameObject pickupSound;
    public GameObject beatLevelSound;

    private Rigidbody _rb;
    private int _count = 0;
    private Vector3 _movement = new Vector3(0, 0, 0);
    private float _secondsCount;
    private int _minutesCount;
    private bool _hasWon = false;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        SetCountText();
        winText.text = "";
    }

    private void Update()
    {
        if (!_hasWon)
        {
            UpdateTimerUI();
            
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            _movement = new Vector3(moveHorizontal, 0, moveVertical);
        }
        else
        {
            _movement = Vector3.up * speed;
        }

    }

    private void FixedUpdate()
    {
        _rb.AddForce(_movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {            
            Instantiate(pickupSound);
            other.gameObject.transform.parent.gameObject.SetActive(false);
            _count++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        countText.text = "Count: " + _count.ToString();
        if (_count >= 14)
        {
            Instantiate(beatLevelSound);
            winText.text = "You Win!";
            _hasWon = true;
        }
    }

    private void UpdateTimerUI()
    {
        _secondsCount += Time.deltaTime;
        if (_secondsCount <= 10)
        {
            timerText.text = _minutesCount + ":0" + (int) _secondsCount;
        }
        else
        {
            timerText.text = _minutesCount + ":" + (int) _secondsCount;
        }
        if (_secondsCount >= 60)
        {
            _minutesCount++;
            _secondsCount = 0;
        }
    }
}
