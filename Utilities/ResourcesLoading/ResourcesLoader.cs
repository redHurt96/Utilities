using System.Collections.Generic;
using UnityEngine;

namespace RH_Utilities.ResourcesLoading
{
    public static class ResourcesLoader
    {
        private static List<Object> _loadedObjects = new List<Object>();

        public static T Get<T>(string name) where T : Object
        {
            if (IsLoaded(name))
                return GetLoadedObject<T>(name);
            else
                return Load<T>(name);
        }

        private static bool IsLoaded(string name)
            => GetLoadedObject<Object>(name) != null;

        private static T GetLoadedObject<T>(string name) where T : Object
            => _loadedObjects.Find(x => x.name.Equals(name)) as T;

        private static T Load<T>(string name) where T : Object
        {
            var resource = Resources.Load<T>(name);
            _loadedObjects.Add(resource);
            return resource;
        }
    }
}