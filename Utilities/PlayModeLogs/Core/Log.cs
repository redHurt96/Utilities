using UnityEngine;

namespace RH.Utilities.PlayModeLogs.Core
{
    public struct Log
    {
        public string Condition;
        public string StackTrace;
        public LogType Type;

        public string FullLog => $"{Condition}\n{StackTrace}";

        public Color Color
        {
            get
            {
                Color color = default;

                switch (Type)
                {
                    case LogType.Error:
                    case LogType.Exception:
                        color = UnityEngine.Color.red;
                        break;
                    case LogType.Warning:
                        color = UnityEngine.Color.yellow;
                        break;
                    case LogType.Log:
                    case LogType.Assert:
                        color = UnityEngine.Color.white;
                        break;
                }

                return color;
            }
        }

        public Log(string condition, string stackTrace, LogType type)
        {
            Condition = condition;
            StackTrace = stackTrace;
            Type = type;
        }
    }
}