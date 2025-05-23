using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using unityroom.Api;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GFManager _gfManager;
    [SerializeField] private float _timeLimit;
    [SerializeField] private float _changeLimit;
    [SerializeField] private Text _timeText;
    [SerializeField] private Text _countDownText;
    [SerializeField] private Text _scoreText;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Status _status;
    [SerializeField] SceneLoadManager _sceneLoadManager;
    [SerializeField] private GameObject _button;
    private float _timer;
    private bool _timerStarted = false;
    
    private float _changeTimer;
    
    private bool _isSended = false;
    public int _girlFriendIndex
    {
        get;
        private set;
    }
    public int Score { get; private set; }

    private void Start()
    {
        _scoreText.enabled = false;
        _timer = _timeLimit;
        StartCoroutine(CountDown());
        _girlFriendIndex = Random.Range(0, _status.GirlFriendStatuses.Length);
        _spriteRenderer.color = _status.GirlFriendStatuses[_girlFriendIndex].Colors;
    }

    private void Update()
    {
        if (!_timerStarted) return;

        if (_timer <= 0)
        {
            _timeText.text = "0";
            _gfManager.isEnded = true;
            ShowScore();
            _button.SetActive(true);
            if (Input.GetButtonDown("Jump"))
            {
                _sceneLoadManager.LoadScene("StartScene");
            }

            if (!_isSended)
            {
                UnityroomApiClient.Instance.SendScore(1,Score,ScoreboardWriteMode.HighScoreDesc);
                _isSended = true;
            }
        }
        else
        {
            _timer -= Time.deltaTime;
            _timeText.text = Mathf.FloorToInt(_timer).ToString();
        }
        _changeTimer += Time.deltaTime;
        if (_changeTimer >= _changeLimit)
        {
            _girlFriendIndex = Random.Range(0, _status.GirlFriendStatuses.Length);
            _spriteRenderer.color = _status.GirlFriendStatuses[_girlFriendIndex].Colors;
            _changeTimer = 0;

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
    public void LegacyCheck(int index)
    {
        if (_girlFriendIndex == index)
        {
            _sceneLoadManager.LoadScene("GameOver");
        }

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