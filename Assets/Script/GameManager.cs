using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _timeLimit;
    [SerializeField] private Text _timeText;
    [SerializeField] private Text _countDownText;
    [SerializeField] private Text _scoreText;
    private float _timer;

    private bool _timerStarted = false;

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
            
        }
        else
        {
            _timer -= Time.deltaTime;
            _timeText.text = _timer.ToString();
        }
    }

    public int Score { get; private set; }

    private void ShowScore()
    {
        _scoreText.text = "Score" + Score;
    }

    public void AddScore(float score, float magnification)
    {
        Score += (int)(score * magnification);
        Invoke(nameof(AAA), 1f);
    }

    private void AAA()
    {
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
    }
}