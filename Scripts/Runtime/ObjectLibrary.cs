using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Dubi.SingletonSpace
{
    public abstract class ObjectLibrary<T> : Singleton<ObjectLibrary<T>>
    {
        private HashSet<T> registered = new HashSet<T>();

        public static void Register(T _object)
        {
            if (Quitting || Instance == null)
            {
                return;
            }

            Instance.RegisterOnInstance(_object);
        }

        public static void Unregister(T _object)
        {
            if (Quitting || Instance == null)
            {
                return;
            }

            Instance.UnregisterOnInstance(_object);
        }

        private void RegisterOnInstance(T _object)
        {
            registered.Add(_object);
        }

        private void UnregisterOnInstance(T _object)
        {
            registered.Remove(_object);
        }
    }
}