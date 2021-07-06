using UnityEngine;
using UnityEngine.UI;
using RH.Utilities.PlayModeLogs.Core;

public class AllLogsCounter : MonoBehaviour
{
    [SerializeField] private Text _countText;

    private int _logsCount;
    private int _warningsCount;
    private int _errorsCount;

    private void Awake()
    {
        LogsList.OnLogRecieved += UpdateCount;
    }

    private void UpdateCount(Log log)
    {
        switch (log.Type)
        {
            case LogType.Log:
            case LogType.Assert:
                _logsCount++;
                break;
            case LogType.Warning:
                _warningsCount++;
                break;
            case LogType.Exception:
            case LogType.Error:
                _errorsCount++;
                break;
        }

        _countText.text = $"<color=white>{_logsCount}</color>/" +
            $"<color=yellow>{_warningsCount}</color>/" +
            $"<color=red>{_errorsCount}</color>";
    }
}