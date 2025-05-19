using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Infrastructure.Pooling
{
    public class ComponentPoolService
    {
        private readonly Dictionary<GameObject, Queue<Component>> _pools = new();
        private readonly Transform _container;

        public ComponentPoolService(Transform container)
        {
            _container = container;
        }

        public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            if (!_pools.TryGetValue(prefab, out var queue))
            {
                queue = new Queue<Component>();
                _pools[prefab] = queue;
            }

            GameObject instance;
            
            if (queue.Count > 0)
            {
                instance = queue.Dequeue().gameObject;
                instance.transform.SetPositionAndRotation(position, rotation);
                instance.SetActive(true);
            }
            else
            {
                instance = Object.Instantiate(prefab, position, rotation, _container);
                if (instance.TryGetComponent<IPoolable>(out var poolable))
                    poolable.SetOriginalPrefab(prefab);
            }

            return instance;
        }

        public void Despawn(GameObject instance)
        {
            instance.SetActive(false);

            if (instance.TryGetComponent<IPoolable>(out var poolable) && poolable.OriginalPrefab != null)
            {
                var prefab = poolable.OriginalPrefab;
                
                if (!_pools.ContainsKey(prefab))
                    _pools[prefab] = new Queue<Component>();

                _pools[prefab].Enqueue(instance.transform);
            }
            else
            {
                Object.Destroy(instance);
            }
        }
    }
}