using UnityEngine;

namespace Presenters
{
    public abstract class BaseFactory<T> : MonoBehaviour
    {
        public abstract void Create(T obj);
    }
}