using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Stats/Player Stats")]
public class PlayerData : ScriptableObject
{
    [Header("Base Stats")]
    public string playerName;
    public Sprite playerSprite;
    public GameObject selectedWeapon;
    public int maxHealth = 100;
    public float moveSpeed = 3f;
    public int BaseDamage = 10;
    public float attackSpeed = 1.0f;
    public float range = 5.0f;

}
