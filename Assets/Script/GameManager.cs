using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GFManager _gfManager;
    [SerializeField] private float _timeLimit;
    [SerializeField] private Text _timeText;
    [SerializeField] private Text _countDownText;
    [SerializeField] private Text _scoreText;
    private float _timer;
    private bool _timerStarted = false;
    public int Score { get; private set; }

    private void Start()
    {
        _scoreText.enabled = false;
        _timer = _timeLimit;
        StartCoroutine(CountDown());
    }

    private void Update()
    {
        if (!_timerStarted) return;

        if (_timer <= 0)
        {
            _timeText.text = "0";
            ShowScore();
        }
        else
        {
            _timer -= Time.deltaTime;
            _timeText.text = Mathf.FloorToInt(_timer).ToString();
        }
    }
    
    private void ShowScore()
    {
        _scoreText.enabled = true;
        _scoreText.text = "Score" + Score;
    }

    public void AddScore(float score, float magnification)
    {
        Score += (int)(score * magnification);
        Debug.Log($"add score : {score}");
    }
    
    IEnumerator CountDown()
    {
        for (int i = 3; i > 0; i--)
        {
            _countDownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        _countDownText.text = "Start!";
        yield return new WaitForSeconds(1f);
        _countDownText.enabled = false;
        _timerStarted = true;
        _gfManager.isStarted = true;
    }
}