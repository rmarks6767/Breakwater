using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

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
        
        /// <summary>
        /// Returns the chunkmap
        /// </summary>
        public Chunk[,] ChunkMap
        {
            get { return chunkMap;}
        }

        /// <summary>
        /// Places moving entities in their proper chunck every update
        /// </summary>
        public void Update()
        {
            //Iterate through all ents in each chunk
            for (int i = 0; i < chunkMap.GetLength(0); i++)
            {
                for (int ii = 0; ii < chunkMap.GetLength(1); ii++)
                {
                    Chunk chunk = chunkMap[i, ii];

                    chunk.QuadTree = new QuadTree(chunk.members,chunk.X1,chunk.X2,chunk.Y1,chunk.Y2);
                    for(int x = 0; x < chunk.members.Count; x++)
                    {
                        Entity ent = chunk.members[x];
                        //Check if the entity is moveable
                        if (!(ent is IMovable))
                        {
                            continue;
                        }
                        else
                        {

                            //Bools of the different ent collison box corners contained in the chunk bounds.
                            bool NW = false;
                            bool NE = false;
                            bool SW = false;
                            bool SE = false;
                            
                            //Aliases for the different corners of the ent
                            Point nw = new Point(ent.vars.CollisionRectangle.X, ent.vars.CollisionRectangle.Y);
                            Point ne = new Point(ent.vars.CollisionRectangle.X + ent.vars.CollisionRectangle.Width, ent.vars.CollisionRectangle.Y);
                            Point sw = new Point(ent.vars.CollisionRectangle.X, ent.vars.CollisionRectangle.Y+ ent.vars.CollisionRectangle.Height);
                            Point se = new Point(ent.vars.CollisionRectangle.X + ent.vars.CollisionRectangle.Width, ent.vars.CollisionRectangle.Y + ent.vars.CollisionRectangle.Height);

                            //Check which corners the boundings contain
                            if (chunk.Rectangle.Contains(nw) )
                            {
                                NW = true;
                            }
                            if (chunk.Rectangle.Contains(ne))
                            {
                                NE = true;
                            }
                            if (chunk.Rectangle.Contains(sw))
                            {
                                SW = true; 
                            }
                            if (chunk.Rectangle.Contains(se))
                            {
                                SE = true;
                            }
                            /*
                             * (0,0) (0,1) (0,2)
                             * (1,0) (1,1) (1,2)
                             * (2,0) (2,1) (2,2)
                             */

                            //Now check if the ent is entirely inside of the bounds
                            if (NW && NE && SE && SW)
                            {
                                //Go to next iteration of the loop because we don't care about things entirely in our bounds
                                continue;
                            }

                            //Now check if we only have one corner contained for each possible case
                            //NW is only contained
                            else if(NW && !NE && !SW && !SE)
                            {
                                if (chunk.AdjChunks[1, 2] != null)
                                {
                                    if (!chunk.AdjChunks[1, 2].members.Contains(ent))
                                    {
                                        chunk.AdjChunks[1, 2].Add(ent);
                                    }
                                }

                                if (chunk.AdjChunks[2, 2] != null)
                                {
                                    if (!chunk.AdjChunks[2, 2].members.Contains(ent))
                                    {
                                        chunk.AdjChunks[2, 2].Add(ent);
                                    }
                                }
                                if (chunk.AdjChunks[2, 1] != null)
                                {
                                    if (!chunk.AdjChunks[2, 1].members.Contains(ent))
                                    {
                                        chunk.AdjChunks[2, 1].Add(ent);
                                    }
                                }
                                
                            }
                            //NE is only contained
                            else if (!NW && NE && !SW && !SE)
                            {
                                if (chunk.AdjChunks[1, 0]!= null)
                                {
                                    if (!chunk.AdjChunks[1, 0].members.Contains(ent))
                                    {
                                        chunk.AdjChunks[1, 0].Add(ent);
                                    }
                                }
                                if (chunk.AdjChunks[2, 0]!= null)
                                {
                                    if (!chunk.AdjChunks[2, 0].members.Contains(ent))
                                    {
                                        chunk.AdjChunks[2, 0].Add(ent);
                                    }
                                }
                                if (chunk.AdjChunks[2, 1] != null)
                                {
                                    if (!chunk.AdjChunks[2, 1].members.Contains(ent))
                                    {
                                        chunk.AdjChunks[2, 1].Add(ent);
                                    }
                                }
                                
                            }
                            //SW is only contained
                            else if (!NW && !NE && SW && !SE)
                            {
                                if (chunk.AdjChunks[0, 1] != null)
                                {
                                    if (!chunk.AdjChunks[0, 1].members.Contains(ent))
                                    {
                                        chunk.AdjChunks[0, 1].Add(ent);
                                    }
                                }

                                if (chunk.AdjChunks[0, 2] != null)
                                {
                                    if (!chunk.AdjChunks[0, 2].members.Contains(ent))
                                    {
                                        chunk.AdjChunks[0, 2].Add(ent);
                                    }
                                }

                                if (chunk.AdjChunks[1, 2] != null)
                                {
                                    if (!chunk.AdjChunks[1, 2].members.Contains(ent))
                                    {
                                        chunk.AdjChunks[1, 2].Add(ent);
                                    }
                                }
                                
                            }
                            //SE is only contained
                            else if (!NW && !NE && !SW && SE)
                            {
                                if (chunk.AdjChunks[0, 1] != null)
                                {
                                    if (!chunk.AdjChunks[0, 1].members.Contains(ent))
                                    {
                                        chunk.AdjChunks[0, 1].Add(ent);
                                    }
                                }
                                if (chunk.AdjChunks[0, 0] != null)
                                {
                                    if (!chunk.AdjChunks[0, 0].members.Contains(ent))
                                    {
                                        chunk.AdjChunks[0, 0].Add(ent);
                                    }
                                }

                                if (chunk.AdjChunks[1, 0] != null)
                                {
                                    if (!chunk.AdjChunks[1, 0].members.Contains(ent))
                                    {
                                        chunk.AdjChunks[1, 0].Add(ent);
                                    }
                                }
                                
                            }
                            //Now check if only two points are contained
                            //Top Side
                            else if (NW && NE && !SW && !SE)
                            {
                                if (chunk.AdjChunks[2, 1] != null)
                                {
                                    if (!chunk.AdjChunks[2, 1].members.Contains(ent))
                                    {
                                        chunk.AdjChunks[2, 1].Add(ent);
                                    }
                                }
                                
                            }
                            //Bottom Side
                            else if (!NW && !NE && SW && SE)
                            {
                                if (chunk.AdjChunks[0, 1] != null)
                                {
                                    if (!chunk.AdjChunks[0, 1].members.Contains(ent))
                                    {
                                        chunk.AdjChunks[0, 1].Add(ent);
                                    }
                                }
                                
                            }
                            //Left Side
                            else if (NW && !NE && SW && !SE)
                            {
                                if (chunk.AdjChunks[1, 2] != null)
                                {
                                    if (!chunk.AdjChunks[1, 2].members.Contains(ent))
                                    {
                                        chunk.AdjChunks[1, 2].Add(ent);
                                    }
                                }
                                
                            }
                            //Right Side
                            else if (!NW && NE && !SW && SE)
                            {
                                if (chunk.AdjChunks[1, 0] != null)
                                {
                                    if (!chunk.AdjChunks[1, 0].members.Contains(ent))
                                    {
                                        chunk.AdjChunks[1, 0].Add(ent);
                                    }
                                }
                                
                            }
                            //Nothing is inside
                            else
                            {
                                //Just remove it from our members list. Its not our problem anymore
                                chunk.members.Remove(ent);
                                Debug.WriteLine(ent.ToString() + " has been removed from a chunk");
                                
                            }

                        }      
                    }

                }
            }
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

            LinkChunks();
        }

        private void LinkChunks()
        {
            for (int i = 0; i < chunkMap.GetLength(0); i++)
            {
                for (int j = 0; j < chunkMap.GetLength(1); j++)
                {
                    Chunk[,] adjChunks = new Chunk[3, 3];
                    if (i != 0)
                    {
                        adjChunks[0, 1] = chunkMap[i - 1, j];
                        if (j != 0)
                        {
                            adjChunks[0, 0] = chunkMap[i - 1, j - 1];
                        }
                        if (j != chunkMap.GetLength(1) - 1)
                        {
                            adjChunks[0, 2] = chunkMap[i - 1, j + 1];
                        }
                    }
                    if (j != 0)
                    {
                        adjChunks[1, 0] = chunkMap[i, j - 1];
                        if (i != chunkMap.GetLength(0) - 1)
                        {
                            adjChunks[2, 0] = chunkMap[i + 1, j - 1];
                        }
                    }
                    if (i != chunkMap.GetLength(0) - 1)
                    {
                        adjChunks[2, 1] = chunkMap[i + 1, j];
                        if (j != 0)
                        {
                            adjChunks[2, 0] = chunkMap[i + 1, j - 1];
                        }
                        if (j != chunkMap.GetLength(1) - 1)
                        {
                            adjChunks[2, 2] = chunkMap[i + 1, j + 1];
                        }
                    }
                    if (j != chunkMap.GetLength(1) - 1)
                    {
                        adjChunks[1, 2] = chunkMap[i, j + 1];
                        if (i != 0)
                        {
                            adjChunks[0, 2] = chunkMap[i - 1, j + 1];
                        }
                    }
                    adjChunks[1, 1] = chunkMap[i, j];
                    chunkMap[i, j].StoreAdjChunks(adjChunks);
                }
            }
            
        }
    }
}
