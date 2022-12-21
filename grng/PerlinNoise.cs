using System.Collections;
using System.Collections.Generic;

public partial class PerlinNoise: Noise_t
{

    public PerlinNoise(int seed) : base(seed)
	{
        // this.seed = seed;
		// base(seed);
	}

    public PerlinNoise(GRNG grng) : base(grng)
    {
		// base(grng);
    }

    public PerlinNoise(Noise_t noiser) : base(noiser)
    {
		// base(noiser);
    }

	public PerlinNoise() :base()
	{
		// base();
	}

	public override float Sample1D(float xPosition, bool randomPermTable = false) {
        if(amplitude == 0) amplitude = 1;
        return Perlin1D(xPosition,randomPermTable)*amplitude;
    }

    public override float Sample2D(float xPosition, float yPosition, bool randomPermTable = false) {
        if(amplitude == 0) amplitude = 1;
        return Perlin2D(xPosition,yPosition,randomPermTable)*amplitude;
    }

    public override float Sample3D(float xPosition, float yPosition, float zPosition, bool randomPermTable = false) {
        if(amplitude == 0) amplitude = 1;
        return Perlin3D(xPosition,yPosition,zPosition,randomPermTable)*amplitude;
    }

	public override float Octave1D(float x)
	{
		x = x * scale + xOffset;

		return Sample1D(x * frequency) * amplitude;
	}

	public override float Octave2D(float x, float y)
	{
		x = x + xOffset;
		y = y + yOffset;

		return (Sample2D(x * frequency, y * frequency) * amplitude)*scale;
	}

	public override float Octave3D(float x, float y, float z)
	{
		x = x + xOffset;
		y = y + yOffset;
		z = z + zOffset;
		return Sample3D(x * frequency, y * frequency, z * frequency) * amplitude;
	}





} //end classs
