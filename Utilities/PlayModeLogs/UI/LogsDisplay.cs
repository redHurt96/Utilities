using System.Collections.Generic;
using UnityEngine;
using RH.Utilities.PlayModeLogs.Core;

namespace RH.Utilities.PlayModeLogs.UI
{
    public class LogsDisplay : MonoBehaviour
    {
        public List<LogDisplayItem> LogsItems { get; private set; } = new List<LogDisplayItem>();

        [SerializeField] private Transform _itemsParent;
        [SerializeField] private LogDisplayItem _logItemPrefab;
        [SerializeField] private FullLogPresentator _fullLogPresentator;

        private void Awake()
        {
            new LogsReciever();
            LogsList.OnLogRecieved += PerformOnLogRecieved;

            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            LogsList.OnLogRecieved -= PerformOnLogRecieved;
        }

        private void PerformOnLogRecieved(Log log)
        {
            LogDisplayItem item = Instantiate(_logItemPrefab, _itemsParent);
            
            item.Init(log);
            item.OnClick += () => _fullLogPresentator.ShowLog(log);

            LogsItems.Add(item);
        }
    }
}