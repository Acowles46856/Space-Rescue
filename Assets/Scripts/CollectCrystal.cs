using UnityEngine;

public class CollectCrystal : MonoBehaviour
{
    public static int crystalsCollected = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            crystalsCollected++;
            Debug.Log("Crystals Collected: " + crystalsCollected);
            Destroy(gameObject);
        }
    }
}