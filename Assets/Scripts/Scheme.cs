using System;
using System.Collections.Generic;
using Unity.VisualScripting;


namespace Labyrint
{
    public struct Cell
    {
        public bool up;
        public bool rt;
        public bool dw;
        public bool lt;
    }

    public class Scheme
    {
        public static int VISS = 0;
        public static int WALL = 1;
        public static int CELL = 2;

        public int height   = 1;
        public int width    = 1;
        public int startHeight = 1;
        public int startWidth = 1;
        public int[][] maze;

        public Scheme (int width = 1, int height = 1)
        {
            this.height = width * 2 + 1;
            this.width = height * 2 + 1;
            this.startHeight = width;
            this.startWidth = height;


            this.building();
        }

        public Cell[][] getCells()
        {
            Cell[][] outData = new Cell[this.startHeight][];

            int mh;
            int mw;

            for (int h = 0; h < this.startHeight; h++)
            {
                outData[h] = new Cell[this.startWidth];
                for (int w = 0; w < this.startWidth; w++)
                {
                    mh = h * 2 + 1;
                    mw = w * 2 + 1;

                    outData[h][w] = new Cell();
                    outData[h][w].up = this.maze[mh-1][mw] == VISS;
                    outData[h][w].rt = this.maze[mh][mw+1] == VISS;
                    outData[h][w].dw = this.maze[mh+1][mw] == VISS;
                    outData[h][w].lt = this.maze[mh][mw-1] == VISS;
                }
            }

            return outData;
        }
        protected void building()
        {
            this.clean();
            int[] currentCell = { 1, 1 };
            int[] neighbourCell;

            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            Stack<int[]> stackCell = new Stack<int[]>();
            List<int[]> Neighbours;

            this.maze[currentCell[1]][currentCell[0]] = VISS;
            while (this.unvisitedCount())
            {
                Neighbours = this.getNeighbours(currentCell);
                if (Neighbours.Count > 0)
                {
                    neighbourCell = Neighbours[Convert.ToInt32(Math.Floor(rnd.NextDouble() * Neighbours.Count))];

                    stackCell.Push(new int[] { neighbourCell[0], neighbourCell[1] });

                    this.removeWall(currentCell, neighbourCell);
                    currentCell = neighbourCell;
                    this.maze[neighbourCell[1]][neighbourCell[0]] = VISS;
                }
                else if (stackCell.Count > 0)
                {
                    currentCell = stackCell.Pop();
                }
            }
        }

        protected List<int[]> getNeighbours(int[] c) {
            int dist = 2;
            int x = c[0];
            int y = c[1];

            int[][] d = {
                   new int[] { x, y - dist },   // up 0
                   new int[] { x + dist, y},    // rt 1
                   new int[] { x, y + dist},    // dw 2
                   new int[] { x - dist, y}     // lt 3
                };

            List<int[]> cells = new List<int[]> ();

			for (int i=0; i<d.Length; i++) {
				if (d[i][0]>0 && d[i][0]<this.width && d[i][1]>0 && d[i][1]<this.height) {
					if (this.maze[d[i][1]][d[i][0]] != WALL && this.maze[d[i][1]][d[i][0]] != VISS)
                        cells.Add(new int[] { d[i][0], d[i][1]} );
				}
}

            return cells;
		}

		protected bool unvisitedCount()  {
            for (int i = 0; i < this.height; i++)
                for (int j = 0; j < this.width; j++)
                    if (this.maze[i][j] == CELL) return true;

            return false;
        }

        protected void removeWall(int[] first, int[] second)
        {
            int xDiff = second[0] - first[0];
            int yDiff = second[1] - first[1];

            int addX = (xDiff != 0) ? (xDiff / Math.Abs(xDiff)) : 0;
            int addY = (yDiff != 0) ? (yDiff / Math.Abs(yDiff)) : 0;

            this.maze[first[1] + addY][first[0] + addX] = VISS;
        }

        private void clean()
        {
            this.maze = new int[this.height][];

            for (int h = 0; h < this.height; h++)
            {
                this.maze[h] = new int[this.width];
                for (int w = 0; w < this.width; w++)
                {
                    if (h % 2 != 0 && w % 2 != 0) this.maze[h][w] = CELL;
                    else this.maze[h][w] = WALL;
                }
            }
        }

        public String log()
        {
            string str = "";

            if (this.maze==null) return str;
            
            for (int h = 0; h < this.height; h++)
            {
                for (int w = 0; w < this.width; w++)
                {
                    str += "\t" + this.maze[h][w];
                }
                str += "\n";
            }

            return str;
        }
    }
}