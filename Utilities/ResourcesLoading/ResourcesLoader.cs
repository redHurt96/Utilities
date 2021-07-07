using UnityEngine;

namespace RH.Utilities.ResourcesLoading
{
    public static class ResourcesLoader
    {
        private static BaseResourcesFactory _resourcesFactory;

        static ResourcesLoader()
        {
            _resourcesFactory = new BaseResourcesFactory();
        }

        public static T Get<T>(string name) where T : Object
            => _resourcesFactory.Get<T>(name);

        public static T Instantiate<T>(string name, Transform parent = null) where T : Component
            => _resourcesFactory.Instantiate<T>(name, parent);
    }
}