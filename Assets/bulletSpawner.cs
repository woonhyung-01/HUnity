using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    // public GameObject bulletPrefab;
    private Transform target;

    public GameObject[] array = new GameObject[3];

    public float interval = 3f;
    private float timer = 0;
    
    private void Start()
    {
        GameObject findGo = GameObject.FindWithTag("Player");
        target = findGo.transform;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            timer = 0f;
            Spawn();
        }
    }
    private void Spawn()
    {
        var element = array[Random.Range(0, array.Length)];
        Vector3 position = transform.position;
        Vector3 direction = target.position - position;
        direction.Normalize();
        Quaternion rotation = Quaternion.LookRotation(direction);
        if (element == array[0])
        {
            Instantiate(array[0], position, rotation);
        }
        else if (element == array[1])
        {
            Instantiate(array[1], position, rotation);
        }
        else if (element == array[2])
        {
            Instantiate(array[2], position, rotation);
        }
    }
}
