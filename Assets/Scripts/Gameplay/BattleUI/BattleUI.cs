
using SandDefender.Library.Game;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace SandDefender.Gameplay.BattleUI
{
	// ReSharper disable once InconsistentNaming
	public class BattleUI : GameCanvas
	{
		protected override void Start()
		{
			base.Start();
			
			Canvas.gameObject.SetActive(Active);
		}

		private void Update() 
		{
			if (Input.GetKeyDown(KeyCode.Escape) && Canvas.enabled)
			{
				Controller.SwitchTo("GameMenuCanvas");
			}
				
		}
	}
}
