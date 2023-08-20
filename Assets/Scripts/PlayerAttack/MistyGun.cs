//using UnityEngine;

//public class MistyGun : MonoBehaviour
//{
//    public Transform bulletSpawnPoint;
//    public GameObject bulletPrefab;
//    public float bulletSpeed = 10;
//    public float detectionRange = 10; // Adjust this range as needed

//    private GameObject targetObject;
//    private bool isShooting = false;

//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space)) // manual method from keyboard
//        {
//            ShootBullet();
//        }

//        DetectTarget();

//        if (isShooting && targetObject != null)
//        {
//            ShootBullet();
//        }
//    }

//    void DetectTarget()
//    {
//        RaycastHit hit;
//        Debug.DrawRay(bulletSpawnPoint.position, bulletSpawnPoint.forward * detectionRange, Color.red); // Debug ray

//        if (Physics.Raycast(bulletSpawnPoint.position, bulletSpawnPoint.forward, out hit, detectionRange))
//        {
//            Debug.Log(hit.collider.tag);
//            if (hit.collider.CompareTag("drone") || hit.collider.CompareTag("Target"))// Change "Target" to the appropriate tag
//            {
//                targetObject = hit.collider.gameObject;
//                isShooting = true;
//            }
//            else
//            {
//                targetObject = null;
//                isShooting = false;
//            }
//        }
//        else
//        {
//            targetObject = null;
//            isShooting = false;
//        }
//    }

//    void ShootBullet()
//    {
//        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
//        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
//    }
//}

using UnityEngine;

public class MistyGun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float detectionRange = 30; // Adjust this range as needed
    public float shootInterval = 1f; // Adjust the delay between shots

    private GameObject targetObject;
    private bool isShooting = false;
    private float lastShootTime = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // manual method from keyboard
        {
            ShootBullet();
        }

        DetectTarget();

        if (isShooting && targetObject != null && Time.time >= lastShootTime + shootInterval)
        {
            ShootBullet();
            lastShootTime = Time.time;
        }
    }

    void DetectTarget()
    {
        RaycastHit hit;
        Debug.DrawRay(bulletSpawnPoint.position, bulletSpawnPoint.forward * detectionRange, Color.red); // Debug ray

        if (Physics.Raycast(bulletSpawnPoint.position, bulletSpawnPoint.forward, out hit, detectionRange))
        {
            Debug.Log(hit.collider.tag);
            if (hit.collider.CompareTag("drone") || hit.collider.CompareTag("blaster") || hit.collider.CompareTag("spider"))// Change "Target" to the appropriate tag
            {
                targetObject = hit.collider.gameObject;
                isShooting = true;
            }
            else
            {
                targetObject = null;
                isShooting = false;
            }
        }
        else
        {
            targetObject = null;
            isShooting = false;
        }
    }

    void ShootBullet()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
    }
}
