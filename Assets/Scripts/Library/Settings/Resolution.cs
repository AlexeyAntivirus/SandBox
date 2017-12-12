using System;
using System.Xml.Serialization;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace SandDefender.Library.Settings
{
    [XmlRoot("resolution")]
    public class Resolution
    {
        [XmlAttribute("width")]
        public int Width { get; set; }

        [XmlAttribute("height")]
        public int Height { get; set; }

        [XmlAttribute("rate")]
        public int Rate { get; set; }

        public Resolution()
        {
            Width = Screen.currentResolution.width;
            Height = Screen.currentResolution.height;
            Rate = Screen.currentResolution.refreshRate;
        }
        
        public Resolution(int width, int height, int rate)
        {
            Width = width;
            Height = height;
            Rate = rate;
        }

        public override bool Equals(object obj)
        {
            var resolutionObj = obj as Resolution;

            if (resolutionObj != null)
            {
                return resolutionObj.Width == Width
                    && resolutionObj.Height == Height
                    && resolutionObj.Rate == Rate;
            }

            var resolutionStr = obj as string;

            return resolutionStr != null && resolutionStr.Equals(ToString());
        }

        public override int GetHashCode()
        {
            return (Width + Height + Rate) << 1;
        }

        public override string ToString()
        {
            return Width + "x" + Height + " " + Rate + "Hz";
        }
    }
}