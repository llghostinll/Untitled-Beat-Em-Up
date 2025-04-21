using UnityEngine;

public class PickUpCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandlePickUp(collision);
    }
    void HandlePickUp(Collider2D other)
    {
        string tag = other.tag;
        Collectible collectibleStats = other.GetComponent<Collectible>();

        switch (tag)
        {
            case "Apple":
                HandleApplePickUp(other, collectibleStats);
                break;
        }
    }

    void HandleApplePickUp(Collider2D other, Collectible collectibleStats)
    {
        other.GetComponent<HealthSystem>().IncreaseHealth(collectibleStats.value);
    }
}
