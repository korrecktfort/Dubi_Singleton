using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dubi.Singleton
{
    public class Singleton<T> : Singleton where T : MonoBehaviour
    {
        private static T instance;


        private static readonly object Lock = new object();

        [SerializeField] private bool persistent = true;

        public bool IsLoaded => instance != null;

        public static T Instance
        {
            get
            {
                if (Quitting)
                {
                    return null;
                }
                lock (Lock)
                {
                    if (instance != null)
                    {
                        return instance;
                    }

                    T[] instances = FindObjectsOfType<T>();
                    int count = instances.Length;
                    if (count > 0)
                    {
                        if (count == 1)
                        {
                            return instance = instances[0];
                        }

                        for (int i = count - 1; i > 0; i--)
                        {
                            Destroy(instances[i]);
                        }

                        return instance = instances[0];
                    }

                    instance = new GameObject("!" + typeof(T).ToString() + " - Singleton").AddComponent<T>(); 
                    return instance;
                }
            }
        }

        private void Awake()
        {
            if (this.persistent)
            {
                DontDestroyOnLoad(this.gameObject);
            }

            OnAwake();
        }       

        protected virtual void OnAwake() { }
        public void LoadSingletonObject()
        {
            /// Hello reader.
        }
    }

    public abstract class Singleton : MonoBehaviour
    {
        bool quitting = false;

        public bool LocalQuitting => quitting;

        public static bool Quitting { get; private set; }

        private void OnApplicationQuit()
        {
            Quitting = true;
            quitting = true;
        }
    }

}