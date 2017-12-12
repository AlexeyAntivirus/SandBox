

using System.Xml.Serialization;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace SandDefender.Library.Game.Level.Wrappers
{
    public class Vector3Wrapper
    {
        [XmlAttribute("x")]
        public float X { get; set; }
        
        [XmlAttribute("y")]
        public float Y { get; set; }
        
        [XmlAttribute("z")]
        public float Z { get; set; }

        public Vector3Wrapper(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        
        public static implicit operator Vector3(Vector3Wrapper rValue)
        {
            return new Vector3(rValue.X, rValue.Y, rValue.Z);
        }
     
        public static implicit operator Vector3Wrapper(Vector3 rValue)
        {
            return new Vector3Wrapper(rValue.x, rValue.y, rValue.z);
        }
    }
}