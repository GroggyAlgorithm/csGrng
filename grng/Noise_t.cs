using System.Collections;
using System.Collections.Generic;



/// <summary>
/// Base class for noise
/// </summary>
public abstract class Noise_t : GRNG
{
    public float scale{get; set;}
    public float frequency{get; set;}
    public float amplitude{get; set;}
    public float gain{get; set;}
    public float xOffset{get;set;} 
    public float yOffset{get;set;}
    public float zOffset{get;set;}

    public Noise_t(GRNG.AlgorithmChoices algo) : base(algo)
	{
        this.scale = 1;
        this.frequency = 1;
        this.amplitude = 1.0f;
        this.gain = 0.5f;
        this.xOffset = 0;
        this.yOffset = 0;
        this.zOffset = 0;
	}

    public Noise_t(int seed, GRNG.AlgorithmChoices algo) : base(seed,algo)
	{
        this.scale = 1;
        this.frequency = 1;
        this.amplitude = 1.0f;
        this.gain = 0.5f;
        this.xOffset = 0;
        this.yOffset = 0;
        this.zOffset = 0;
	}
    public Noise_t(Noise_t noiser)
	{
        this._selected_algo = noiser._selected_algo;
        this._selectedAlgorithm = noiser._selectedAlgorithm;
        this.seed = noiser.seed;
        this.scale = noiser.scale;
        this.frequency = noiser.frequency;
        this.amplitude = noiser.amplitude;
        this.gain = noiser.gain;
        this.xOffset = noiser.xOffset;
        this.yOffset = noiser.yOffset;
        this.zOffset = noiser.zOffset;
	}

    public Noise_t(int seed) : base(seed)
    {
        this.seed = seed;
        this.scale = 1;
        this.frequency = 1;
        this.amplitude = 1.0f;
        this.gain = 0.5f;
        this.xOffset = 0;
        this.yOffset = 0;
        this.zOffset = 0;

    }

    public Noise_t() : base()
    {
        this.scale = 1;
        this.frequency = 1;
        this.amplitude = 1.0f;
        this.gain = 0.5f;
        this.xOffset = 0;
        this.yOffset = 0;
        this.zOffset = 0;
    }

    public Noise_t(GRNG rand) : base(rand)
    {
        this.scale = 1;
        this.frequency = 1;
        this.amplitude = 1.0f;
        this.gain = 0.5f;
        this.xOffset = 0;
        this.yOffset = 0;
        this.zOffset = 0;
    }

    public abstract float Sample1D(float xPosition, bool randomPermTable = false);
    public abstract float Sample2D(float xPosition, float yPosition, bool randomPermTable = false);
    public abstract float Sample3D(float xPosition, float yPosition, float zPosition, bool randomPermTable = false);

    public virtual float Octave1D(float x)
    {
        if(gain == 0) gain = 1;
        
        x = x * scale + xOffset;
        

        return Sample1D(x * frequency) * gain;
    }

    public virtual float Octave2D(float x, float y)
    {
        if (gain == 0) gain = 1;
        
        x = x * scale + xOffset;
        y = y * scale + yOffset;
        
        return Sample2D(x * frequency, y * frequency) * gain;
    }

    public virtual float Octave3D(float x, float y, float z)
    {
        if (gain == 0) gain = 1;
        
        x = x * scale + xOffset;
        y = y * scale + yOffset;
        z = z * scale + zOffset;
        
        return Sample3D(x * frequency, y * frequency, z * frequency) * gain;
    }


    public virtual float[] SampleNoiseMap(int size, int octaveCount, float roughness = 10000)
    {
        float[] noiseMap = new float[size];
        float[] octaves = new float[octaveCount];

        

        for(var x = 0; x < size; x++)
        {
            float normalization = 0.0f;
            float noiseVal = 0;
            for(var i = 0; i < octaveCount; i++)
            {
                noiseVal += (Octave1D(x)+Range(-roughness,roughness));
                normalization += amplitude;
            }

            noiseVal /= normalization;

            noiseMap[x] = noiseVal;
            
        }


        return noiseMap;
    }

    public virtual float[,] SampleNoiseMap(int width, int height, int octaveCount, float roughness = 10000)
    {
        float[,] noiseMap = new float[width,height];
        float[] octaves = new float[octaveCount];

        

        for(var x = 0; x < width; x++)
        {
            for(var y = 0; y < height; y++)
            {
                float normalization = 0.0f;
                float noiseVal = 0;
                for(var i = 0; i < octaveCount; i++)
                {
                    noiseVal += (Octave2D(x,y)+Range(-roughness,roughness));
                    normalization += amplitude;
                }

                noiseVal /= normalization;

                noiseMap[x,y] = noiseVal;
            }
        }


        return noiseMap;
    }

    public virtual float[,,] SampleNoiseMap(int width, int height, int depth, int octaveCount, float roughness = 10000)
    {
        float[,,] noiseMap = new float[width,height,depth];
        float[] octaves = new float[octaveCount];

        

        for(var x = 0; x < width; x++)
        {
            for(var y = 0; y < height; y++)
            {
                for(var z = 0; z < depth; z++)
                {

                
                    float normalization = 0.0f;
                    float noiseVal = 0;

                    for(var i = 0; i < octaveCount; i++)
                    {
                        noiseVal += (Octave3D(x,y,z)+Range(-roughness,roughness));
                        normalization += amplitude;
                    }

                    noiseVal /= normalization;

                    noiseMap[x,y,z] = noiseVal;
                }
            }
        }


        return noiseMap;
    }
    

}




