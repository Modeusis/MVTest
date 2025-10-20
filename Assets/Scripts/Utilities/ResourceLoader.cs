using System.Text;
using UnityEngine;

namespace Utilities
{
    public class ResourceLoader
    {
        private const string PrefabResourcesPath = "Prefabs/";
        
        public T LoadPrefab<T>(Transform parent) where T : Object
        {
            var pathString = new StringBuilder(PrefabResourcesPath);
            
            pathString.Append(typeof(T).Name);
            
            var prefab = Resources.Load<T>(pathString.ToString());

            if (prefab == null)
            {
                Debug.LogWarning("Failed to load prefab: " + pathString);

                return null;
            }

            return Object.Instantiate(prefab, parent);
        }
    }
}