using System.Collections;
using System.Collections.Generic;
using SandDefender.Library.Game;
using UnityEngine;
using UnityEngine.SceneManagement;

// ReSharper disable once CheckNamespace
namespace SandDefender.Gameplay.StartGameMenu
{
    public class StartGameMenu : GameCanvas 
    {
        
        protected override void Start()
        {
            base.Start();
            
            Canvas.gameObject.SetActive(Active);
        }

        private void Update() 
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Controller.SwitchTo("GameMenuCanvas");
        }

        public void StartTutorial()
        {
            SceneManager.LoadSceneAsync("Battle");
        }

        public void ChooseLevel()
        {
            
        }

        public void ExitToMenu()
        {
            Controller.SwitchTo("GameMenuCanvas");
        }
    }
}
