using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    class Pool
    {
        public Pool(GameObject prefab)
        {
            this.prefab = prefab;
        }

        private List<GameObject> inactive = new List<GameObject>();
        private GameObject prefab;

        public GameObject Spawn(Vector3 position, Quaternion rotation)
        {
            GameObject obj;
            if (inactive.Count == 0)
            {
                obj = Instantiate(prefab, position, rotation);
                obj.name = prefab.name;
                obj.transform.SetParent(instance.transform);
            }
            else
            {
                obj = inactive[inactive.Count - 1];
                inactive.RemoveAt(inactive.Count - 1);
            }

            obj.transform.SetPositionAndRotation(position, rotation);
            obj.SetActive(true);

            return obj;
        }

        public GameObject SpawnEnemy(Vector3 position)
        {
            GameObject obj;
            if (inactive.Count == 0)
            {
                obj = Instantiate(prefab);
                obj.name = prefab.name;
                obj.transform.SetParent(instance.transform);
            }
            else
            {
                obj = inactive[inactive.Count - 1];
                inactive.RemoveAt(inactive.Count - 1);
            }

            obj.transform.Find("Enemy").position = position;
            obj.SetActive(true);

            return obj;
        }

        public void Despawn(GameObject obj)
        {
            obj.SetActive(false);
            inactive.Add(obj);
        }
    }

    public static PoolManager instance;
    private Dictionary<string, Pool> pools = new Dictionary<string, Pool>();
    
    private void Awake()
    {
        instance = this;
    }

    private void Init(GameObject prefab)
    {
        if (prefab != null && pools.ContainsKey(prefab.name) == false)
        {
            pools[prefab.name] = new Pool(prefab);
        }
    }
    
    public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        Init(prefab);
        return pools[prefab.name].Spawn(position, rotation);
    }

    public GameObject SpawnEnemy(GameObject prefab, Vector3 position)
    {
        Init(prefab);
        return pools[prefab.name].SpawnEnemy(position);
    }

    public void Despawn(GameObject obj)
    {
        if(pools.ContainsKey(obj.name))
        {
            pools[obj.name].Despawn(obj);
        }
        else
        {
            Destroy(obj);
        }
    }
}