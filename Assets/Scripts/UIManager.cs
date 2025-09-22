using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject upgradesPanel;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI goldAmountText;
    public TextMeshProUGUI PlayerHpUI;
    public TextMeshProUGUI CastleHpUI;
    public static UIManager Instance;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }

    public void OpenUpgradesPanel()
    {
        if (GameManager.Instance.isGameOver) return; 

        bool isActive = upgradesPanel.gameObject.activeSelf;

        upgradesPanel.gameObject.SetActive(!isActive);
    }


}
