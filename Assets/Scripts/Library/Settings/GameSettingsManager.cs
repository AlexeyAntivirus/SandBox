using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace SandDefender.Library.Settings
{
    public class GameSettingsManager : MonoBehaviour
    {
        private static readonly string SettingsPath = Path.Combine(Path.GetFullPath("."), "settings.xml");

        private readonly XmlSerializer _settingsXmlSerializer = new XmlSerializer(typeof(GameSettings));

        private GameSettings _loadedSettings;

        
        private void Awake()
        {
            LoadOrDefault();
            Apply(_loadedSettings);
        }

        public void Save(GameSettings gameSettings)
        {
            try
            {
                using (var fileStream = new FileStream(SettingsPath, FileMode.Create))
                {
                    _settingsXmlSerializer.Serialize(fileStream, gameSettings);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public GameSettings LoadOrDefault()
        {
            if (_loadedSettings == null)
            {
                try
                {
                    using (var fileStream = new FileStream(SettingsPath, FileMode.Open))
                    {
                        _loadedSettings = _settingsXmlSerializer.Deserialize(fileStream) as GameSettings;
                    }
                }
                catch (Exception e)
                {
                    print("Settings file are not loaded. Using default settings!");
                
                    _loadedSettings = new GameSettings();
                    Save(_loadedSettings);
                }
            }
            
            return _loadedSettings;
        }

        public void Apply(GameSettings gameSettings)
        {
            var resolution = gameSettings.Video.Resolution;
            
            Screen.SetResolution(resolution.Width, resolution.Height, true, resolution.Rate);

            foreach (var objectWithMusic in GameObject.FindGameObjectsWithTag("Music"))
            {
                objectWithMusic.GetComponent<AudioSource>().volume = gameSettings.Audio.MusicVolume / 100;
                print("AA" + objectWithMusic.GetComponent<AudioSource>().volume);
            }
            
            foreach (var objectWithEffect in GameObject.FindGameObjectsWithTag("Effect"))
            {
                objectWithEffect.GetComponent<AudioSource>().volume = gameSettings.Audio.EffectsVolume / 100;
            }
        }

        public GameSettings Copy(GameSettings original)
        {
            return new GameSettings(
                video: new VideoSettings(
                    resolution: new Resolution(
                        width:  original.Video.Resolution.Width,
                        height: original.Video.Resolution.Height,
                        rate:   original.Video.Resolution.Rate)),
                audio: new AudioSettings(
                    musicVolume: original.Audio.MusicVolume,
                    effectsVolume: original.Audio.EffectsVolume));

        }

    }
}