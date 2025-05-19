using UnityEngine;

namespace Runtime.Infrastructure.Pooling
{
    public interface IPoolable
    {
        GameObject OriginalPrefab { get; }
        void SetOriginalPrefab(GameObject prefab);
    }
}