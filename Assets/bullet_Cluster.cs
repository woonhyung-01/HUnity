using Unity.Mathematics;
using UnityEngine;

public class bullet_Cluster : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody rb;
    public GameObject gameCluster1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        rb.linearVelocity = transform.forward * speed;

        Invoke("Cluster", 1f);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            playerController.OnDie();
        }

    }

    private void Cluster()
    {
       Quaternion currentRotation = transform.rotation;
       Quaternion quaternion = Quaternion.Euler(0, 10f, 0);
       Quaternion gameCluster = quaternion * currentRotation;
       Instantiate(gameCluster1, transform.position, gameCluster);

       Quaternion tion = transform.rotation;
       Quaternion nion = Quaternion.Euler(0, -10f, 0);
       Quaternion ter = nion * tion;
       Instantiate(gameCluster1, transform.position, ter);
       Instantiate(gameCluster1, transform.position, transform.rotation);
       Destroy(gameObject);
    }
}
