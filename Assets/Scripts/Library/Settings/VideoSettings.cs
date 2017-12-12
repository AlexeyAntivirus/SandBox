

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace SandDefender.Library.Settings
{
    [XmlRoot("video")]
    public class VideoSettings
    {
        public static readonly List<Resolution> AvailableResolutions = new List<Resolution>();
        
        [XmlElement("resolution")]
        public Resolution Resolution { get; set; }

        public VideoSettings()
        {
            Resolution = new Resolution();
            
            foreach (var resolution in Screen.resolutions)
            {
                var resolutionSpec = new Resolution(
                    width: resolution.width,
                    height: resolution.height,
                    rate: resolution.refreshRate);
                if (!AvailableResolutions.Contains(resolutionSpec))
                {
                    AvailableResolutions.Add(resolutionSpec);
                }
            }
            
            if (AvailableResolutions.Count == 0)
            {
                AvailableResolutions.Add(new Resolution(1920, 1080, 60));
                AvailableResolutions.Add(new Resolution(1024, 768, 60));
                AvailableResolutions.Add(new Resolution(800, 600, 60));
            }
        }
        
        public VideoSettings(Resolution resolution)
        {
            Resolution = resolution ?? new Resolution();
        }

        public override bool Equals(object obj)
        {
            var video = obj as VideoSettings;

            return video != null && Resolution.Equals(video.Resolution);
        }

        public override int GetHashCode()
        {
            return Resolution.GetHashCode() << 1;
        }


    }
}