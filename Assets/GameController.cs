using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public GameObject enemyPrefab;
    public Vector2 screenBounds;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        StartCoroutine("RandomAsteroidSpawn");
        StartCoroutine("RandomEnemySpawn");
    }

   IEnumerator RandomAsteroidSpawn()
    {
        while (true)
        {
            float asteroidSpawnRate = Random.Range(3.0f, 8.0f);

            yield return new WaitForSeconds(asteroidSpawnRate);

            GameObject asteroid = Instantiate(asteroidPrefab);
            asteroid.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y, screenBounds.y));
        }
    }

    IEnumerator RandomEnemySpawn()
    {
        while (true)
        {
            float enemySpawnRate = Random.Range(1.0f, 3.0f);

            yield return new WaitForSeconds(enemySpawnRate);

            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y, screenBounds.y));
        }
    }
}