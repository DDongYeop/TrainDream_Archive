using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnCoolTime;
    private int _spawnCnt = 0;
    private int _spawnIndex;
    
    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnCoolTime);
            ++_spawnCnt;
            _spawnCoolTime -= _spawnCoolTime * 0.01f;

            for (int i = 0; i < (int)Math.Floor((float)_spawnCnt / 5) + 1; ++i)
            {
                Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            }
        }
    }

    [ContextMenu("Enemy spawn")]
    public void SpawnEnemy()
    {
        ++_spawnCnt;
        _spawnCoolTime -= _spawnCoolTime * 0.01f;

        for (int i = 0; i < (int)Math.Floor((float)_spawnCnt / 5) + 1; ++i)
        {
            PoolableMono resource = PoolManager.Instance.Pop("01Beary");
            resource.transform.position = new Vector3(
                Random.Range(transform.root.transform.position.x - 7.5f, transform.root.transform.position.x + 7.5f), 
                transform.position.y,
                Random.Range(transform.root.transform.position.z - 7.5f, transform.root.transform.position.z + 7.5f));
        }
    }
}
