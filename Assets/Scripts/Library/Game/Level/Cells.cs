
using System.Xml.Serialization;

// ReSharper disable once CheckNamespace
namespace SandDefender.Library.Game.Level
{
    public class Cells
    {
        [XmlArray("cells")]
        [XmlArrayItem("cell")]
        private Cell[] _cells;

        public int Length
        {
            get { return _cells.Length; }
        }

        public Cell this[int index]
        {
            get { return _cells[index]; }
            set { _cells[index] = value; }
        }

        public Cells(Cell[] cells)
        {
            _cells = cells;
        }
    }
}