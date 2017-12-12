

using System;
using System.Xml.Serialization;

// ReSharper disable once CheckNamespace
namespace SandDefender.Library.Settings
{
    [XmlRoot("audio")]
    [Serializable]
    public class AudioSettings
    {
        [XmlAttribute("music-volume")]
        public float MusicVolume { get; set; }

        [XmlAttribute("effects-volume")]
        public float EffectsVolume { get; set; }

        public AudioSettings()
        {
            MusicVolume = 25f;
            EffectsVolume = 25f;
        }
        
        public AudioSettings(float musicVolume, float effectsVolume)
        {
            MusicVolume = musicVolume;
            EffectsVolume = effectsVolume;
        }

        public override bool Equals(object obj)
        {
            var audio = obj as AudioSettings;

            if (audio != null)
            {
                return Math.Abs(audio.MusicVolume - MusicVolume) < 0.00005f;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (int) Math.Round(MusicVolume) << 1;
        }
    }
}