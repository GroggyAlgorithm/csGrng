using System.Collections.Generic;



/// <summary>
/// The Groggy Random Number Generator
/// </summary>
public class GRNG {

    /// <summary>
    /// Weight for the numbers to lean
    /// </summary>
    public enum Weight { None, Lower, Upper, Centre, Ends }
    
    /// <summary>
    /// Available algorithms to create the psuedo random values
    /// </summary>
    public enum AlgorithmChoices {
        AdaptedLehmer32,
        Lehmer64,
        Xorshift32,
        Xorshift64,
        Xorshift128,
        Wyhash,
        Reverse17,
        Reverse23,
    }

    public AlgorithmChoices _selected_algo{get; protected set;}
    
    ///The random seed
    public int seed {get; protected set;} 
    
    ///The random algorithm to use
    protected delegate int _randomAlgo(int value);
    protected _randomAlgo _selectedAlgorithm;
    

#region INIT

    public void SetSeed(int newSeed)
	{
        seed = newSeed;
	}

    public void SetAlgorithm(AlgorithmChoices newAlgorithm)
	{
        _selected_algo = newAlgorithm;
        _check_algo(newAlgorithm);
    }

    public GRNG(GRNG grng) 
    {
        this.seed = grng.seed;
        this._selected_algo = grng._selected_algo;
        _check_algo(this._selected_algo);
    }

    public GRNG(int seed, AlgorithmChoices algo = AlgorithmChoices.AdaptedLehmer32) {
        this.seed = seed;
        _check_algo(algo);
    }

    public GRNG(float seed, AlgorithmChoices algo = AlgorithmChoices.AdaptedLehmer32) {
        this.seed = seed.ToInt();
        _check_algo(algo);
    }

    public GRNG(long seed, AlgorithmChoices algo = AlgorithmChoices.AdaptedLehmer32) {
        this.seed = (int)(seed);
        _check_algo(algo);
    }

    public GRNG (string seed, AlgorithmChoices algo = AlgorithmChoices.AdaptedLehmer32) {
		this.seed = seed.GetHashCode();
        _check_algo(algo);
	}

	public GRNG(AlgorithmChoices algo = AlgorithmChoices.AdaptedLehmer32) {
        seed = System.Environment.TickCount;
        _check_algo(algo);
	}

    protected void _check_algo(AlgorithmChoices algo) {
        switch(algo) {
            
            case AlgorithmChoices.AdaptedLehmer32:
                _selectedAlgorithm = new _randomAlgo(GRandomAlgorithms.AdaptedLehmer32);
                break;

            case AlgorithmChoices.Lehmer64:
                _selectedAlgorithm = new _randomAlgo(GRandomAlgorithms.Lehmer64);
                break;
            

            case AlgorithmChoices.Xorshift32:
                _selectedAlgorithm = new _randomAlgo(GRandomAlgorithms.xorshift32);
                break;
            

            case AlgorithmChoices.Xorshift64:
                _selectedAlgorithm = new _randomAlgo(GRandomAlgorithms.xorshift64);
                break;
            

            case AlgorithmChoices.Xorshift128:
                _selectedAlgorithm = new _randomAlgo(GRandomAlgorithms.xorshift128);
                break;
            

            case AlgorithmChoices.Wyhash:
                _selectedAlgorithm = new _randomAlgo(GRandomAlgorithms.wyhash);
                break;

            case AlgorithmChoices.Reverse17:
                _selectedAlgorithm = new _randomAlgo(GRandomAlgorithms.reverse17);
            break;

            case AlgorithmChoices.Reverse23:
                _selectedAlgorithm = new _randomAlgo(GRandomAlgorithms.reverse23);
            break;
            
            default:
                _selectedAlgorithm = new _randomAlgo(GRandomAlgorithms.AdaptedLehmer32);
                break;
        }
    }


#endregion

 

    /// <summary>
    /// Returns a double between 0 and 1
    /// </summary>
    /// <returns></returns>
    public double NextDouble() {
        int randVal = _selectedAlgorithm(seed);
        seed = _selectedAlgorithm(randVal);
        return (MathG.NormalizeInRange((double)randVal,(double)int.MinValue,(double)int.MaxValue));
    }


    /// <summary>
    /// Returns a double
    /// </summary>
    /// <returns></returns>
    public double NextDouble(double max) {
        int randVal = _selectedAlgorithm(seed);
        seed = _selectedAlgorithm(randVal);
        return (MathG.NormalizeInRange((double)randVal,(double)int.MinValue,max));
    }


    /// <summary>
    /// Returns a random boolean
    /// </summary>
    /// <returns></returns>
    public bool NextBool() => (NextDouble() > 0.5 ? true : false); 


    /// <summary>
    /// Returns a float between 0 and 1
    /// </summary>
    /// <returns></returns>
    public float NextFloat() {
        int randVal = _selectedAlgorithm(seed);
        seed = _selectedAlgorithm(randVal);
        return (MathG.NormalizeInRange(randVal,int.MinValue,int.MaxValue));
    }


    /// <summary>
    /// Returns a float between 0 and 100
    /// </summary>
    /// <returns></returns>
    public float NextPercentage() {
        int randVal = _selectedAlgorithm(seed);
        seed = _selectedAlgorithm(randVal);
        return Range(0f,100f);
    }

    /// <summary>
    /// Returns a float
    /// </summary>
    /// <returns></returns>
    public float NextFloat(float max) {
        int randVal = _selectedAlgorithm(seed);
        seed = _selectedAlgorithm(randVal);
        return (MathG.NormalizeInRange((float)randVal,(float)int.MinValue,max));
    }

    /// <summary>
    /// Returns a random int
    /// </summary>
    /// <returns></returns>
    public int NextInt() {
        int randVal = _selectedAlgorithm(seed);
        seed = _selectedAlgorithm(randVal);
        return randVal;
    }


    /// <summary>
    /// Returns a value between the min and max values
    /// </summary>
    /// <param name="min">min value</param>
    /// <param name="max">max value</param>
    /// <returns></returns>
    public double Range(double min, double max) {
        return MathG.LerpClamped(min,max,NextDouble());
    }

    /// <summary>
    /// Returns a value between the min and max values
    /// </summary>
    /// <param name="min">min value</param>
    /// <param name="max">max value</param>
    /// <returns></returns>
    public float Range(float min, float max) {
        return MathG.LerpClamped(min,max,NextFloat());
    }


    /// <summary>
    /// Returns a value between the x and y values
    /// </summary>
    /// <param name="min">min value</param>
    /// <param name="max">max value</param>
    /// <returns></returns>
    public int Range(int min, int max) {
        return MathG.RoundToInt(Range((float)min, (float)max));
    }

    
    /// <summary>
    /// Returns a random int
    /// </summary>
    /// <returns></returns>
    public int NextInt(int max) {
        return Range(int.MinValue,max);
    }

    /// <summary>
    /// Returns the next char value
    /// </summary>
    /// <returns></returns>
    public char NextChar()
	{
        return(char)Range(0, 0xFF);
	}


    /// <summary>
    /// Returns the next printable ascii value
    /// </summary>
    /// <returns></returns>
    public char NextAscii()
	{
        return (char)Range(0x20, 0xFF);
    }


	/// <summary>
	/// Returns a value between the x and y values
	/// </summary>
	/// <param name="min">min value</param>
	/// <param name="max">max value</param>
	/// <returns></returns>
	public char CharRange(int min, int max)
	{
		return (char)Range(min&0xFF,max&0xFF);
	}




	/// <summary>
	/// Returns a random value between 0 and 1
	/// </summary>
	/// <returns></returns>
	public float Value() => (float)Range(0f,1f);

    /// <summary>
    /// Returns a Random element from an array
    /// </summary>
    /// <param name="a"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T Element<T>(IList<T> a) => a[Range(0, a.Count-1)];



    /// <summary>
    /// Shuffles the collections values
    /// </summary>
    /// <param name="l"></param>
    /// <typeparam name="T"></typeparam>
    public void Shuffle<T>(IList<T> l) {
        int lCount = l.Count;
        for(int i = 0; i < lCount; i++) {
            int j = Range(i,lCount-1);
            T temp = l[j];
            l[j] = l[i];
            l[i] = temp;
        }
    }


    /// <summary>
    /// Returns a random boolean value
    /// </summary>
    /// <returns></returns>
    public bool BoolValue() => (Value() > 0.5f);

    /// <summary>
    /// Returns the value with a random sign
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public float Sign(float v) => ((BoolValue()) ? -v : v);


    /// <summary>
    /// Returns a random sign
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public float Sign() => ((BoolValue()) ? -1 : 1);


    /// <summary>
    /// Random value -1 to 1
    /// </summary>
    /// <returns></returns>
    public float SignedValue() => (Value() * 2 - 1);


    /// <summary>
    /// Creates a random value based on averaging around a point instead of an even distibution
    /// </summary>
    /// <returns>A random float value between 0 and 1</returns>
    public float Gaussian() {
        float value1 = 0;
        float value2 = 0;
        float s = 0; //Idk what this one is supposed to be named


        do
        {

            value1 = 2.0f * Range(0f, 1f) - 1.0f;
            value2 = 2.0f * Range(0f, 1f) - 1.0f;
            s = (value1 * value1) + (value2 * value2);

        } while (s >= 1.0f || s == 0f);

        s = MathG.sqrt((-2f * MathG.Log(s)) / s);

        return value1 * s;
    }


    /// <summary>
    /// Creates a random value based on averaging around a point instead of an even distibution
    /// </summary>
    /// <param name="center">The center point for the values to be centered around</param>
    /// <param name="deviation">The deviation the points can deviate by</param>
    /// <returns>A random gaussian value</returns>
    public float Gaussian(float center, float deviation)
    {
        return (center + Gaussian() * deviation);
    }

    /// <summary>
    /// Creates a random value from a range based on on averaging around a point instead of an even distibution
    /// </summary>
    /// <param name="deviation">The deviation the points can deviate by</param>
    /// <param name="min">The minimum value allowed</param>
    /// <param name="max">The maximum value allowed</param>
    /// <returns>A radom value within the range</returns>
    public float GaussianRange(float deviation, float min, float max)
    {

        float newRand = 0;
        float a = min;
        float b = max;

        if(min > max)
        {
            a = max;
            b = min;
        }

        do
        {
            newRand = Gaussian(((a+b)/2), deviation);

            if (a == b) break;

        } while (newRand < a || newRand > b);

        return newRand;

    }


    /// <summary>
    /// Creates a value biased towards 0 based on the strength
    /// </summary>
    /// <param name="strength"></param>
    /// <returns></returns>
    public float LowerBiasValue(float strength) {
        float t = Value ();

		// Avoid possible division by zero
		if (strength == 1) {
			return 0;
		}

		// Remap strength for nicer input -> output relationship
		float k = MathG.Clamp01 (1 - strength);
		k = k * k * k - 1;

		return MathG.Clamp01 ((t + t * k) / (t * k + 1));
    }


    /// <summary>
    /// Creates a value biased towards 1 based on the strength
    /// </summary>
    /// <param name="strength"></param>
    /// <returns></returns>
    public float UpperBiasValue(float strength) => (1 - LowerBiasValue(strength));


    /// <summary>
    /// Returns a value biased towards the extremes
    /// </summary>
    /// <param name="strength"></param>
    /// <returns></returns>
    public float ExtremesBiasValue(float strength) {
        float t = LowerBiasValue(strength);
        return(BoolValue() ? 1-t : t);
    }

    /// <summary>
    /// Returns a random value biased towards the center
    /// </summary>
    /// <param name="strength"></param>
    /// <returns></returns>
    public float CenterBiasValue(float strength) {
        float t = LowerBiasValue(strength);
        return (0.5f + t * 0.5f * Sign());
    }



    /// <summary>
    /// Creates a value weighted towards the weight passed
    /// </summary>
    /// <param name="weight"></param>
    /// <param name="strength"></param>
    /// <returns></returns>
    public float WeightedValue(Weight weight, int strength) {

        float randVal = 0;

        if(weight == Weight.None) {
            randVal = Value();
        }
        else {

        
            float smallestValue = Value();
            for(int i = 0; i < strength; i++) {
                smallestValue = MathG.Min(smallestValue,Value());
            }

            switch(weight) {
                case Weight.Lower:
                    randVal = smallestValue;
                    break;
                case Weight.Upper:
                    randVal = 1 - smallestValue;
                    break;
                case Weight.Centre:
                    randVal = (0.5f + smallestValue * 0.5f * Sign());
                    break;
                case Weight.Ends:
                    randVal = (BoolValue() ? 1 - smallestValue : smallestValue);
                    break;
                
                default:
                    break;
            }

        }

        return randVal;
    }



    /// <summary>
    /// Returns the smallest value in x iterations
    /// </summary>
    /// <param name="iterations"></param>
    /// <returns></returns>
    public float SmallestRandom(int iterations) {
        float smallestValue = 1;
        for(int i = 0; i < iterations; i++) {
            smallestValue = MathG.Min(smallestValue,Value());
        }

        return smallestValue;
    }

    
    /// <summary>
    /// Returns the largest value in x iterations
    /// </summary>
    /// <param name="iterations"></param>
    /// <returns></returns>
    public float LargestRandom(int iterations) {
        float largestValue = 0;
        for(int i = 0; i < iterations; i++) {
            largestValue = MathG.Max(largestValue,Value());
        }

        return largestValue;
    }



    /// <summary>
    /// Returns the most centered of values in a range up to x iterations
    /// </summary>
    /// <param name="iterations"></param>
    /// <returns></returns>
    public float CenteredRandom(int iterations) {
        float centeredValue = 0;

        for(int i = 0; i < iterations; i++) {
            float rVal = Value();
            if(MathG.Abs(rVal - 0.5f) < (centeredValue - 0.5f)) centeredValue = rVal;
        }

        return centeredValue;
    }



    /// <summary>
    /// Checks if probability chance roll was successful
    /// </summary>
    /// <param name="chancePercentage">The percentage chance to roll for</param>
    /// <returns>True if the value from Range is <= the chance</returns>
    public bool ChanceRoll(float chancePercentage)
    {
        bool blnChanceIsYes = false;
        if(chancePercentage.IsWithin(0,1)) {
            chancePercentage*= 100;
        }

        if (chancePercentage >= 100)
        {
            blnChanceIsYes = true;
        }
        else if (chancePercentage > 0)
        {

            if (chancePercentage >= Range(0f, 100f))
            {
                blnChanceIsYes = true;
            }
        }

        return blnChanceIsYes;


    }


    
    /// <summary>
    /// Creates a permutation table with defaults of length 512 with values from 0 - 255 inclusive
    /// </summary>
    /// <param name="tableSize"></param>
    /// <param name="maxSize"></param>
    /// <returns>A new permutation table</returns>
    public int[] CreatePermutationTable(int tableSize = 512, int maxSize = 255) {
        int[] newPermutation = new int[tableSize];
        
        for(int i = 0, j = 0; i < tableSize; i++) {
            if(i > maxSize) {
                newPermutation[i] = newPermutation[j];
                j++;
            }
            else {
                newPermutation[i] = i;
            }
        }
        
        Shuffle(newPermutation);
        return newPermutation;
    }


#region PERLIN


    /// <summary>
    /// The permutation table from ken perlins perlin noise source code
    /// </summary>
    /// <value></value>
    protected int[] PermutationTable = {
        151,160,137,91,90,15,
        131,13,201,95,96,53,194,233,7,225,140,36,103,30,69,142,8,99,37,240,21,10,23,
        190, 6,148,247,120,234,75,0,26,197,62,94,252,219,203,117,35,11,32,57,177,33,
        88,237,149,56,87,174,20,125,136,171,168, 68,175,74,165,71,134,139,48,27,166,
        77,146,158,231,83,111,229,122,60,211,133,230,220,105,92,41,55,46,245,40,244,
        102,143,54, 65,25,63,161, 1,216,80,73,209,76,132,187,208, 89,18,169,200,196,
        135,130,116,188,159,86,164,100,109,198,173,186, 3,64,52,217,226,250,124,123,
        5,202,38,147,118,126,255,82,85,212,207,206,59,227,47,16,58,17,182,189,28,42,
        223,183,170,213,119,248,152, 2,44,154,163, 70,221,153,101,155,167, 43,172,9,
        129,22,39,253, 19,98,108,110,79,113,224,232,178,185, 112,104,218,246,97,228,
        251,34,242,193,238,210,144,12,191,179,162,241, 81,51,145,235,249,14,239,107,
        49,192,214, 31,181,199,106,157,184, 84,204,176,115,121,50,45,127, 4,150,254,
        138,236,205,93,222,114,67,29,24,72,243,141,128,195,78,66,215,61,156,180,
        151
    };


    
    /// <summary>
    /// Returns gradient value
    /// </summary>
    /// <param name="hash"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    /// <returns></returns>
    public double Gradient(int hash, double x, double y, double z) {
      int h = hash & 15;                      
      double u = h<8 ? x : y,                 
             v = h<4 ? y : h==12||h==14 ? x : z;
      return ((h&1) == 0 ? u : -u) + ((h&2) == 0 ? v : -v);
   }


    /// <summary>
    /// Returns gradient value
    /// </summary>
    /// <param name="hash"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public float Gradient(int hash, float x) {
      return ((hash&1) == 0 ? x : -x);
   }

    /// <summary>
    /// Returns gradient value
    /// </summary>
    /// <param name="hash"></param>
    /// <param name="x"></param>
    /// <returns></returns>
    public float Gradient(int hash, float x, float y) {
      return ((hash & 1) == 0 ? x : -x) + ((hash & 2) == 0 ? y : -y);
   }

    /// <summary>
    /// Returns gradient value
    /// </summary>
    /// <param name="hash"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    /// <returns></returns>
    public float Gradient(int hash, float x, float y, float z) {
      int h = hash & 15;                      
      float u = h<8 ? x : y,                 
             v = h<4 ? y : h==12||h==14 ? x : z;
      return ((h&1) == 0 ? u : -u) + ((h&2) == 0 ? v : -v);
   }

    
    /// <summary>
    /// 1D Perlin Noise
    /// </summary>
    /// <param name="x"></param>
    /// <param name="randomPermTable"></param>
    /// <returns></returns>
   public float Perlin1D(float x, bool randomPermTable = false) {
       int newX = MathG.FloorToInt(x) & 0xff;
       x -= MathG.FloorToInt(x);
       float fadedX = MathG.Fade(x);
       var perm = (randomPermTable == false) ? PermutationTable : CreatePermutationTable();
       return MathG.CbLerp(fadedX, Gradient(perm[newX],x),Gradient(perm[newX+1],x-1))*2;
   }


    /// <summary>
    /// 2D Perlin Noise
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="randomPermTable"></param>
    /// <returns></returns>
    public float Perlin2D(float x, float y, bool randomPermTable = false) 
    {
        int newX = MathG.FloorToInt(x) & 0xff;
        int newY = MathG.FloorToInt(y) & 0xff;
        x -=MathG.FloorToInt(x);
        y -= MathG.FloorToInt(y);
        float fadedX = MathG.Fade(x);
        float fadedY = MathG.Fade(y);
        var perm = (randomPermTable == false) ? PermutationTable : CreatePermutationTable();
        var A = (perm[newX] + newY) & 0xff;
        var B = (perm[newX + 1] + newY) & 0xff;

        var l1 = MathG.CbLerp(fadedY, MathG.CbLerp(fadedX, Gradient(perm[A],x,y),Gradient(perm[B], x-1,y)),
            MathG.CbLerp(fadedX, Gradient(perm[A+1],x,y-1), Gradient(perm[B+1], x-1, y-1)));

        return l1;
    }


    /// <summary>
    /// 3D Perlin Noise
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    /// <param name="randomPermTable"></param>
    /// <returns></returns>
   public float Perlin3D(float x, float y, float z, bool randomPermTable = false) {

        var perm = (randomPermTable == false) ? PermutationTable : CreatePermutationTable();

        int newX = MathG.FloorToInt(x) & 0xff;
        int newY = MathG.FloorToInt(y) & 0xff;
        int newZ = MathG.FloorToInt(z) & 0xff;
        x -= MathG.FloorToInt(x);
        y -= MathG.FloorToInt(y);
        z -= MathG.FloorToInt(y);
        float fadedX = MathG.Fade(x);
        float fadedY = MathG.Fade(y);
        float fadedZ = MathG.Fade(z);
       
        var A = (perm[newX] + newY) & 0xff;
        var B = (perm[newX + 1] + newY) & 0xff;
        var AA = (perm[A] + newZ) & 0xff;
        var BA = (perm[B] + newZ) & 0xff;
        var AB = (perm[A+1] + newZ) & 0xff;
        var BB = (perm[B+1] + newZ) & 0xff;


        var l1 = MathG.CbLerp(fadedZ, 
            MathG.CbLerp(fadedY, 
                MathG.CbLerp(fadedX, Gradient(perm[AA], x, y, z), Gradient(perm[BA], x-1, y, z)),
                    MathG.CbLerp(fadedX, Gradient(perm[AB], x, y-1, z), Gradient(perm[BB], x-1, y-1, z))),
                       MathG.CbLerp(fadedY, MathG.CbLerp(fadedX, Gradient(perm[AA+1], x, y  , z-1), Gradient(perm[BA+1], x-1, y  , z-1)),
                            MathG.CbLerp(fadedX, Gradient(perm[AB+1], x, y-1, z-1), Gradient(perm[BB+1], x-1, y-1, z-1))));

       return l1;
   }


    

    
    

    /// <summary>
    /// Ken perlins improved noise
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    /// <returns></returns>
    public float ImprovedNoise(float x, float y, float z = 0.01f) {
        return (float)ImprovedNoise((double)x, (double)y, (double)z);
    }
    

    /// <summary>
    /// Ken perlins improved noise
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    /// <returns></returns>
    public double ImprovedNoise(double x, double y, double z = 0) {

        var p = PermutationTable;
		//var p = CreatePermutationTable();

		x +=NextDouble();
        y +=NextDouble();
        z +=NextDouble();

        // FIND UNIT CUBE THAT CONTAINS POINT.
        int X = (int)MathG.Floor(x) & 255;
        int Y = (int)MathG.Floor(y) & 255;
        int Z = (int)MathG.Floor(z) & 255;
        x -= MathG.Floor(x);                                // FIND RELATIVE X,Y,Z
        y -= MathG.Floor(y);                                // OF POINT IN CUBE.
        z -= MathG.Floor(z);
        double u = MathG.Fade(x);                                // COMPUTE FADE CURVES
        double v = MathG.Fade(y);                                // FOR EACH OF X,Y,Z.
        double w = MathG.Fade(z);

        
        
        // HASH COORDINATES OF THE 8 CUBE CORNERS,
        int A =  (p[X] + Y) & 255;
        int AA = (p[A] + Z) & 255;
        int AB = (p[A+1]+Z) & 255;
        int B =  (p[X + 1] + Y) & 255;
        int BA = (p[B] + Z) & 255; 
        int BB = (p[B+1]+Z) & 255;

        // AND ADD BLENDED RESULTS FROM  8 CORNERS OF CUBE
        return MathG.CbLerp(w, MathG.CbLerp(v, MathG.CbLerp(u, Gradient(p[AA], x  , y  , z   ),
            Gradient(p[BA], x-1, y  , z   )), 
            MathG.CbLerp(u, Gradient(p[AB], x  , y-1, z   ),  
            Gradient(p[BB], x-1, y-1, z   ))),
            MathG.CbLerp(v, MathG.CbLerp(u, Gradient(p[AA+1], x  , y  , z-1 ),
            Gradient(p[BA+1], x-1, y  , z-1 )), 
            MathG.CbLerp(u, Gradient(p[AB+1], x  , y-1, z-1 ),
            Gradient(p[BB+1], x-1, y-1, z-1 ))));
    }



    /// <summary>
    /// Creates offset perlin noise
    /// </summary>
    public float OffsetPerlinNoise(int xIteration, int yIteration, float noiseScale, float xOffset, float yOffset,
    float centerX, float centerY, float frequency)
    {
        float perlinValue = 0f;
        var devisor = (noiseScale != 0 && frequency != 0) ? noiseScale * frequency : 1;
        float x = (xIteration - centerX + xOffset) / devisor;
        float y = (yIteration - centerY - yOffset) / devisor;
        perlinValue = Perlin2D(x, y) * 2 - 1;
        return perlinValue;

    }

    /// <summary>
    /// Creates offset perlin noise
    /// </summary>
    public float OffsetPerlinNoise(int xIteration, float noiseScale, float xOffset, 
    float centerX, float frequency)
    {
        float perlinValue = 0f;
        var devisor = (noiseScale != 0 && frequency != 0) ? noiseScale * frequency : 1;
        float x = (xIteration - centerX + xOffset) / devisor;
        perlinValue = Perlin1D(x)*2-1;
        return perlinValue;

    }



    /// <summary>
    /// Creates offset perlin noise
    /// </summary>
    public float OffsetPerlinNoise(int xIteration, int yIteration, int zIteration, float noiseScale, float xOffset, float yOffset, float zOffset, 
        float centerX, float centerY, float centerZ, float frequency)
    {
        float perlinValue = 0f;
        var devisor = (noiseScale != 0 && frequency != 0) ? noiseScale * frequency : 1;
        float x = (xIteration - centerX + xOffset) / devisor;
        float y = (yIteration - centerY - yOffset) / devisor;
        float z = (zIteration - centerZ + zOffset) / devisor;

        perlinValue = Perlin3D(x, y, z) * 2 - 1;

        return perlinValue;

    }





    /// <summary>
    /// Creates offset perlin noise
    /// </summary>
    public float OffsetPerlinNoise(float xPosition, float noiseScale, float xOffset, float frequency)
    {
        float perlinValue = 0f;
        var devisor = (noiseScale != 0 && frequency != 0) ? noiseScale * frequency : 1;
        float x = (xPosition + xOffset) / devisor;
        perlinValue = Perlin1D(x) * 2 - 1;
        return perlinValue;

    }



    /// <summary>
    /// Creates offset perlin noise
    /// </summary>
    public float OffsetPerlinNoise(float xPosition, float yPosition, float noiseScale, float xOffset, float yOffset, float frequency)
    {
        float perlinValue = 0f;
        var devisor = (noiseScale != 0 && frequency != 0) ? noiseScale * frequency : 1;
        float x = (xPosition + xOffset) / devisor;
        float y = (yPosition - yOffset) / devisor;
        perlinValue = Perlin2D(x, y) * 2 - 1;
        return perlinValue;

    }
    

    
    /// <summary>
    /// Creates offset perlin noise
    /// </summary>
    public float OffsetPerlinNoise(float xPosition, float yPosition, float zPosition, float noiseScale, float xOffset, float yOffset, float zOffset, float frequency)
    {
        float perlinValue = 0f;
        var devisor = (noiseScale != 0 && frequency != 0) ? noiseScale * frequency : 1;
        float x = (xPosition + xOffset) / devisor;
        float y = (yPosition - yOffset) / devisor;
        float z = (zPosition + zOffset) / devisor;

        perlinValue = Perlin3D(x, y, z) * 2 - 1;

        return perlinValue;

    }



    /// <summary>
    /// Creates perlin octave noise
    /// </summary>
    /// <param name="octaveAmount"></param>
    /// <param name="resolution"></param>
    /// <param name="offsetX"></param>
    /// <param name="offsetY"></param>
    /// <param name="noisePersistance"></param>
    /// <param name="noiseLacunarity"></param>
    /// <param name="noiseScale"></param>
    /// <param name="normalizeHeightGlobally"></param>
    /// <param name="roughness"></param>
    /// <returns></returns>
    public float[,] PerlinOctaves(int octaveAmount, int resolution, float offsetX, float offsetY, 
    float noisePersistance, float noiseLacunarity, float noiseScale, float roughness = 10000)
    {
        if(octaveAmount < 1) octaveAmount = 1;
        if(noisePersistance <= 0) noisePersistance = 0.001f;
        if(noiseLacunarity < 0.01f) noiseLacunarity = 0.01f;
        float[,] noiseMap = new float[resolution + 1,resolution + 1];
        float[] octaveOffsetsX = new float[octaveAmount];
        float[] octaveOffsetsY = new float[octaveAmount];
        float center = resolution/2;
        float amplitude = 1;
        float frequency = 1;
        int x = 0;
        int y = 0;

        //GetOctaves;
        for (int i = 0; i < octaveAmount; i++)
        {
            float newX = Range(-roughness, roughness) + offsetX + center;
            float newY = Range(-roughness, roughness) - offsetY - center;
            octaveOffsetsX[i] = newX;
            octaveOffsetsY[i] = newY;
        }

        

        for(int i = 0; i < MathG.sqr(resolution+1); i++) {
            amplitude = 1;
            frequency = 1;
            float noiseValue = 0;



            for(int j = 0; j < octaveAmount; j++) {
                float noise = OffsetPerlinNoise(x,y,noiseScale,octaveOffsetsX[j], octaveOffsetsY[j],center,center,frequency);
                noiseValue += (noise * amplitude);
                amplitude *= noisePersistance;
                frequency *= noiseLacunarity;
            }

            

            noiseMap[x,y] = noiseValue;

            y+=1;
            
            if(y >= resolution) {
                x+=1;
                y=0;
            }
            else if(x >= resolution) {
                break;
            }

        }

        return noiseMap;

    }




    /// <summary>
    /// Creates perlin octave noise
    /// </summary>
    /// <param name="octaveAmount"></param>
    /// <param name="resolution"></param>
    /// <param name="offsetX"></param>
    /// <param name="offsetY"></param>
    /// <param name="noisePersistance"></param>
    /// <param name="noiseLacunarity"></param>
    /// <param name="noiseScale"></param>
    /// <param name="normalizeHeightGlobally"></param>
    /// <param name="roughness"></param>
    /// <returns></returns>
    public float[,,] PerlinOctaves(int octaveAmount, int resolution, float offsetX, float offsetY, float offsetZ,
    float noisePersistance, float noiseLacunarity, float noiseScale, float roughness = 10000)
    {
        if(octaveAmount < 1) octaveAmount = 1;
        if(noisePersistance <= 0) noisePersistance = 0.001f;
        if(noiseLacunarity <= 0) noiseLacunarity = 0.001f;
        float[,,] noiseMap = new float[resolution + 1, resolution + 1, resolution + 1];
        float[] octaveOffsetsX = new float[octaveAmount];
        float[] octaveOffsetsY = new float[octaveAmount];
        float[] octaveOffsetsZ = new float[octaveAmount];
        float center = resolution/2;
        float amplitude = 1;
        float frequency = 1;

        int x = 0;
        int y = 0;
        int z = 0;

        //GetOctaves;
        for (int i = 0; i < octaveAmount; i++)
        {
            float newX = Range(-roughness, roughness) + offsetX + center;
            float newY = Range(-roughness, roughness) - offsetY - center;
            float newZ = Range(-roughness, roughness) - offsetZ - center;
            octaveOffsetsX[i] = newX;
            octaveOffsetsY[i] = newY;
            octaveOffsetsZ[i] = newZ;
        }

        

        for(int i = 0; i < MathG.cubed(resolution+1); i++) {
            amplitude = 1;
            frequency = 1;
            float noiseValue = 0;


            for(int j = 0; j < octaveAmount; j++) {
                float noise = OffsetPerlinNoise(x,y,z,noiseScale, octaveOffsetsX[j], octaveOffsetsY[j], octaveOffsetsZ[j], center, center, center,frequency);
                noiseValue += (noise * amplitude);
                amplitude *= noisePersistance;
                frequency *= noiseLacunarity;
            }

            

            noiseMap[x,y,z] = noiseValue;

            z+=1;
            
            if(z >= resolution) {
                y+=1;
                z=0;
            }
            else if(y >= resolution) {
                x+=1;
                y=0;
            }
            else if(x >= resolution) {
                break;
            }

        }

        return noiseMap;

    }


    /// <summary>
    /// Creates perlin octave noise
    /// </summary>
    /// <param name="octaveAmount"></param>
    /// <param name="resolution"></param>
    /// <param name="offsetX"></param>
    /// <param name="offsetY"></param>
    /// <param name="noisePersistance"></param>
    /// <param name="noiseLacunarity"></param>
    /// <param name="noiseScale"></param>
    /// <param name="normalizeHeightGlobally"></param>
    /// <param name="roughness"></param>
    /// <returns></returns>
    public float[,] PerlinOctaves(int octaveAmount, int resolution, float offsetX, float offsetY, 
    float noisePersistance, float noiseLacunarity, float noiseScale, bool normalizeHeightGlobally, float roughness = 10000)
    {
        if(octaveAmount < 1) octaveAmount = 1;
        if(noisePersistance <= 0) noisePersistance = 0.001f;
        if(noiseLacunarity < 0.01f) noiseLacunarity = 0.01f;
        float[,] noiseMap = new float[resolution + 1,resolution + 1];
        float[] octaveOffsetsX = new float[octaveAmount];
        float[] octaveOffsetsY = new float[octaveAmount];
        float center = resolution/2;
        float amplitude = 1;
        float frequency = 1;
        int x = 0;
        int y = 0;
        float maximumHeight = 0;
        float minimumHeight = 0;

        //GetOctaves;
        for (int i = 0; i < octaveAmount; i++)
        {
            float newX = Range(-roughness, roughness) + offsetX + center;
            float newY = Range(-roughness, roughness) - offsetY - center;
            octaveOffsetsX[i] = newX;
            octaveOffsetsY[i] = newY;
            maximumHeight += amplitude;
            minimumHeight -= amplitude;
            amplitude *= noisePersistance;
        }

        

        for(int i = 0; i < MathG.sqr(resolution+1); i++) {
            amplitude = 1;
            frequency = 1;
            float noiseValue = 0;



            for(int j = 0; j < octaveAmount; j++) {
                float noise = OffsetPerlinNoise(x,y,noiseScale,octaveOffsetsX[j], octaveOffsetsY[j],center,center,frequency);
                noiseValue += (noise * amplitude);
                amplitude *= noisePersistance;
                frequency *= noiseLacunarity;
            }

            if (noiseValue < minimumHeight) minimumHeight = noiseValue;
            else if (noiseValue > maximumHeight) maximumHeight = noiseValue;


            if (normalizeHeightGlobally){
                var normalizedHeight = (noiseValue + 1f) / (maximumHeight / 0.9f);
                noiseValue = MathG.Clamp(normalizedHeight, 0, int.MaxValue);
            } else {
                noiseValue = MathG.Clamp(noiseValue,minimumHeight, maximumHeight);
            }

            noiseMap[x,y] = noiseValue;

            y+=1;
            
            if(y >= resolution) {
                x+=1;
                y=0;
            }
            else if(x >= resolution) {
                break;
            }

        }

        return noiseMap;

    }




    /// <summary>
    /// Creates perlin octave noise
    /// </summary>
    /// <param name="octaveAmount"></param>
    /// <param name="resolution"></param>
    /// <param name="offsetX"></param>
    /// <param name="offsetY"></param>
    /// <param name="noisePersistance"></param>
    /// <param name="noiseLacunarity"></param>
    /// <param name="noiseScale"></param>
    /// <param name="normalizeHeightGlobally"></param>
    /// <param name="roughness"></param>
    /// <returns></returns>
    public float[,,] PerlinOctaves(int octaveAmount, int resolution, float offsetX, float offsetY, float offsetZ,
    float noisePersistance, float noiseLacunarity, float noiseScale, bool normalizeHeightGlobally, float roughness = 10000)
    {
        if(octaveAmount < 1) octaveAmount = 1;
        if(noisePersistance <= 0) noisePersistance = 0.001f;
        if(noiseLacunarity <= 0) noiseLacunarity = 0.001f;
        float[,,] noiseMap = new float[resolution + 1, resolution + 1, resolution + 1];
        float[] octaveOffsetsX = new float[octaveAmount];
        float[] octaveOffsetsY = new float[octaveAmount];
        float[] octaveOffsetsZ = new float[octaveAmount];
        float center = resolution/2;
        float amplitude = 1;
        float frequency = 1;
        float maximumHeight = 0;
        float minimumHeight = 0;

        int x = 0;
        int y = 0;
        int z = 0;

        //GetOctaves;
        for (int i = 0; i < octaveAmount; i++)
        {
            float newX = Range(-roughness, roughness) + offsetX + center;
            float newY = Range(-roughness, roughness) - offsetY - center;
            float newZ = Range(-roughness, roughness) - offsetZ - center;
            octaveOffsetsX[i] = newX;
            octaveOffsetsY[i] = newY;
            octaveOffsetsZ[i] = newZ;
            maximumHeight += amplitude;
            minimumHeight -= amplitude;
            amplitude *= noisePersistance;
        }

        

        for(int i = 0; i < MathG.cubed(resolution+1); i++) {
            amplitude = 1;
            frequency = 1;
            float noiseValue = 0;


            for(int j = 0; j < octaveAmount; j++) {
                float noise = OffsetPerlinNoise(x,y,z,noiseScale, octaveOffsetsX[j], octaveOffsetsY[j], octaveOffsetsZ[j], center, center, center,frequency);
                noiseValue += (noise * amplitude);
                amplitude *= noisePersistance;
                frequency *= noiseLacunarity;
            }

            if (noiseValue < minimumHeight) minimumHeight = noiseValue;
            else if (noiseValue > maximumHeight) maximumHeight = noiseValue;


            if (normalizeHeightGlobally){
                var normalizedHeight = (noiseValue + 1f) / (maximumHeight / 0.9f);
                noiseValue = MathG.Clamp(normalizedHeight, 0, int.MaxValue);
            } else {
                noiseValue = MathG.Clamp(noiseValue,minimumHeight, maximumHeight);
            }

            noiseMap[x,y,z] = noiseValue;

            z+=1;
            
            if(z >= resolution) {
                y+=1;
                z=0;
            }
            else if(y >= resolution) {
                x+=1;
                y=0;
            }
            else if(x >= resolution) {
                break;
            }

        }

        return noiseMap;

    }





    #endregion

    

    public double ValueNoise3D(int x, int y, int z, int seed)
    {
        return 1.0 - (ValueNoise3DInt(x, y, z, seed) / 1073741824.0);
    }

    public double ValueNoise2D(int x, int y, int seed)
    {
        return 1.0 - (ValueNoise2DInt(x, y, seed) / 1073741824.0);
    }

    public double ValueNoise1D(int x, int seed)
    {
        return 1.0 - (ValueNoise1DInt(x, seed) / 1073741824.0);
    }



    public long ValueNoise3DInt(int x, int y, int z, int seed)
    {
        long n = (NextInt() * x + NextInt() * y + NextInt() * z +
                  this.seed * seed) & 0x7fffffff;
        n = (n >> 13) ^ n;
        return (n * (n * n * 60493 + 19990303) + 1376312589) & 0x7fffffff;
    }


    public long ValueNoise2DInt(int x, int y, int seed)
    {
        long n = (NextInt() * x + NextInt() * y +
                  this.seed * seed) & 0x7fffffff;
        n = (n >> 13) ^ n;
        return (n * (n * n * 60493 + 19990303) + 1376312589) & 0x7fffffff;
    }


    public long ValueNoise1DInt(int x, int seed)
    {
        long n = (NextInt() * x + this.seed * seed) & 0x7fffffff;
        n = (n >> 13) ^ n;
        return (n * (n * n * 60493 + 19990303) + 1376312589) & 0x7fffffff;
    }


    /// <summary>
    /// Returns the output value for the given input coordinates.
    /// </summary>
    /// <param name="x">The input coordinate on the x-axis.</param>
    /// <param name="y">The input coordinate on the y-axis.</param>
    /// <param name="z">The input coordinate on the z-axis.</param>
    /// <returns>The resulting output value.</returns>
    public double Voronoi(double x, double frequency, bool useDistance, double displacement)
    {
        x *= frequency * NextDouble();
        var xi = (x > 0.0 ? (int)x : (int)x - 1);
        var md = 2147483647.0;
        double xc = 0;

            for (var xcu = xi - 2; xcu <= xi + 2; xcu++)
            {
                var xp = xcu + ValueNoise1D(xcu, seed);
                var xd = xp - x;
                var d = xd * xd;
                if (d < md)
                {
                    md = d;
                    xc = xp;
                }
            }


        double v;
        if (useDistance)
        {
            var xd = xc - x;

            v = (MathG.sqrt(xd * xd)) * MathG.SQRT3 - 1.0;
        }
        else
        {
            v = 0.0;
        }
        return v + (displacement * ValueNoise1D((MathG.FloorToInt(xc)), 0));
    }


    /// <summary>
    /// Returns the output value for the given input coordinates.
    /// </summary>
    /// <param name="x">The input coordinate on the x-axis.</param>
    /// <param name="y">The input coordinate on the y-axis.</param>
    /// <param name="z">The input coordinate on the z-axis.</param>
    /// <returns>The resulting output value.</returns>
    public double Voronoi(double x, double y, double frequency, bool useDistance, double displacement)
    {
        x *= frequency * NextDouble();
        y *= frequency * NextDouble();
        var xi = (x > 0.0 ? (int)x : (int)x - 1);
        var iy = (y > 0.0 ? (int)y : (int)y - 1);
        var md = 2147483647.0;
        double xc = 0;
        double yc = 0;
        for (var ycu = iy - 2; ycu <= iy + 2; ycu++)
        {
            for (var xcu = xi - 2; xcu <= xi + 2; xcu++)
            {
                var xp = xcu + ValueNoise2D(xcu, ycu, seed);
                var yp = ycu + ValueNoise2D(xcu, ycu, seed + 1);
                var xd = xp - x;
                var yd = yp - y;
                var d = xd * xd + yd * yd;
                if (d < md)
                {
                    md = d;
                    xc = xp;
                    yc = yp;
                }
            }
        }

        double v;
        if (useDistance)
        {
            var xd = xc - x;
            var yd = yc - y;

            v = (MathG.sqrt(xd * xd + yd * yd)) * MathG.SQRT3 - 1.0;
        }
        else
        {
            v = 0.0;
        }
        return v + (displacement * ValueNoise2D((MathG.FloorToInt(xc)), (MathG.FloorToInt(yc)), 0));
    }


    /// <summary>
    /// Returns the output value for the given input coordinates.
    /// </summary>
    /// <param name="x">The input coordinate on the x-axis.</param>
    /// <param name="y">The input coordinate on the y-axis.</param>
    /// <param name="z">The input coordinate on the z-axis.</param>
    /// <returns>The resulting output value.</returns>
    public double Voronoi(double x, double y, double z, double frequency, bool useDistance, double displacement)
    {
        x *= frequency * NextDouble();
        y *= frequency * NextDouble();
        z *= frequency * NextDouble();
        var xi = (x > 0.0 ? (int)x : (int)x - 1);
        var iy = (y > 0.0 ? (int)y : (int)y - 1);
        var iz = (z > 0.0 ? (int)z : (int)z - 1);
        var md = 2147483647.0;
        double xc = 0;
        double yc = 0;
        double zc = 0;
        for (var zcu = iz - 2; zcu <= iz + 2; zcu++)
        {
            for (var ycu = iy - 2; ycu <= iy + 2; ycu++)
            {
                for (var xcu = xi - 2; xcu <= xi + 2; xcu++)
                {
					var xp = xcu + ValueNoise3D(xcu, ycu, zcu, seed);
					var yp = ycu + ValueNoise3D(xcu, ycu, zcu, seed + 1);
					var zp = zcu + ValueNoise3D(xcu, ycu, zcu, seed + 2);
                    var xd = xp - x;
                    var yd = yp - y;
                    var zd = zp - z;
                    var d = xd * xd + yd * yd + zd * zd;
                    if (d < md)
                    {
                        md = d;
                        xc = xp;
                        yc = yp;
                        zc = zp;
                    }
                }
            }
        }
        double v;
        if (useDistance)
        {
            var xd = xc - x;
            var yd = yc - y;
            var zd = zc - z;
            
            v = (MathG.sqrt(xd * xd + yd * yd + zd * zd)) * MathG.SQRT3 - 1.0;
        }
        else
        {
            v = 0.0;
        }
        return v + (displacement * ValueNoise3D((MathG.FloorToInt(xc)), (MathG.FloorToInt(yc)),
            (MathG.FloorToInt(zc)), 0));
    }

	public float Voronoi(float x, float y, float z, float frequency, bool useDistance, float displacement) => (float)(Voronoi((double)x, (double)y, (double)z, (double)frequency, useDistance, (double)displacement));
	public float Voronoi(int x, int y, int z, float frequency, bool useDistance, float displacement) => (float)(Voronoi((double)x, (double)y, (double)z, (double)frequency, useDistance, (double)displacement));
    public float Voronoi(float x, float y, float frequency, bool useDistance, float displacement) => (float)(Voronoi((double)x, (double)y, (double)frequency, useDistance, (double)displacement));
    public float Voronoi(int x, int y, float frequency, bool useDistance, float displacement) => (float)(Voronoi((double)x, (double)y, (double)frequency, useDistance, (double)displacement));    
    public float Voronoi(float x, float frequency, bool useDistance, float displacement) => (float)(Voronoi((double)x, (double)frequency, useDistance, (double)displacement));
    public float Voronoi(int x, float frequency, bool useDistance, float displacement) => (float)(Voronoi((double)x, (double)frequency, useDistance, (double)displacement));
} //End class



