using System.Collections.Generic;
using System.Linq;
using SandDefender.Gameplay.BattleUI;
using SandDefender.Library.Game.Level;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
namespace SandDefender.Library.Game
{
    public class Enemy : MonoBehaviour
    {
        
        private int _roadCellIndex;

        private Dictionary<Cell, Coord> _roadCells;

        private List<GameObject> _enemies;

        private List<Cell> _keys;
        
        private RectTransform _enemyRectTransform;

        private StatePanel _state;

        private RectTransform _enemyObjectRectTransform;
        
        [SerializeField] 
        private int _hitPoints;
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;
                gameObject.GetComponentInChildren<Text>().text = "" + _hitPoints;
            }
        }

        [SerializeField] 
        private int _speed;
        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public int Coins { get; set; }

        private void Start()
        {
            gameObject.GetComponentInChildren<Text>().text = "" + _hitPoints;
            _enemyRectTransform = GetComponent<RectTransform>();
            _roadCells = GameObject.Find("BattleField").GetComponent<BattleField>().GetCurrentLevel().RoadCells;
            _keys = _roadCells.Keys.ToList();
            _enemies = GameObject.Find("BattleField").GetComponent<BattleField>().GetEnemies();
            _state = GameObject.Find("StatePanel").GetComponent<StatePanel>();
            foreach (var componentsInChild in _enemyRectTransform.GetComponentsInChildren<RectTransform>())
            {
                if (componentsInChild.name == "Object")
                {
                    _enemyObjectRectTransform = componentsInChild;
                }
            }
        }

        private void Update()
        {
            Move();
            
            if (_hitPoints <= 0)
            {
                var find = _enemies.Find(enemy => gameObject == enemy);
                _enemies.Remove(find);
                _state.CoinCount += Coins;
                Destroy(gameObject);
            }
        }

        private void Move()
        {
            var norm = _roadCells[_keys[_roadCellIndex]];
            _enemyRectTransform.localPosition += norm.ToVector3() * Time.deltaTime * _speed;

            if (norm.ToVector3() == Vector3.right)
            {
                _enemyObjectRectTransform.localEulerAngles = new Vector3(0, 0, 270);
            }
            else if (norm.ToVector3() == Vector3.up)
            {
                _enemyObjectRectTransform.localEulerAngles = new Vector3(0, 0, 360);
            }
            else if (norm.ToVector3() == Vector3.down)
            {
                _enemyObjectRectTransform.localEulerAngles = new Vector3(0, 0, 180);
            }
            else if (norm.ToVector3() == Vector3.left)
            {
                _enemyObjectRectTransform.localEulerAngles = new Vector3(0, 0, 90);
            }
            
            if (Vector3.Distance(_enemyRectTransform.localPosition,
                    _keys[_roadCellIndex].CellGameObject.transform.localPosition) <= 15f)
            {
                if (_keys[_roadCellIndex].CellTexture != CellTexture.EndPoint)
                {
                    _roadCellIndex++;
                }
                else
                {
                    var find = _enemies.Find(enemy => gameObject == enemy);
                    _state.HitPoints -= 1;
                    _enemies.Remove(find);

                    Destroy(gameObject);
                }
            }
        }
    }
}