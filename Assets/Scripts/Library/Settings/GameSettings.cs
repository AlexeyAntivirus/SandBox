

using System;
using System.Xml.Serialization;

// ReSharper disable once CheckNamespace
namespace SandDefender.Library.Settings
{
    [XmlRoot("settings")]
    public class GameSettings
    {
        [XmlElement("video")]
        public VideoSettings Video { get; set; }

        [XmlElement("audio")]
        public AudioSettings Audio { get; set; }

        public GameSettings()
        {
            Video = new VideoSettings();
            Audio = new AudioSettings();
        }
        
        public GameSettings(
            AudioSettings audio, 
            VideoSettings video)
        {
            Video = video ?? new VideoSettings();
            Audio = audio ?? new AudioSettings();
        }

        public override bool Equals(object obj)
        {
            var settings = obj as GameSettings;
            
            if (settings != null)
            {
                return Video.Equals(settings.Video) && Audio.Equals(settings.Audio);
            }
            
            return false;
        }

        public override int GetHashCode()
        {
            return (Audio.GetHashCode() << 1) + (Video.GetHashCode() << 1);
        }
    }
}