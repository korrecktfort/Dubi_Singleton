using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System;

namespace Dubi.SingletonSpace
{
    public abstract class AsyncLoadSingleton<T, U> : Singleton<T> where U : Component where T : MonoBehaviour
    {
        protected U Component { get => this.component; }
        U component = null;

        protected bool Valid { get => this.component != null; }

        protected abstract string Key { get; } 
       
        protected override void OnAwake()
        {
            base.OnAwake();

            //Addressables.LoadAssetAsync<GameObject>(Key).Completed += (asyncHandler) =>
            //{
            //    GameObject obj = Instantiate(asyncHandler.Result);
            //    obj.transform.SetParent(this.transform);

            //    this.component = obj.GetComponentInChildren<U>();

            //    OnComponentLoaded(this.component);
            //};
        }

        public abstract void OnComponentLoaded(U component);
    }
}
