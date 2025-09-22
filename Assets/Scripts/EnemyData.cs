using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyStats", menuName = "Stats/Enemy Stats")]
public class EnemyData : ScriptableObject
{
    [Header("Base Stats")]
    public string enemyName;
    public Sprite enemySprite;
    public int maxHealth = 100;
    public float moveSpeed = 2f;
    public int damage = 10;

    [Header("Reward")]
    public int xpReward = 5;
    public int goldReward = 1;
}

