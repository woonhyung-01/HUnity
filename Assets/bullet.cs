using UnityEngine;

public class bullit : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody rb;

    public bool isCluster;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        rb.linearVelocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            playerController.TakeDamage();
        }

        if (!isCluster)
        {
            if(other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
        }
    }
}
