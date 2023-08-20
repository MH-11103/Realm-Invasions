using UnityEngine;

public class SpiderhealthManager : MonoBehaviour
{
    public int SpidermaxHealth = 600;
    public int SpidercurrentHealth;

    private void Start()
    {
        SpidercurrentHealth = SpidermaxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        SpidercurrentHealth -= damageAmount;
        if (SpidercurrentHealth <= 0)
        {
            SpiderDie();
        }
    }

    private void SpiderDie()
    {
        // Perform death logic here, such as playing death animations or spawning particle effects.
        Destroy(gameObject);
    }
}
