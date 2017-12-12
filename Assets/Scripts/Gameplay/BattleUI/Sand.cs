using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
namespace SandDefender.Gameplay.BattleUI
{
    public class Sand : MonoBehaviour
    {
        
        private void Start()
        {
            Physics.queriesHitTriggers = true;
        }

        public void Run()
        {
            print("AAAAAAAAAAAAA");
            
            GameObject.Find("BuildingPanel").GetComponent<Image>().enabled = true;
            GameObject.Find("BuildingPanel").GetComponent<BuildingPanel>().ReceiveSand(gameObject);
        }
    }
}