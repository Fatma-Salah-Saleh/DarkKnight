using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    public struct Location
    {
        int x, y;

        public Location(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }
    }
    public static class DarkKnight
    {
        #region YOUR CODE IS HERE
        //Your Code is Here:
        //==================
        /// <summary>
        /// Given the dimention of the board and the current location of the DarkKnight, calculate the min number of moves to reach the given target or return -1 if can't be reach ed
        /// </summary>
        /// <param name="N">board dimension</param>
        /// <param name="src">current location of the DarkKnight</param>
        /// <param name="target">target location</param>
        /// <returns>min number of moves to reach the target OR -1 if can't reach the target</returns>
        public static int Play(int N, Location src, Location target)
        {
            int[,] d = new int[N + 1, N + 1];
            int[] color = new int[(N + 1) * (N + 1)];
            Queue<Location> queue = new Queue<Location>();
            for (int i = 1; i <= N; i++)
            {
                color[i] = 0;
            }
            d[src.X, src.Y] = 0;
            color[(src.X-1)+ src.Y] = 1;
            queue.Enqueue(src);
            int number_of_movement = 4;
            int[] x_axis = { 1, -1, -1, 1 };
            int[] y_axis = { 2, 2, -2, -2 };
            while (queue.Count != 0)
            {
                Location L = queue.Dequeue();
                if (L.X == target.X && L.Y == target.Y)
                {
                    return d[L.X, L.Y];
                }
                for (int i = 0; i < number_of_movement; i++)
                {
                    int x = L.X + x_axis[i];
                    int y = L.Y + y_axis[i];
                    int index = (x - 1) * N + y;
                    if (x >= 1 && x <= N && y >= 1 && y <= N && (color[index] == 0))
                    {
                        d[x, y] = d[L.X, L.Y] + 1;
                        queue.Enqueue(new Location(x, y));
                        color[index] = 2;
                    }
                }
            } 
            return -1;
        }
        #endregion
    }
}
