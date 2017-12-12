using System;
using System.Collections.Generic;
using SandDefender.Gameplay.BattleUI;
using UnityEngine;



// ReSharper disable once CheckNamespace
namespace SandDefender.Library.Game
{
	public class Tower : MonoBehaviour
	{
		public float Range;
		public float Cooldown;
		public float Damage;
		private float _currentCooldown;
		private Queue<GameObject> _enemyTargets = new Queue<GameObject>();
		private List<GameObject> _enemies;
		private GameObject _currentTarget;

		private void Start()
		{
			var circleCollider2D = GetComponent<CircleCollider2D>();
			circleCollider2D.radius = Range;
			circleCollider2D.isTrigger = true;
			_enemies = GameObject.Find("BattleField").GetComponent<BattleField>().GetEnemies();
			_currentCooldown = 0;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (!other.gameObject.name.StartsWith("Quad")) return;
			
			var target = other.gameObject;
			if (_currentTarget == null)
			{
				_currentTarget = target;
			}
			else
			{
				_enemyTargets.Enqueue(target);
			}
		}

		private void OnTriggerStay2D(Collider2D other)
		{
			if (!other.gameObject.name.StartsWith("Quad")) return;
			
			if (Math.Abs(_currentCooldown - Cooldown) <= 0.005f)
			{
				_currentTarget.GetComponent<Enemy>().HitPoints -= (int) Damage;
				_currentCooldown = 0;
			}
			else
			{
				_currentCooldown = Mathf.Clamp(_currentCooldown + Time.deltaTime, 0, Cooldown - 0.005f);
			}
			
			if (_currentTarget.GetComponent<Enemy>().HitPoints <= 0)
			{
				_enemies.Remove(_currentTarget);
				var temp = _enemyTargets.Dequeue();
				
				_currentTarget = temp;
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (!other.gameObject.name.StartsWith("Quad")) return;
			
			_currentTarget = _enemyTargets.Dequeue();
		}
	}
}
