
using SandDefender.Library.Settings;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
namespace SandDefender.Gameplay.BattleUI {

    public class StatePanel : MonoBehaviour
    {
        private Text _hitPointsBarText;

        private Text _coinCountBarText;
        
        [SerializeField]
        private int _hitPoints;

        [SerializeField]
        private int _coinCount;

        
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value > 10000 ? 10000 : value;
                _hitPointsBarText.text = _hitPoints.ToString();
            }
        }
        
        
        public int CoinCount
        {
            get { return _coinCount; }
            set
            {
                _coinCount = value > 100000 ? 100000 : value;
                _coinCountBarText.text = _coinCount.ToString();
            }
        }


        private void Start()
        {
            var statePanel = GetComponent<RectTransform>();

            foreach (var component in statePanel.GetComponentsInChildren<RectTransform>())
            {
                if (component.name.Equals("HitPointsBar"))
                {
                    _hitPointsBarText = component.GetComponentInChildren<Text>();
                } 
                else if (component.name.Equals("CoinCountBar"))
                {
                    _coinCountBarText = component.GetComponentInChildren<Text>();
                }
            }

            if (_hitPointsBarText == null ||
                _coinCountBarText == null)
            {
                throw new SandDefenderGameInitializationException(
                    "Hit points bar or coin count bar are not initialized!");
            }
            
            _hitPointsBarText.text = _hitPoints.ToString();
            _coinCountBarText.text = _coinCount.ToString();
        }
	

    }
}