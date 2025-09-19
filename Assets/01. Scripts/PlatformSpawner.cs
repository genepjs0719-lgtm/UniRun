using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    [SerializeField] GameObject platformPrefab;
    int count = 3;

    float timeBestSpawnMin = 1.25f;
    float timeBestSpawnMax = 2.25f;
    float timeBestSpawn;

    float yMin = -3.5f;
    float yMax = 1.5f;
    float xPos = 20;

    GameObject[] platforms;
    int currentIndex = 0;

    Vector2 poolPosition = new Vector2(0, -25);
    private float lastSpawnTime;

    void Start()
    {
        platforms = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);

        }
        lastSpawnTime = 0f;
        timeBestSpawn = 0f;
    }

    void Update()
    {
        if (GameManager.instance.isGameover)
        {
            return;
        }
        if (Time.time >= lastSpawnTime + timeBestSpawn)

        {
            lastSpawnTime += Time.time;

            timeBestSpawn = Random.Range(timeBestSpawnMin, timeBestSpawnMax);

            float yPos = Random.Range(yMin, yMax);
            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);

            platforms[currentIndex].transform.position = new Vector2(xPos, yPos);

            currentIndex++;

            if (currentIndex >= count)
            {
                currentIndex = 0;
            }
       
        }
    }
}
