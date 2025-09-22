using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData stats;
    [SerializeField] Animator animator;
    private float enemyHealth;
    private Transform target;
    private int waypointIndex = 0;
    private bool isEnemyDead;

    /*private void OnEnable()
    {
        Ticker.OnTickAction += Tick;
    }

    private void OnDisable()
    {
        Ticker.OnTickAction -= Tick;
    }

        //Runs every 0.1 second
    /*private void Tick()
    {
        
    }*/

    void Start()
    {
        Debug.Log("Waypoint count: " + Waypoints.waypoints.Length);

        //enemy stats
        enemyHealth = stats.maxHealth;

        //pathfinding
        target = Waypoints.waypoints[0];
    }


    void Update()
    {
        enemyMovement();

    }

    private void enemyMovement()
    {
        if (!isEnemyDead)
        {
            //Moving
            float enemySpeed = stats.moveSpeed;
            Vector3 dir = (target.position - transform.position).normalized;
            transform.Translate(dir * enemySpeed * Time.deltaTime, Space.World);

            //Adjust waypoints
            if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            {
                GetNextWaypoint();
            }
        }
    }

    private void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
            GameManager.Instance.castleHealth -= stats.damage;
            return;
        }
        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }

    public void enemyTookDamage() 
    {
        enemyHealth -= Player.Instance.stats.BaseDamage;
        animator.SetTrigger("damageTrigger");
        if (enemyHealth <= 0) 
        {
            enemyDeath();
        }
    }

    private void enemyDeath() 
    {
        GameManager.Instance.goldAmount += stats.goldReward;
        GetComponent<Collider>().enabled = false;
        animator.SetTrigger("deathTrigger");
        isEnemyDead = true;
        StartCoroutine(DeathRoutine());
       
    }

    private IEnumerator DeathRoutine()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
    private void EnemyDamage()
    {
        Player.Instance.playerHealth -= stats.damage;
        if (Player.Instance.playerHealth <= 0) 
        {
            GameManager.Instance.GameOver();
        }
        

    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player")) 
        { 
            EnemyDamage();
            Debug.Log("player took damage");
        }
    }

    
}
