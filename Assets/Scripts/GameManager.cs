using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isGameOver;
    public int goldAmount;
    public int castleHealth;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        isGameOver = false;
        goldAmount = 0;
        castleHealth = 100;
    }

    private void OnEnable()
    {
        Ticker.OnTickAction += Tick;
    }

    private void OnDisable()
    {
        Ticker.OnTickAction -= Tick;
    }

    private void Tick()
    {
        UIManager.Instance.goldAmountText.text = goldAmount.ToString();
        UIManager.Instance.PlayerHpUI.text = Player.Instance.playerHealth.ToString();
        UIManager.Instance.CastleHpUI.text = castleHealth.ToString();
        if (castleHealth <= 0)
        {
            GameOver();
        }

    }

    public void GameOver() 
    {
        isGameOver = true;
        UIManager.Instance.gameOverMenu.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void LoadCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();  
        SceneManager.LoadScene(currentScene.name);           
    }
}
