using UnityEngine;
using UnityEngine.UI;
using RH.Utilities.PlayModeLogs.Core;

namespace RH.Utilities.PlayModeLogs.UI
{
    public class FullLogPresentator : MonoBehaviour
    {
        [SerializeField] private Text _fullLog;

        public void ShowLog(Log log)
        {
            _fullLog.color = log.Color;
            _fullLog.text = log.FullLog;
        }
    }
}