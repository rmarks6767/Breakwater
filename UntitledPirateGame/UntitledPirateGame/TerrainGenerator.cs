using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SharpNoise;
using SharpNoise.Builders;
using SharpNoise.Modules;

namespace UntitledPirateGame
{
    class TerrainGenerator
    {
        public TerrainGenerator()
        {
            // The noise source - a simple Perlin noise generator will do for this sample
            var noiseSource = new Perlin
            {
                Seed = new Random().Next()
            };

            // Create a new, empty, noise map and initialize a new planar noise map builder with it
            var noiseMap = new NoiseMap();
            var noiseMapBuilder = new PlaneNoiseMapBuilder
            {
                DestNoiseMap = noiseMap,
                SourceModule = noiseSource
            };

            // Set the size of the noise map
            noiseMapBuilder.SetDestSize(100, 100);

            // Set the bounds of the noise mpa builder
            // These are the coordinates in the noise source from which noise values will be sampled
            noiseMapBuilder.SetBounds(-3, 3, -2, 2);

            // Build the noise map - samples values from the noise module above,
            // using the bounds coordinates we have passed in the builder
            noiseMapBuilder.Build();


            ///*
            for (int i = 0; i <= 100; i++)
            {
                for(int a = 0; a <= 100; a++)
                {
                    Debug.Write(noiseMap[i, a]);
                    
                }

                Debug.Write("\n");
                
            }
            //*/
            Debug.Write(noiseMap.ToString());

        }
        
        
    }
}
