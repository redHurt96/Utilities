using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RH.Utilities.PlayModeLogs.UI
{
    public class SortersList : MonoBehaviour
    {
        [SerializeField] private LogsDisplay _logsDisplay;
        [SerializeField] private LogsSorter[] _sorters;

        private void Awake()
        {
            foreach (var sorter in _sorters)
                sorter.OnClick += () => Sort(sorter);
        }

        private void Sort(LogsSorter sorter)
        {
            if (sorter.IsSelected)
                ShowAllItems();
            else
                HideLogsItems(sorter);
        }

        private void HideLogsItems(LogsSorter sorter)
        {
            ShowAllItems();

            foreach (LogDisplayItem item in _logsDisplay.LogsItems)
            {
                if (!sorter.LogsTypes.Contains(item.LogType))
                    item.Disable();
            }

            sorter.IsSelected = true;
        }

        private void ShowAllItems()
        {
            foreach (LogDisplayItem item in _logsDisplay.LogsItems)
            {
                if (!item.IsActive)
                    item.Enable();
            }

            foreach (var sorter in _sorters)
                sorter.IsSelected = false;
        }
    }
}