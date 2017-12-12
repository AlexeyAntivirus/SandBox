
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace SandDefender.Library.Settings
{
    public class CloseGame
    {
        public static void Do()
        {

#if UNITY_STANDALONE
            Application.Quit();
#endif
        }
    }
}