using UnityEngine;

namespace RH.Utilities.PlayModeLogs.Core
{
    public class LogsReciever
    {
        public LogsReciever()
        {
            Application.logMessageReceived += OnLogMessageReceived;
        }

        private void OnLogMessageReceived(string condition, string stackTrace, LogType type)
        {
            LogsList.Add(new Log(condition, stackTrace, type));
        }
    }
}
