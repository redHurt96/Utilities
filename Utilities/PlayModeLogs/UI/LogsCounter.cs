using RH.Utilities.PlayModeLogs.Core;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogsCounter : MonoBehaviour
{
    [SerializeField] private Text _countText;
    [SerializeField] private List<LogType> _types;

    private int count
    {
        get => _count;
        set
        {
            _count = value;
            _countText.text = _count.ToString();
        }
    }

    private int _count;

    private void Awake()
    {
        LogsList.OnLogRecieved += UpdateCountText;
    }

    private void UpdateCountText(Log log)
    {
        if (_types.Contains(log.Type))
            count++;
    }
}
