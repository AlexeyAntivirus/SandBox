using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
namespace SandDefender.Gameplay.BattleUI
{
    public class BuildingPanel : MonoBehaviour
    {
        [SerializeField]
        private Image _image;

        [SerializeField]
        private StatePanel _statePanel;

        private GameObject _sand;

        private void Start()
        {
            Physics.queriesHitTriggers = true;
            GetComponent<Image>().enabled = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                print("X");
                if (gameObject.activeSelf)
                {
                    GetComponent<Image>().enabled = false;
                }
            }
        }

        public void ReceiveSand(GameObject sand)
        {
            print("A");
            _sand = sand;
        }

        public void Show()
        {
            print("AA");
            GetComponent<Image>().enabled = true;
        }
        
        public void MouseDown()
        {
            if (_sand != null)
            {
                if (_statePanel.CoinCount > 30)
                {
                    var tower = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Game/Tower.prefab"));
                    tower.transform.SetParent(GameObject.Find("BattleField").transform);
                    tower.transform.localScale = Vector3.one;
                    tower.transform.localPosition = _sand.transform.localPosition;
                    _statePanel.CoinCount -= 30;
                } 
                
            }
        }

        private void OnMouseEnter()
        {
            _image.color = Color.green + Color.grey;
        }

        private void OnMouseExit()
        {
            _image.color = Color.white;
        }
    }
}