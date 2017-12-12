using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace SandDefender.Library.Game.Level
{
    public static class Levels
    {
        public sealed class LevelRepresentation
        {
            public int[][] Matrix { get; set; }
            public Wave[] Waves { get; set; }

            public LevelRepresentation(int[][] matrix, Wave[] waves)
            {
                Matrix = matrix;
                Waves = waves;
            }
        }
        public sealed class LevelsIndexer
        {
            public LevelRepresentation this[Level index]
            {
                get { return new LevelRepresentation(_matrices[(int) index], _wavesArrays[(int) index]); }
            }

            public int[][] this[int index]
            {
                get { return _matrices[index]; }
            }
        }
        
        private static List<int[][]> _matrices = new List<int[][]>
        {
            new[]{
                new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                new[]{2,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                new[]{0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                new[]{0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                new[]{0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0},
                new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0},
                new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0},
                new[]{0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0},
                new[]{0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                new[]{0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                new[]{0,1,1,1,1,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0},
                new[]{0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0},
                new[]{0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0},
                new[]{0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0},
                new[]{0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1,0},
                new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0},
                new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0},
                new[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0},
                new[]{0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
                new[]{0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
            }
        };

        private static List<Wave[]> _wavesArrays = new List<Wave[]>
        {
            new[]
            {
                new Wave(5, 5, 0), 
                new Wave(5, 5, 10),
                new Wave(5, 5, 20),
                new Wave(6, 5, 30),
                new Wave(6, 6, 40),
                new Wave(8, 6, 50),
                new Wave(8, 6, 60),
                new Wave(9, 6, 70),
                new Wave(10, 7, 80),
                new Wave(11, 7, 90),
                new Wave(11, 7, 100),
                new Wave(12, 8, 110),
                new Wave(13, 8, 120),
                new Wave(15, 9, 130),
                new Wave(15, 9, 140)
            }
        };

        private static LevelsIndexer _levelsIndexer = new LevelsIndexer();
        public static LevelsIndexer Matrix
        {
            get { return _levelsIndexer; }
        }
    }

}