
using System;
using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace SandDefender.Gameplay
{
    public class CanvasVisibilityController : MonoBehaviour
    {
        [SerializeField] 
        private List<CanvasVisibility> _canvases = new List<CanvasVisibility>();

        [SerializeField] 
        private int _activeCanvasIndex;

        public void SwitchTo(string canvasName)
        {
            print(canvasName);
            var currentCanvas = _canvases[_activeCanvasIndex];
            var targetCanvasIndex = _canvases.FindIndex(canvas => canvas.Canvas.name.Equals(canvasName));
            var targetCanvas = _canvases[targetCanvasIndex];
            
            print("Before[current: `" + _activeCanvasIndex + "`, target: `" + targetCanvasIndex + "`]");
            _activeCanvasIndex = _canvases.IndexOf(targetCanvas);
           
            currentCanvas.SetActive(false);
            targetCanvas.SetActive(true);
            
            print("Before[current: `" + _activeCanvasIndex + "`, target: `" + targetCanvasIndex + "`]");
        }
    }

    [Serializable]
    public class CanvasVisibility
    {
        [SerializeField] 
        private Canvas _canvas;

        [SerializeField] 
        private bool _isDeactivatingLogic;
       

        public Canvas Canvas
        {
            get { return _canvas; }
            set { _canvas = value; }
        }

        public bool IsDeactivatingLogic
        {
            get { return _isDeactivatingLogic; }
            set { _isDeactivatingLogic = value; }
        }

        public void SetActive(bool isActive)
        {
            if (IsDeactivatingLogic)
            {
                _canvas.gameObject.SetActive(isActive);
            }
            else
            {
                _canvas.enabled = isActive;
            }
        }

        public CanvasVisibility(Canvas canvas, bool isDeactivatingLogic)
        {
            _canvas = canvas;
            _isDeactivatingLogic = isDeactivatingLogic;
        }

        public override string ToString()
        {
            return Canvas.name + ": " + _isDeactivatingLogic;
        }
    }
}