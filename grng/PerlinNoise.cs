using System.Collections;
using System.Collections.Generic;

public partial class PerlinNoise : Noise_t
{

	public PerlinNoise(int seed) : base(seed)
	{

	}

	public PerlinNoise(GRNG grng) : base(grng)
	{

	}

	public PerlinNoise(Noise_t noiser) : base(noiser)
	{

	}

	public PerlinNoise() : base()
	{

	}

	public override float Sample1D(float xPosition, bool randomPermTable = false)
	{
		if (amplitude == 0) amplitude = 1;
		return Perlin1D(xPosition, randomPermTable) * amplitude;
	}

	public override float Sample2D(float xPosition, float yPosition, bool randomPermTable = false)
	{
		if (amplitude == 0) amplitude = 1;
		return Perlin2D(xPosition, yPosition, randomPermTable) * amplitude;
	}

	public override float Sample3D(float xPosition, float yPosition, float zPosition, bool randomPermTable = false)
	{
		if (amplitude == 0) amplitude = 1;
		return Perlin3D(xPosition, yPosition, zPosition, randomPermTable) * amplitude;
	}




} //end classs
