using System;
using UnityEngine;
using UnityEngine.UI;

namespace RH.Utilities.PlayModeLogs.UI
{
    [RequireComponent(typeof(Button))]
    public class LogsSorter : MonoBehaviour
    {
        public event Action OnClick;
        public LogType[] LogsTypes => _logsTypes;

        public bool IsSelected = false;

        [SerializeField] private LogType[] _logsTypes;
        [SerializeField] private Button _button;

        private void Awake()
        {
            _button.onClick.AddListener(() => OnClick?.Invoke());
        }
    }
}