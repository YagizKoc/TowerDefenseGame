using UnityEngine;

public class Projectile : MonoBehaviour
{
    float projectileSpeed = 30.0f;
    public GameObject projectileShatter;
    private GameObject target;

    private void Start()
    {
        target = Player.Instance.FindClosestEnemy();
    }
    private void Update()
    {
        
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        moveProjectile();
    }

    private void moveProjectile() 
    {
        
        Vector3 dir = (target.transform.position - transform.position).normalized;
        transform.Translate(dir * Time.deltaTime * projectileSpeed, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.enemyTookDamage();
            }
            GameObject effectIns = (GameObject)Instantiate(projectileShatter, transform.position, transform.rotation);
            Destroy(effectIns, 2.0f);
            Destroy(gameObject);
        }
    }
}
