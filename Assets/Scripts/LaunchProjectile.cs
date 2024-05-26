using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;

    public float launchCooldown = 1.5f;
    private float lastLaunchTime;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= lastLaunchTime + launchCooldown)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            ShootProjectile(mousePosition);
        }
    }

    void ShootProjectile(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - projectileSpawnPoint.position;
        GameObject projectileP = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
        Projectile projectile = projectileP.GetComponent<Projectile>();
        if (projectile != null)
        {
            projectile.SetDirection(direction);
        }
        lastLaunchTime = Time.time;
    }
}
