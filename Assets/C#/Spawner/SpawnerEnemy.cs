using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabList;
    [SerializeField][Range(10,50)] private int spawnRange;
    [SerializeField] private float spawnCD;
    [SerializeField] private float interval;
    private int counter;

    private void Start()
    {
        interval = spawnCD;
    }
    
    private void OnEnable()
    {
        TimeManager.onSecoundPassed += IncreseSpawnSpeed;
    }

    private void OnDisable()
    {
        TimeManager.onSecoundPassed -= IncreseSpawnSpeed;
    }

    private void Update()
    {
        if (Tower.instance.STATE == Tower.State.Live)
        {
            if (spawnCD > 0 && Tower.instance.STATE == Tower.State.Live)
            {
                spawnCD -= Time.deltaTime;
            }
            else 
            {
                spawnCD = interval;
                SpawnEnemy();
            }
        }
        else
        {
            TurnOffSpawner();
        }
    }

    [ContextMenu(nameof(SpawnEnemyManual))]
    private void SpawnEnemyManual()
    {
        var enemyClone = PoolManager.instance.SpawnEnemy(GetEnemy(), SetPosition());
        Tower.instance.AddEnemy(enemyClone);
    }

    private void SpawnEnemy()
    {
        var enemyClone = PoolManager.instance.SpawnEnemy(GetEnemy(), SetPosition());
        Tower.instance.AddEnemy(enemyClone);
    }

    private Vector3 SetPosition()
    {
        float angel = 360 * Random.value;

        return new Vector3(Mathf.Cos(angel), 0, Mathf.Sin(angel)) * spawnRange;
    }
    private void TurnOffSpawner()
    {   
        for (int i = 0; i < Tower.instance.enemyList.Count; i++)
        {
            PoolManager.instance.Despawn(Tower.instance.enemyList[i]);
        }
    }

    private GameObject GetEnemy()
    {
        float enemy = Random.Range(0,10f);
        if (enemy > 9)
        {
            return enemyPrefabList[0];
        }
        return enemyPrefabList[1];
    }
    
    private void IncreseSpawnSpeed()
    {
        counter++;
        if(counter % 5 == 0)
        {
            if (interval > 1.1)
                interval *= 0.95f;
        }
    }
}
