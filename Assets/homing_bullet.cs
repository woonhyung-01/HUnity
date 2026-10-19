using UnityEngine;

public class homing_bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody rb;
    private Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        Destroy(gameObject, 3f);
        
    }
    private void Update()
    {
        GameObject findGo = GameObject.FindWithTag("Player");
        target = findGo.transform;
        Vector3 position = transform.position;
        Vector3 direction = target.position - position;
        direction.Normalize();
        rb.linearVelocity = direction * speed;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            playerController.OnDie();
        }

        if(other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
