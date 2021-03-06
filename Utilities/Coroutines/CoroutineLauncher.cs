using System.Collections;
using UnityEngine;

namespace RH.Utilities.Coroutines
{
    public static class CoroutineLauncher
    {
        private static CoroutinesLauncherReciever _reciever;

        static CoroutineLauncher()
        {
            if (_reciever == null)
            {
                _reciever = new GameObject("CoroutinesLauncher", typeof(CoroutinesLauncherReciever))
                    .GetComponent<CoroutinesLauncherReciever>();
            }
        }

        public static Coroutine Start(IEnumerator coroutine) => _reciever.StartCoroutine(coroutine);

        public static void Stop(IEnumerator coroutine) => _reciever.StopCoroutine(coroutine);
        public static void Stop(Coroutine coroutine) => _reciever.StopCoroutine(coroutine);

        public static void StopAll() => _reciever.StopAllCoroutines();

        private class CoroutinesLauncherReciever : MonoBehaviour { }
    }
}