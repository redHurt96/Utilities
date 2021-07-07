﻿using System;
using System.Collections.Generic;
using UnityEngine;
using RH.Utilities.ResourcesLoading;
using RH.Utilities.UI.Elements.Core;
using RH.Utilities.UI.Extensions;

namespace RH.Utilities.UI
{
    public class UIManager
    {
        public static UIManager Instance { get; protected set; }

        private readonly Transform _parent;
        private readonly Stack<UIElement> _showedElements = new Stack<UIElement>();
        private readonly IAssetsFactory _assetsFactory;

        private bool _hasOpenedElements => _showedElements.Count > 0;

        protected UIManager(Transform parent, IAssetsFactory factory)
        {
            _parent = parent;
            _assetsFactory = factory;

            Instance = this;
        }

        public T Open<T>(string name, bool closeOthers = true) where T : UIElement => Open(name, closeOthers) as T;

        public UIElement Open(string fullAssetName, bool closeOthers = true)
        {
            var element = GetElement(fullAssetName);

            if (element.IsShowed)
                Debug.LogError($"[UIManager] Trying to show element, that already showed : {element.name}");
            else if (closeOthers && _hasOpenedElements)
                Closell(onDone: () => Open(fullAssetName, false));
            else
                OpenElement(element);

            return element;
        }

        public void Closell(Action onDone = null)
        {
            if (!_hasOpenedElements)
            {
                onDone?.Invoke();
            }
            else
            {
                int count = _showedElements.Count;

                for (int i = 0; i < count; i++)
                    Close(() => InvokeIfAllClosed(onDone));
            }
        }

        public void Close(UIElement element, Action onDone = null)
        {
            SetElementAsClosed(element);
            element.Close(onDone);
        }

        public void Close(Action onDone = null)
        {
            if (_hasOpenedElements)
                Close(_showedElements.Peek(), onDone);
        }

        private void SetElementAsOpen(UIElement element) => _showedElements.Push(element);
        private void SetElementAsClosed(UIElement element) => _showedElements.Remove(element);

        private void InvokeIfAllClosed(Action onDone)
        {
            if (!_hasOpenedElements)
                onDone?.Invoke();
        }

        private UIElement GetElement(string fullAssetName)
        {
            var actualName = GetActualName(fullAssetName);
            var element = TryGetLocalElement(actualName);

            if (element != null)
                return element;
            else
                return LoadElement(fullAssetName);

        }

        private UIElement TryGetLocalElement(string actualName)
        {
            foreach (Transform item in _parent)
            {
                if (item.gameObject.name.Equals(actualName))
                    return item.GetComponent<UIElement>();
            }

            return null;
        }

        private string GetActualName(string fullAssetName)
        {
            var splitName = fullAssetName.Split('\\');
            return splitName[splitName.Length - 1];
        }

        private UIElement LoadElement(string fullAssetName)
        {
            var element = _assetsFactory.Instantiate<UIElement>(fullAssetName, _parent);
            element.gameObject.SetActive(false);

            return element;
        }

        private void OpenElement(UIElement element)
        {
            element.Open();
            SetElementAsOpen(element);
        } 
    }
}