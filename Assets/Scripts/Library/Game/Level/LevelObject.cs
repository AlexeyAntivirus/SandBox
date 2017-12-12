
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;


// ReSharper disable once CheckNamespace
namespace SandDefender.Library.Game.Level
{
    [XmlRoot("level")]
    public class LevelObject
    {
        [XmlArray("cellsArray")]
        [XmlArrayItem("cells")]
        private Cells[] _cellsArray;
        
        [XmlElement("start-point")]
        public Coord StartPoint { get; set; }
        
        [XmlElement("end-point")]
        public Coord EndPoint { get; set; }
        
        public List<Wave> Waves { get; set; }
        
        public Dictionary<Cell, Coord> RoadCells { get; set; }

        public int Length
        {
            get { return _cellsArray.Length; }
        }

        public Cells this[int index]
        {
            get { return _cellsArray[index]; }
        }
        
        public Cell this[Coord index]
        {
            get { return _cellsArray[index.Row][index.Col]; }
        }

        public LevelObject(Cells[] cellsArray, List<Wave> waves)
        {
            _cellsArray = cellsArray;

            for (int row = 0; row < cellsArray.Length; row++)
            {
                for (int col = 0; col < cellsArray[row].Length; col++)
                {
                    switch (cellsArray[row][col].CellTexture)
                    {
                        case CellTexture.StartPoint:
                            StartPoint = new Coord(row, col);
                            break;
                        case CellTexture.EndPoint:
                            EndPoint = new Coord(row, col);
                            break;
                        case CellTexture.Sand1:
                        case CellTexture.Road1:
                            break;
                        default: throw new Exception("Dummy Exception!");
                    }
                }
            }

            RoadCells = InitRoad();
            Waves = waves;
        }

        private Dictionary<Cell, Coord> InitRoad()
        {
            var roadCells = new Dictionary<Cell, Coord>();

            var currentCoord = StartPoint;

            
            do
            {
                if (IsPossibleDirection(currentCoord + new Coord(1, 0), roadCells))
                {
                    currentCoord = new Coord(1, 0) + currentCoord;
                    roadCells.Add(this[currentCoord], new Coord(1, 0));
                }
                else if (IsPossibleDirection(currentCoord + new Coord(-1, 0), roadCells))
                {
                    currentCoord = new Coord(-1, 0) + currentCoord;
                    roadCells.Add(this[currentCoord], new Coord(-1, 0));
                }
                else if (IsPossibleDirection(currentCoord + new Coord(0, 1), roadCells))
                {
                    currentCoord = new Coord(0, 1) + currentCoord;
                    roadCells.Add(this[currentCoord], new Coord(0, 1));
                }
                else if (IsPossibleDirection(currentCoord + new Coord(0, -1), roadCells))
                {
                    currentCoord = new Coord(0, -1) + currentCoord;
                    roadCells.Add(this[currentCoord], new Coord(0, -1));
                }
            } while (
                currentCoord.Row != EndPoint.Row ||
                currentCoord.Col != EndPoint.Col);
           
            return roadCells;
        }

 
        private bool IsPossibleDirection(Coord coord, Dictionary<Cell, Coord> road)
        {
            var isInRowConstraint = coord.Row >= 0 && coord.Row <= _cellsArray.Length;
            var isInColConstraint = coord.Col >= 0 && coord.Col <= _cellsArray[0].Length;
            var isNotSand1Texture = this[coord].CellTexture != CellTexture.Sand1;
            var isNotContainsInRoad = !road.ContainsKey(this[coord]);
            
            return isInRowConstraint && isInColConstraint 
                   && isNotSand1Texture 
                   && isNotContainsInRoad;
        }
    }

}