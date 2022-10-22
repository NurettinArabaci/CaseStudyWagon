using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoSingleton<UIManager>
{
    [Header("Panels")]
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    [Header("Buttons")]
    [Space(20)]
    [SerializeField] private Button startButton;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button restartButton;

    [Header("Score")]
    [Space(10)]
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] TextMeshProUGUI _coalScoreText;
    [SerializeField] TextMeshProUGUI _stickmanScoreText;

    protected override void Awake()
    {
        base.Awake();
        EventManager.OnBeginGame += OnBeginGame;
        EventManager.OnPlayGame += OnPlayGame;
        EventManager.OnWin += OnWinGame;
        EventManager.OnLose += OnLoseGame;
        AddListenerClickButtons();
    }

    void OnBeginGame()
    {
        startPanel.SetActive(true);
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    void OnPlayGame()
    {
        startPanel.SetActive(false);
    }

    void OnWinGame()
    {
        _coalScoreText.text = scoreManager.coalScore.ToString();
        _stickmanScoreText.text = scoreManager.stickmanScore.ToString();
        winPanel.SetActive(true);
        
    }

    void OnLoseGame()
    {
        losePanel.SetActive(true);
    }

    void AddListenerClickButtons()
    {
        startButton.onClick.AddListener(() => {

            GameStateEvent.Fire_OnChangeGameState(GameState.Play);
        });

        nextLevelButton.onClick.AddListener(() => {
            //Next => LevelManager
        });

        restartButton.onClick.AddListener(() => {
            //Restart => LevelManager
        });

    }

    private void OnDisable()
    {
        EventManager.OnBeginGame -= OnBeginGame;
    }

}
