using System.Collections;
using System.Collections.Generic;



/// <summary>
/// Base class for noise
/// </summary>
public abstract class Noise_t : GRNG
{

    // public GRNG gRand{get; set;}
    public int seed{get;set;}
    public float scale{get; set;}
    public float frequency{get; set;}
    public float amplitude{get; set;}
    public float gain{get; set;}
    public float xOffset{get;set;} 
    public float yOffset{get;set;}
    public float zOffset{get;set;}

    public Noise_t(GRNG.AlgorithmChoices algo) : base(algo)
	{
        // base();
	}

    public Noise_t(int seed, GRNG.AlgorithmChoices algo) : base(seed,algo)
	{
        // base();
	}
    public Noise_t(Noise_t noiser)
	{
        this._selected_algo = noiser._selected_algo;
        this._selectedAlgorithm = noiser._selectedAlgorithm;
        // this.gRand = noiser.gRand;
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
        // base(seed);
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
        // base();

        // this.gRand = new GRNG();
        // this.seed = this.gRand.seed;
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
        // this.gRand = rand;
        // this.seed = this.gRand.seed;
        this.scale = 1;
        this.frequency = 1;
        this.amplitude = 1.0f;
        this.gain = 0.5f;
    }

    public abstract float Sample1D(float xPosition, bool randomPermTable = false);
    public abstract float Sample2D(float xPosition, float yPosition, bool randomPermTable = false);
    public abstract float Sample3D(float xPosition, float yPosition, float zPosition, bool randomPermTable = false);

    public virtual float Octave1D(float x)
    {
        if(gain == 0) gain = 1;
        x = x + xOffset;

        return Sample1D(x * frequency) * gain;
    }

    public virtual float Octave2D(float x, float y)
    {
        if (gain == 0) gain = 1;
        x = x + xOffset;
        y = y + yOffset;

        return Sample2D(x * frequency, y * frequency) * gain;
    }

    public virtual float Octave3D(float x, float y, float z)
    {
        if (gain == 0) gain = 1;
        x = x + xOffset;
        y = y + yOffset;
        z = z + zOffset;
        return Sample3D(x * frequency, y * frequency, z * frequency) * gain;
    }

    

}




