using UnityEngine;
using System.Collections;

public class ShootersTowers : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;

    [Header("Geral")]
    public float range = 15f;

    [Header("Uso das Bullets")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Uso Laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public int damageOverTime = 30;

    [Header("Unity Setup")]
    public string enemyTag = "Enemy";
    public string caciqueTag = "Cacique";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject[] caciques = GameObject.FindGameObjectsWithTag(caciqueTag);

        float shortestEnemyDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        // Detectar inimigos
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestEnemyDistance)
            {
                shortestEnemyDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (!useLaser && fireRate < 2.5f) 
        { 
            // Detectar e aplicar buff do Cacique
            foreach (GameObject cacique in caciques)
            {
                float distanceToCacique = Vector3.Distance(transform.position, cacique.transform.position);
                if (distanceToCacique <= range)
                {
                    Cacique caciqueScript = cacique.GetComponent<Cacique>();
                    if (caciqueScript != null)
                    {
                        caciqueScript.BuffFireRate(this);
                    }
                }
            }
        }
        if (useLaser)
        {
            foreach (GameObject cacique in caciques)
            {
                float distanceToCacique = Vector3.Distance(transform.position, cacique.transform.position);
                if (distanceToCacique <= range)
                {
                    Cacique caciqueScript = cacique.GetComponent<Cacique>();
                    if (caciqueScript != null)
                    {
                        caciqueScript.BuffSlow(this);
                    }
                }
            }
                
        }


        if (nearestEnemy != null && shortestEnemyDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                    lineRenderer.enabled = false;
            }
            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    void LockOnTarget()
    {
        //Target lock on
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser()
    {
        targetEnemy.DamageTake(damageOverTime * Time.deltaTime);


        if (!lineRenderer.enabled)
            lineRenderer.enabled = true;


        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

    }
    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Perseguir(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

