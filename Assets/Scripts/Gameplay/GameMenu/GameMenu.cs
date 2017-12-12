using System.Collections;
using System.Collections.Generic;
using SandDefender.Library.Game;
using SandDefender.Library.Settings;
using UnityEngine;
using UnityEngine.SceneManagement;


// ReSharper disable once CheckNamespace
namespace SandDefender.Gameplay.GameMenu
{
	public class GameMenu : GameCanvas
	{
		protected override void Start()
		{
			base.Start();
			
			Canvas.gameObject.SetActive(Active);
		}
		
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
				Controller.SwitchTo("BattleUICanvas");
		}

		public void ShowSettings()
		{
			Controller.SwitchTo("SettingsUICanvas");
		}

		public void ReturnToGame()
		{
			Controller.SwitchTo("BattleUICanvas");
		}

		public void ExitToMenu()
		{
			SceneManager.LoadScene("MainMenu");
		}

		public void ExitGame()
		{
			CloseGame.Do();
		}
	}
}