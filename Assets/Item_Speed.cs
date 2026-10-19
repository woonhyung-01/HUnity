using UnityEngine;

public class Item_Speed : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            playerController.Item_SpeedGet();
            Destroy(gameObject);
        }
    }
}
