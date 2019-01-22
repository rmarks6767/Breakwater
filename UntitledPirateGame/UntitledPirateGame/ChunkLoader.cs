using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UntitledPirateGame
{
    class ChunkLoader
    {
        private Chunk[,] chunkMap;

        private int ChunkSide
        {
            set; get;
        }
        private Point NumberOfChunks
        {
            set; get;
        }

        public ChunkLoader(int chunkSide, int numChunkRows, int numChunkCols)
        {
            ChunkSide = chunkSide;
            NumberOfChunks = new Point(numChunkRows, numChunkCols);

            chunkMap = new Chunk[NumberOfChunks.X, NumberOfChunks.Y];

            for(int i = 0; i < chunkMap.GetLength(0); i++)
            {
                for(int j = 0; j < chunkMap.GetLength(1); j++)
                {
                    chunkMap[i, j] = new Chunk(j * ChunkSide, i * ChunkSide, ChunkSide);
                }
            }

            
        }

        private void LinkChunks()
        {
            for (int i = 0; i < chunkMap.GetLength(0); i++)
            {
                for (int j = 0; j < chunkMap.GetLength(1); j++)
                {
                    Chunk[,] adjChunks = new Chunk[3, 3];
                    if(i != 0 && j != 0)
                    {
                        adjChunks[i, j] =
                    }
                }
            }
        }
    }
}
