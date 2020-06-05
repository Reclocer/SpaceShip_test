using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Core
{
    public abstract class SingletonBase<T> : MonoBehaviour
    {
        public static T Instance { get; protected set; }
        protected abstract T GetInstance();

        protected virtual void Awake()
        {
            if (Instance == null)
                Instance = GetInstance();

            DontDestroyOnLoad(this.gameObject);
        }
    }
}
