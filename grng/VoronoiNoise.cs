// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class VoronoiNoise : INoise
// {
//     public float displacement = 0f;

// 	public VoronoiNoise() : base()
// 	{
// 	}

// 	public VoronoiNoise(int seed, float displacement = 1.0f) : base(seed)
//     {
//         this.seed = seed;
//         this.displacement = displacement;
//     }

//     public VoronoiNoise(GRNG grng, float displacement = 1.0f) : base(grng)
//     {
//         this.displacement = displacement;
//     }
    
//     public VoronoiNoise(INoise noiser, float displacement = 1.0f) : base(noiser)
//     {
//         this.displacement = displacement;
//     }

//     public override float Sample1D(float xPosition, bool useDistance = false)
//     {
//         if (amplitude == 0) amplitude = 1;
//         return gRand.Voronoi(xPosition, frequency, useDistance, displacement) * amplitude;
//     }

//     public override float Sample2D(float xPosition, float yPosition, bool useDistance = false)
//     {
//         if (amplitude == 0) amplitude = 1;
//         return gRand.Voronoi(xPosition, yPosition, frequency, useDistance, displacement) * amplitude;
//     }

//     public override float Sample3D(float xPosition, float yPosition, float zPosition, bool useDistance = false)
//     {
//         if (amplitude == 0) amplitude = 1;
//         return gRand.Voronoi(xPosition, yPosition, zPosition, frequency, useDistance, displacement) * amplitude;
//     }

    
// }



using System.Collections;
using System.Collections.Generic;

public class VoronoiNoise : Noise_t
{
    public float displacement = 0f;

	public VoronoiNoise() : base()
	{
        this.displacement = 1.0f;
	}

    public VoronoiNoise(int seed, GRNG.AlgorithmChoices algo) : base(seed,algo)
	{
        this.displacement = 1.0f;
	}

    public VoronoiNoise(GRNG.AlgorithmChoices algo) : base(algo)
	{
        this.displacement = 1.0f;
	}

	public VoronoiNoise(int seed, float displacement = 1.0f) : base(seed)
    {
        this.seed = seed;
        this.displacement = displacement;
    }

    public VoronoiNoise(GRNG grng, float displacement = 1.0f) : base(grng)
    {
        // base(grng);
        this.displacement = displacement;
    }
    
    public VoronoiNoise(Noise_t noiser, float displacement = 1.0f) : base(noiser)
    {
        // base(noiser);
        this.displacement = displacement;
    }

    public override float Sample1D(float xPosition, bool useDistance = false)
    {
        if (amplitude == 0) amplitude = 1;
        return Voronoi(xPosition, frequency, useDistance, displacement) * amplitude;
    }

    public override float Sample2D(float xPosition, float yPosition, bool useDistance = false)
    {
        if (amplitude == 0) amplitude = 1;
        return Voronoi(xPosition, yPosition, frequency, useDistance, displacement) * amplitude;
    }

    public override float Sample3D(float xPosition, float yPosition, float zPosition, bool useDistance = false)
    {
        if (amplitude == 0) amplitude = 1;
        return Voronoi(xPosition, yPosition, zPosition, frequency, useDistance, displacement) * amplitude;
    }

    
}
