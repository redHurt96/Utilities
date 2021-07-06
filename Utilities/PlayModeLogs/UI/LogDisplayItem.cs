using RH.Utilities.PlayModeLogs.Core;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace RH.Utilities.PlayModeLogs.UI
{
    public class LogDisplayItem : MonoBehaviour
    {
        public event Action OnClick;

        public LogType LogType => _log.Type;
        public string FullLog => $"{_log.Condition}\n{_log.StackTrace}";
        public bool IsActive => gameObject.activeSelf;

        [SerializeField] private Text _description;
        [SerializeField] private Button _button;

        private Log _log;

        [SerializeField]
        public void Init(Log log)
        {
            _log = log;
            _description.color = log.Color;
            _description.text = log.Condition;

            _button.onClick.AddListener(() => OnClick?.Invoke());
        }

        public void Enable() => gameObject.SetActive(true);
        public void Disable() => gameObject.SetActive(false);
    }
}