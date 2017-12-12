using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using SandDefender.Library.Game.Level.Wrappers;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace SandDefender.Library.Game.Level
{
    public class Cell
    {
        private GameObject _cellGameObject;
        public GameObject CellGameObject
        {
            get { return _cellGameObject; }
            set { _cellGameObject = value; }
        }

        [XmlAttribute("texture")]
        public CellTexture CellTexture { get; set; }
        
        [XmlAttribute("name")]
        public string CellName { get; set; }
        
        [XmlElement("position")]
        public Vector3Wrapper Position { get; set; }
        
        [XmlElement("scale")]
        public Vector3Wrapper Scale { get; set; }

        public Cell(GameObject cellGameObject, CellTexture cellTexture)
        {
            _cellGameObject = cellGameObject;
            CellName = cellGameObject.name;
            CellTexture = cellTexture;
            Position = cellGameObject.transform.localPosition;
            Scale = cellGameObject.transform.localScale;
        }
    }
}