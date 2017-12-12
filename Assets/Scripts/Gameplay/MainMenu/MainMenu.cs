using System.Collections;
using System.Collections.Generic;
using SandDefender.Library.Game;
using SandDefender.Library.Settings;
using UnityEngine;



// ReSharper disable once CheckNamespace
namespace SandDefender.Gameplay.MainMenu
{
	public class MainMenu : GameCanvas
	{
		protected override void Start()
		{
			base.Start();
			
			Canvas.gameObject.SetActive(Active);
		}

		private void Update()
		{

		}

		public void StartGame()
		{
			Controller.SwitchTo("StartGameCanvas");
		}

		public void ShowSettings()
		{
			
			Controller.SwitchTo("SettingsUICanvas");
		}

		public void ExitGame()
		{
			CloseGame.Do();
		}
	}
}