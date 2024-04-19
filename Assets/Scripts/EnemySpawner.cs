using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] private float rad = 14f;
    [SerializeField] private float spawnRate = 1f;
//    [SerializeField] private GameObject[] enemyPrefabs;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            float alpha = Random.Range(0f, 360f);
            Vector2 temp = new Vector2(Mathf.Cos(alpha), Mathf.Sin(alpha));
            temp = temp * rad + (Vector2)_player.transform.position;

            ObjectPooler.Instance.SpawnFromPool("Enemy", temp, Quaternion.identity);

            yield return new WaitForSeconds(spawnRate);
        }
    }
}