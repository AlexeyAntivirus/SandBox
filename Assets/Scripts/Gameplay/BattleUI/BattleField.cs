
using System;
using System.Collections.Generic;
using System.Linq;
using SandDefender.Library.Game;
using SandDefender.Library.Game.Level;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

// ReSharper disable once CheckNamespace
namespace SandDefender.Gameplay.BattleUI
{
	public class BattleField : MonoBehaviour, IDragHandler, IScrollHandler
	{
		[SerializeField]
		private GameObject _battleField;
		
		[SerializeField]
		private GameObject _gamePanel;

		[SerializeField] 
		private Level _levelName;

		private LevelObject _levelObject;

		private int _currentWave;

		private List<GameObject> _enemies = new List<GameObject>();
		

		private int _enemyMaxCount;
		

		private void Start ()
		{
			var level = Levels.Matrix[_levelName];
			var matrix = level.Matrix;

			var waves = level.Waves;
            
			var cellsArray = new Cells[20];

			
			for (var row = 0; row < 20; row++)
			{
				var cells = new Cell[20];
				
				for (var col = 0; col < 20; col++)
				{
					var cellType = (CellTexture) matrix[row][col];
					var cellObject = 
						Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Textures/" + Enum.GetName(cellType.GetType(), cellType) + ".prefab"));
					cellObject.name = Enum.GetName(cellType.GetType(), cellType) + "-" + row + "-" + col;
					cellObject.transform.SetParent(_battleField.transform);
					cellObject.transform.localPosition = new Vector3(-1216 + col * 128, 1216 - row * 128);
					cellObject.transform.localScale = Vector3.one;

					cells[col] = new Cell(cellObject, cellType);
				}

				cellsArray[row] = new Cells(cells);
			}

			_levelObject = new LevelObject(cellsArray, waves.ToList());
		}



		public LevelObject GetCurrentLevel()
		{
			return _levelObject;
		}

		public List<GameObject> GetEnemies()
		{
			return _enemies;
		}
		
		
		private void Update ()
		{

			if (Input.GetKeyDown(KeyCode.KeypadEnter) && _enemies.Count == 0)
			{
				InvokeRepeating("Spawn", 0.6f, 1.5f);
			}
		}
		
		private void Spawn()
		{
			var quad = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Game/Quad.prefab"));
			quad.transform.SetParent(_battleField.transform);
			quad.transform.localPosition = new Vector3(-1216 + _levelObject.StartPoint.Col * 128, 1216 - _levelObject.StartPoint.Row * 128);
			quad.transform.localScale = Vector3.one;
			quad.name = "Quad" + _enemyMaxCount;
			var component = quad.GetComponent<Enemy>();
			var currentWave = _levelObject.Waves[_currentWave];
			component.HitPoints += currentWave.HpIncrease;
			component.Coins = currentWave.CoinPerEnemy;

			_enemies.Add(quad);
			_enemyMaxCount++;

			if (_enemyMaxCount == currentWave.EnemyCount)
			{
				_currentWave++;
				_enemyMaxCount = 0;
				CancelInvoke("Spawn");
			}
		}

		public void OnDrag(PointerEventData eventData)
		{
			var gpRectTransform = _gamePanel.GetComponent<RectTransform>();
			var bfRectTransform = _battleField.GetComponent<RectTransform>();
			
			var x = eventData.delta.x * 2 + bfRectTransform.localPosition.x;
			var y = eventData.delta.y * 2 + bfRectTransform.localPosition.y;

			var xExtremum = 250 + Math.Abs(bfRectTransform.rect.width * bfRectTransform.localScale.x / 2 - gpRectTransform.rect.width / 2);
			var yExtremum = 250 + Math.Abs(bfRectTransform.rect.height * bfRectTransform.localScale.y / 2 - gpRectTransform.rect.height / 2);
			
			bfRectTransform.localPosition = new Vector3(
				Mathf.Clamp(x, -xExtremum, xExtremum),
				Mathf.Clamp(y, -yExtremum, yExtremum));
			
		}

		public void OnScroll(PointerEventData eventData)
		{
			var bfRectTransform = _battleField.GetComponent<RectTransform>();

			var x = eventData.scrollDelta.y / 12 + bfRectTransform.localScale.x;
			var y = eventData.scrollDelta.y / 12 + bfRectTransform.localScale.y;

			var oldV = bfRectTransform.localScale;
			var newV = new Vector3(
				Mathf.Clamp(x, 0.8f, 3.0f),
				Mathf.Clamp(y, 0.8f, 3.0f));
			
			bfRectTransform.localScale = newV;
			
		}
	}
}
