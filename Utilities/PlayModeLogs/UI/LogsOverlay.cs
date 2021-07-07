using System.Collections;
using UnityEngine;
using RH.Utilities.PlayModeLogs.Core;

namespace RH.Utilities.PlayModeLogs.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class LogsOverlay : MonoBehaviour
    {
        [SerializeField] private GameObject _logsDisplay;
        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            new LogsReciever();

            _canvasGroup = GetComponent<CanvasGroup>();
            
            _canvasGroup.alpha = 0f;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;

            StartCoroutine(DisableAfterLoad());
        }

        private IEnumerator DisableAfterLoad()
        {
            yield return null;

            _logsDisplay.SetActive(false);

            _canvasGroup.alpha = 1f;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }
    }
}