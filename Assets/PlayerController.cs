using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    public Rigidbody rb;
    private int PlayerHp = 3;
    private GameManager gameManager;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        GameObject findGo = GameObject.FindWithTag("GameController");
        gameManager = findGo.GetComponent<GameManager>();
    }

    private void Update()
    {
        Vector3 direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        if (direction.magnitude > 1f)
        {
            direction.Normalize();
        }


        rb.linearVelocity = direction * speed;
    }

    public void OnDie()
    {
        gameObject.SetActive(false);
        gameManager.EndGame();
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Item_Speed"))
    //     {
    //         speed += 3f;
    //     }
    // }
    public void Item_SpeedGet()
    {
        speed += 3f;
    }
    public void TakeDamage()
    {
        PlayerHp -= 1;
        if(PlayerHp >= 3)
        {
        
        }
        else if (PlayerHp >= 2 && PlayerHp < 3)
        {
            heart3.SetActive(false);
        }
        else if(PlayerHp == 1)
        {
            heart2.SetActive(false);
        }
        else if (PlayerHp <= 0)
        {
            heart1.SetActive(false);
            OnDie();
        }
    }
}
