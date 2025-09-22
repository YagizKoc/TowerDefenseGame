using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public PlayerData stats;
    [SerializeField] GameObject playerProjectile;
    private float lastAttackTime;
    [SerializeField] private AudioClip attackSFX;
    [SerializeField] private AudioSource audioSource;
    public float playerHealth;

    [SerializeField] int attackSpeedUpgradeCost = 20;
    [SerializeField] int SpeedUpgradeCost = 20;
    [SerializeField] int attackUpgradeCost = 20;
    [SerializeField] int healthUpgradeCost = 20;

    public static Player Instance;

    // CACHE STATLAR
    private float currentAttackSpeed;
    private float currentMoveSpeed;
    private int currentBaseDamage;
    private float currentRange;
    private float currentMaxHealth;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // ScriptableObject değerleri cache
        currentAttackSpeed = stats.attackSpeed;
        currentMoveSpeed = stats.moveSpeed;
        currentBaseDamage = stats.BaseDamage;
        currentRange = stats.range;
        currentMaxHealth = stats.maxHealth;

        playerHealth = currentMaxHealth;

        InvokeRepeating("EnemyCheckInRange", 0.0f, 0.5f);
    }

    void Update()
    {
        playerMovement();
        EnemyCheckInRange();
    }

    private void playerMovement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v).normalized;
        transform.Translate(dir * currentMoveSpeed * Time.deltaTime, Space.World);

        if (dir.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (dir.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
    }

    private void playerRangeAttack()
    {
        GameObject target = FindClosestEnemy();
        if (target == null) return;

        Vector3 dir = (target.transform.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(dir);
        GameObject projectile = Instantiate(playerProjectile, transform.position, rotation);
        audioSource.PlayOneShot(attackSFX);
        lastAttackTime = Time.time;
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float minDist = Mathf.Infinity;

        foreach (var e in enemies)
        {
            float dist = Vector3.Distance(transform.position, e.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = e;
            }
        }
        return closest;
    }

    private void EnemyCheckInRange()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, currentRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                Debug.Log("Menzilde düşman var: " + hitCollider.name);
                if (lastAttackTime + currentAttackSpeed < Time.time)
                {
                    playerRangeAttack();
                }
            }
        }
    }

    // --- Upgrade Fonksiyonları ---

    public void AttackSpeedUpgrade()
    {
        if (GameManager.Instance.goldAmount >= attackSpeedUpgradeCost)
        {
            currentAttackSpeed -= 0.01f;
            GameManager.Instance.goldAmount -= attackSpeedUpgradeCost;
            attackSpeedUpgradeCost += 5;
        }
    }

    public void AttackUpgrade()
    {
        if (GameManager.Instance.goldAmount >= attackUpgradeCost)
        {
            currentBaseDamage += 5;
            GameManager.Instance.goldAmount -= attackUpgradeCost;
            attackUpgradeCost += 5;
        }
    }

    public void SpeedUpgrade()
    {
        if (GameManager.Instance.goldAmount >= SpeedUpgradeCost)
        {
            currentMoveSpeed += 1.0f;
            GameManager.Instance.goldAmount -= SpeedUpgradeCost;
            SpeedUpgradeCost += 5;
        }
    }

    public void HealthUpgrade()
    {
        if (GameManager.Instance.goldAmount >= healthUpgradeCost)
        {
            currentMaxHealth += 10;
            playerHealth = currentMaxHealth; // full heal örneği
            GameManager.Instance.goldAmount -= healthUpgradeCost;
            healthUpgradeCost += 5;
        }
    }
}
