using System.Xml.Serialization;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace SandDefender.Library.Game.Level
{
    public class Coord
    {
        [XmlAttribute("row")]
        public int Row { get; set; }
        
        [XmlAttribute("col")]
        public int Col { get; set; }

        public Coord(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public static Coord operator +(Coord self, Coord other)
        {
            return new Coord(self.Row + other.Row, self.Col + other.Col);
        }

        public override string ToString()
        {
            return "Row: " + Row + " Col: " + Col;
        }

        public Vector3 ToVector3()
        {
            return new Vector3(Col, -Row);
        }
    }
}