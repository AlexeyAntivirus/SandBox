

using SandDefender.Gameplay;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace SandDefender.Library.Game
{
    public class GameCanvas: MonoBehaviour
    {

        [SerializeField]
        private Canvas _canvas;
        public Canvas Canvas
        {
            get { return _canvas; }
        }

        [SerializeField]
        private bool _active;
        public bool Active
        {
            get { return _active; }
            set
            {
                _active = value;
                Canvas.gameObject.SetActive(value);
            }
        }

        protected CanvasVisibilityController Controller;

        protected virtual void Start()
        {
            Controller = GameObject.Find("MainCamera").GetComponent<CanvasVisibilityController>();
        }

    }
}