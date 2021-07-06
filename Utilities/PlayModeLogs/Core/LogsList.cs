using System;
using System.Collections.Generic;

namespace RH.Utilities.PlayModeLogs.Core
{
    public class LogsList
    {
        public static event Action<Log> OnLogRecieved;

        public static readonly List<Log> Logs = new List<Log>();

        public static void Add(Log log)
        {
            OnLogRecieved?.Invoke(log);
            Logs.Add(log);
        }
    }
}
