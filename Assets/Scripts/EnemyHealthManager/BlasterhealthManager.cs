using UnityEngine;

public class BlasterhealthManager : MonoBehaviour
{
    public int BlastermaxHealth = 100;
    public int BlastercurrentHealth;

    private void Start()
    {
        BlastercurrentHealth = BlastermaxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        BlastercurrentHealth -= damageAmount;
        if (BlastercurrentHealth <= 0)
        {
            BlasterDie();
        }
    }

    private void BlasterDie()
    {
        // Perform death logic here, such as playing death animations or spawning particle effects.
        Destroy(gameObject);
    }
}
