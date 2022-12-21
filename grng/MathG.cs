using System;
using System.Linq; //Library allows us to query collections

/// <summary>
/// Class for math things and math things I thought were neat and wanted to include.
/// Sources:
///     Me, Tim Robbins,
///     Freya Holmer: https://github.com/FreyaHolmer/Mathfs/blob/master/Mathfs.cs,
/// 	Sebastian Lague: https://github.com/SebLague
/// </summary>
public static partial class MathG
{

#region CONSTANTS

    public const float TAU = 6.28318530717959f;
	public const float PI = 3.14159265359f;
	public const float E = 2.71828182846f;
	public const float GOLDEN_RATIO = 1.61803398875f;
	public const float SQRT2 = 1.41421356237f;
	public const double SQRT3 = 1.7320508075688772935;
	public const float Infinity = System.Single.PositiveInfinity;
	public const float NegativeInfinity = System.Single.NegativeInfinity;
	public const float Deg2Rad = TAU / 360f;
	public const float Rad2Deg = 360f / TAU;


#endregion


#region MIN/MAX
	public static float Min( float a, float b ) => a < b ? a : b;        
	public static int Min( int a, int b ) => a < b ? a : b;
	public static long Min( long a, long b ) => a < b ? a : b;
	public static double Min( double a, double b ) => a < b ? a : b;


	public static float Max( float a, float b ) => a > b ? a : b;
	public static int Max( int a, int b ) => a > b ? a : b;
	public static long Max( long a, long b ) => a > b ? a : b;
	public static double Max( double a, double b ) => a > b ? a : b;



	public static float Min( float a, float b, float c ) => Min( Min( a, b ), c );
	public static float Min( float a, float b, float c, float d ) => Min( Min( a, b ), Min( c, d ) );
	public static int Min( int a, int b, int c ) => Min( Min( a, b ), c );
	public static int Min( int a, int b, int c, int d ) => Min( Min( a, b ), Min( c, d ) );


	public static float Max( float a, float b, float c ) => Max( Max( a, b ), c );
	public static float Max( float a, float b, float c, float d ) => Max( Max( a, b ), Max( c, d ) );
	public static int Max( int a, int b, int c ) => Max( Max( a, b ), c );
	public static int Max( int a, int b, int c, int d ) => Max( Max( a, b ), Max( c, d ) );


	public static float Min( params float[] values ) => values.Min();
	public static float Max( params float[] values ) => values.Max();
	public static int Min( params int[] values ) => values.Min();
	public static int Max( params int[] values ) => values.Max();


#endregion
 

#region ABS

    /// <summary>
    /// Returns the absolute value of the passed value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static float Abs( float value ) => (value < 0) ? -value: value;
        


    /// <summary>
    /// Returns the absolute value of the passed value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
	public static int Abs( int value ) => (value < 0) ? -value: value;


    /// <summary>
    /// Returns the absolute value of the passed value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static long Abs( long value ) => (value < 0) ? -value: value;


    /// <summary>
    /// Returns the absolute value of the passed value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
	public static double Abs( double value ) => (value < 0) ? -value: value;


    public static float nAbs( float value ) => (value > 0) ? -value: value;
    public static int nAbs( int value ) => (value > 0) ? -value: value;
    public static long nAbs( long value ) => (value > 0) ? -value: value;
    public static double nAbs( double value ) => (value > 0) ? -value: value;


#endregion


#region EXPONENTS_AND_ROOTS

    public static float sqr( this float v ) => v * v;
    public static int sqr( this int v ) => v * v;
    public static long sqr( this long v ) => v * v;
    public static double sqr( this double v ) => v * v;

	public static float cubed( this float v ) => v * v * v;
	public static int cubed(this int v ) => v * v * v;
	public static long cubed(this long v ) => v * v * v;
	public static double cubed(this double v ) => v * v * v;
 
    public static double sqrt( this double v ) => (float)Math.Sqrt(v);
    public static float sqrt( this float v ) => (float)Math.Sqrt(v);
    public static float sqrt( this int v ) =>   (float)Math.Sqrt(v);
    public static float sqrt( this long v ) =>  (float)Math.Sqrt(v);


	public static float cbrt(this double v) => (float)System.Math.Cbrt(v);
	public static float cbrt(this float v) => (float)System.Math.Cbrt(v);
	public static float cbrt(this int v) => (float)System.Math.Cbrt(v);
	public static float cbrt(this long v) => (float)System.Math.Cbrt(v);


#endregion


#region ATLEAST/ATMOST/WITHIN/BETWEEN

	/// <summary>
	/// Inclusive >=
	/// </summary>
	/// <param name="v"></param>
	/// <param name="min"></param>
	/// <returns></returns>
    public static bool IsAtLeast( this float v, float min ) => (v >= min) ? true: false;

	/// <summary>
	/// Inclusive >=
	/// </summary>
	/// <param name="v"></param>
	/// <param name="min"></param>
	/// <returns></returns>
    public static bool IsAtLeast( this double v, double min ) => (v >= min) ? true: false;

	/// <summary>
	/// Inclusive >=
	/// </summary>
	/// <param name="v"></param>
	/// <param name="min"></param>
	/// <returns></returns>
    public static bool IsAtLeast( this int v, int min ) => (v >= min) ? true: false;

	/// <summary>
	/// Inclusive >=
	/// </summary>
	/// <param name="v"></param>
	/// <param name="min"></param>
	/// <returns></returns>
    public static bool IsAtLeast( this long v, long min ) => (v >= min) ? true: false;

	/// <summary>
	/// Inclusive <=
	/// </summary>
	/// <param name="v"></param>
	/// <param name="min"></param>
	/// <returns></returns>
	public static bool IsAtMost( this float v, float max ) => (v <= max) ? true: false;

	/// <summary>
	/// Inclusive <=
	/// </summary>
	/// <param name="v"></param>
	/// <param name="min"></param>
	/// <returns></returns>
	public static bool IsAtMost( this double v, double max ) => (v <= max) ? true: false;

	/// <summary>
	/// Inclusive <=
	/// </summary>
	/// <param name="v"></param>
	/// <param name="min"></param>
	/// <returns></returns>
	public static bool IsAtMost( this int v, int max ) => (v <= max) ? true: false;

	/// <summary>
	/// Inclusive <=
	/// </summary>
	/// <param name="v"></param>
	/// <param name="min"></param>
	/// <returns></returns>
	public static bool IsAtMost( this long v, long max ) => (v <= max) ? true: false;

	/// <summary>
	/// Checks if value is within the min and max, including the min and max
	/// </summary>
	/// <param name="v"></param>
	/// <param name="min"></param>
	/// <param name="max"></param>
	/// <returns></returns>
	public static bool IsWithin( this float v, float min, float max ) => v >= min && v <= max;

	/// <summary>
	/// Checks if value is within the min and max, including the min and max
	/// </summary>
	/// <param name="v"></param>
	/// <param name="min"></param>
	/// <param name="max"></param>
	/// <returns></returns>
	public static bool IsWithin( this int v, int min, int max ) => v >= min && v <= max;

	/// <summary>
	/// Checks if value is between the min and max, NOT including the min and max
	/// </summary>
	/// <param name="v"></param>
	/// <param name="min"></param>
	/// <param name="max"></param>
	/// <returns></returns>
	public static bool IsBetween( this float v, float min, float max ) => v > min && v < max;

	/// <summary>
	/// Checks if value is between the min and max, NOT including the min and max
	/// </summary>
	/// <param name="v"></param>
	/// <param name="min"></param>
	/// <param name="max"></param>
	/// <returns></returns>
	public static bool IsBetween( this int v, int min, int max ) => v > min && v < max;




#endregion


#region TRIG

    public static float Sin( float angRad ) => (float)Math.Sin( angRad );
	public static float Cos( float angRad ) => (float)Math.Cos( angRad );
	public static float Tan( float angRad ) => (float)Math.Tan( angRad );
	public static float Asin( float value ) => (float)Math.Asin( value );
	public static float Acos( float value ) => (float)Math.Acos( value );
	public static float Atan( float value ) => (float)Math.Atan( value );
	public static float Atan2( float y, float x ) => (float)Math.Atan2( y, x );
	public static float Csc( float x ) => 1f / (float)Math.Sin( x );
	public static float Sec( float x ) => 1f / (float)Math.Cos( x );
	public static float Cot( float x ) => 1f / (float)Math.Tan( x );
	public static float Ver( float x ) => 1 - (float)Math.Cos( x );
	public static float Cvs( float x ) => 1 - (float)Math.Sin( x );
	public static float Crd( float x ) => 2 * (float)Math.Sin( x / 2 );


	#endregion


	#region OTHER_OPERATIONS
	
    public static int Mod( int value, int length ) => ( value % length + length ) % length;
	public static float Pow( float @base, float exponent ) => (float)Math.Pow( @base, exponent );
	public static float Log( float value, float @base ) => (float)Math.Log( value, @base );
	public static float Exp( float power ) => (float)Math.Exp( power );
	public static float Log( float value ) => (float)Math.Log( value );
	public static float Log10( float value ) => (float)Math.Log10( value );
    public static float Fract( this float v ) => v - (float)Math.Floor( v );

    public static float Smooth01( float x ) => x * x * ( 3 - 2 * x );
	public static float Smoother01( float x ) => x * x * x * ( x * ( x * 6 - 15 ) + 10 );
	public static float SmoothCos01( float x ) => Cos( x * PI ) * -0.5f + 0.5f;
        
    public static float SmoothStep(float a, float b, float t) {
        float x = Clamp01((t - Min(a,b)) / (Max(a,b) - (Min(a,b))));
        return x*x*(3-2*x);
    }

    public static float SmootherStep(float a, float b, float t) {
        float x = Clamp01((t - a) / (b - a));
        return x*x*x*(x*(x*6-15)+15);
    }

    public static float Gamma( float value, float absmax, float gamma ) {
		bool negative = value < 0F;
		float absval = Abs( value );
		if( absval > absmax )
			return negative ? -absval : absval;

		float result = Pow( absval / absmax, gamma ) * absmax;
		return negative ? -result : result;
	}

    /// <summary>
    /// Creates a neato pi sin wave
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static float SinPi(float x, float t=0) => Sin(PI * (x+t));



    /// <summary>
    /// Creates a neato pi cos wave
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static float CosPi(float x,float t=0) => Sin(PI * (x+t));

	public static float Distance(float a, float b) => (a - b);
	public static float Distance(int a, int b) => (a - b);
	public static double Distance(double a, double b) => (a - b);


	public static float DistanceSquared(float a, float b) => (a - b).sqr();
	public static float DistanceSquared(int a, int b) => (a - b).sqr();
	public static double DistanceSquared(double a, double b) => (a - b).sqr();


	#endregion


	#region CLAMPING

	public static float Clamp( this float value, float min, float max ) {
		if( value < min ) value = min;
		if( value > max ) value = max;
		return value;
	}

	public static int Clamp(this int value, int min, int max ) {
		if( value < min ) value = min;
		if( value > max ) value = max;
		return value;
	}

	public static float Clamp01(this float value ) {
		if( value < 0f ) value = 0f;
		if( value > 1f ) value = 1f;
		return value;
	}

	public static double Clamp01(this double value ) {
		if( value < 0f ) value = 0f;
		if( value > 1f ) value = 1f;
		return value;
	}

	public static float ClampNeg1to1(this float value ) {
		if( value < -1f ) value = -1f;
		if( value > 1f ) value = 1f;
		return value;
	}

    /// <summary>
    /// Clamps between negative 1 and 1
    /// </summary>
    /// <param name="v">this value</param>
    /// <returns>new clamped this value</returns>
    public static float ClampN1to1( this float v ) => (v < -1) ? -1 : (v > 1) ? 1 : v;


    /// <summary>
    /// Clamps between the negative value and the abs value
    /// </summary>
    /// <param name="v">this value</param>
    /// <param name="val">the value to value clamp</param>
    /// <returns>Clamped value</returns>
    public static float ClampNValtoVal( this float v, float val) => (v < nAbs(val)) ? nAbs(val) : (v > Abs(val)) ? Abs(val) : v;


	public static float Floor0(this float v) => (v < 0) ? 0 : v;
	public static float Floor1(this float v) => (v < 1) ? 1 : v;


#endregion


#region ROUNDING

	public static int Sign( float value ) => value >= 0f ? 1 : -1;
	public static int Sign( int value ) => value >= 0 ? 1 : -1;
	public static long Sign( long value ) => value >= 0 ? 1 : -1;
	public static double Sign( double value ) => value >= 0 ? 1 : -1;


	public static int SignWithZero( int value ) => value == 0 ? 0 : Sign( value );
	public static long SignWithZero( long value ) => value == 0 ? 0 : Sign( value );
        

    public static float Floor( float value ) => (float)Math.Floor( value );
	public static double Floor( double value ) => Math.Floor( value );
    public static float Ceil( float value ) => (float)Math.Ceiling( value );
	public static float Round( float value ) => (float)Math.Round( value );
	public static float Round( float value, float snapInterval ) => (float)Math.Round( value / snapInterval ) * snapInterval;
	public static int FloorToInt( float value ) => (int)Math.Floor( value );
	public static int FloorToInt( double value ) => (int)Math.Floor( value );
	public static int CeilToInt( float value ) => (int)Math.Ceiling( value );
	public static int RoundToInt( float value ) => (int)Math.Round( value );
	public static int RoundToInt( double value ) => (int)Math.Round( value );


#endregion


#region HAILSTONE

    /// <summary>
    /// Uses the collatz 3x+1 problem and returns the value at the stoping point. Breaks upon reaching the infinite loop
    /// </summary>
    /// <param name="startingValue">The value to start at</param>
    /// <param name="endingIteration">The iteration to end on</param>
    /// <returns>The value at the stoping point</returns>
    public static int HailStoneValue(int startingValue, int endingIteration)
    {
        int counts = 0;
        int currentValue = startingValue;


        do
        {
            if(currentValue % 2 == 0)
            {
                currentValue /= 2;
            }
            else
            {
                currentValue = ((3 * currentValue) + 1);
            }
            counts++;

        } while (counts < endingIteration || currentValue > 1);

        return currentValue;
    }


       


    /// <summary>
    /// Uses the collatz 3x+1 problem and returns the amount of counts upon reaching the infinite loop
    /// </summary>
    /// <param name="startingValue">The value to start at</param>
    /// <returns>The amount of counts before the value hits an infinite loop</returns>
    public static int HailStoneCounts(int startingValue)
    {
        int counts = 0;
        int currentValue = startingValue;

        do
        {
            if(currentValue % 2 == 0)
            {
                currentValue /= 2;
            }
            else
            {
                currentValue = ((3 * currentValue) + 1);
            }

            counts++;

        } while (currentValue > 1);

        return counts;
    }

    /// <summary>
    /// Gets the average value from a hailstone sequence
    /// </summary>
    /// <param name="startingValue">The value to start at</param>
    /// <returns>The average value of all the hail stone values</returns>
    public static float HailStoneAverage(int startingValue)
    {
        int counts = 0;
        int currentValue = startingValue;
        float average = 0;


        do
        {
            if (currentValue % 2 == 0)
            {
                currentValue /= 2;
            }
            else
            {
                currentValue = ((3 * currentValue) + 1);
            }

            average += currentValue;

            counts++;

        } while (currentValue > 1);

        average /= counts;

        return average;

    }



#endregion


#region NORMALIZATION


        
    public static float Magnitude( this float v ) => Abs( v );
    public static float Magnitude( this double v ) => (float)Abs( v );


    /// <summary>
	/// Normalizes the value within a range. Example: (value = 8, min = 7, max = 24) = (float)0.0588235...
	/// </summary>
	/// <param name="value"></param>
	/// <param name="minPossibleValue"></param>
	/// <param name="maxPossibleValue"></param>
	/// <returns></returns>
	public static float NormalizeInRange(int value, int minPossibleValue, int maxPossibleValue) {
		float normalizedValue = 0;
		float checkedMin = Min(minPossibleValue,maxPossibleValue);
		float checkedMax = Max(minPossibleValue,maxPossibleValue);

		if(value < checkedMin || (checkedMax - checkedMin == 0)) {
			normalizedValue = 0;
		}
		else if(value > checkedMax || checkedMin == checkedMax) {
			normalizedValue = 1;
		}
		else {
			normalizedValue = ((value - checkedMin) / (checkedMax - checkedMin));
		}

		return normalizedValue;
	}


	/// <summary>
	/// Normalizes the value within a range. Example: (value = 8, min = 7, max = 24) = (float)0.0588235...
	/// </summary>
	/// <param name="value"></param>
	/// <param name="minPossibleValue"></param>
	/// <param name="maxPossibleValue"></param>
	/// <returns></returns>
	public static float NormalizeInRange(float value, float minPossibleValue, float maxPossibleValue) {
		float normalizedValue = 0f;
		float checkedMin = Min(minPossibleValue,maxPossibleValue);
		float checkedMax = Max(minPossibleValue,maxPossibleValue);

		if(value < checkedMin || (checkedMax - checkedMin == 0)) {
			normalizedValue = 0;
		}
		else if(value > checkedMax || checkedMin == checkedMax) {
			normalizedValue = 1;
		}
		else {
			normalizedValue = ((value - checkedMin) / (checkedMax - checkedMin));
		}
			
		return normalizedValue;
	}


		


    /// <summary>
	/// Normalizes the value within a range. Example: (value = 8, min = 7, max = 24) = (float)0.0588235...
	/// </summary>
	/// <param name="value"></param>
	/// <param name="minPossibleValue"></param>
	/// <param name="maxPossibleValue"></param>
	/// <returns></returns>
	public static double NormalizeInRange(double value, double minPossibleValue, double maxPossibleValue) {
		double normalizedValue = 0f;
		double checkedMin = Min(minPossibleValue,maxPossibleValue);
		double checkedMax = Max(minPossibleValue,maxPossibleValue);

		if(value < checkedMin || (checkedMax - checkedMin == 0)) {
			normalizedValue = 0;
		}
		else if(value > checkedMax || checkedMin == checkedMax) {
			normalizedValue = 1;
		}
		else {
			normalizedValue = ((value - checkedMin) / (checkedMax - checkedMin));
		}
			
		return normalizedValue;
	}

    /// <summary>
	/// Normalizes the value between 0 and 1 using (float)int.MinValue, (float)int.MaxValue)
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	public static float Normalize(float value) => (NormalizeInRange(value, (float)int.MinValue, (float)int.MaxValue));



	/// <summary>
	/// Gets the percentage of the value is in the range. Example: (value = 8, min = 7, max = 24) = (float)5.88235...
	/// </summary>
	/// <param name="value"></param>
	/// <param name="minPossibleValue"></param>
	/// <param name="maxPossibleValue"></param>
	/// <returns></returns>
	public static float PercentageInRange(float value, float minPossibleValue, float maxPossibleValue) => (NormalizeInRange(value,minPossibleValue,maxPossibleValue) * 100);


#endregion		


#region ROOTS

	/// <summary>Finds the root (x-intercept) of a linear equation of the form ax+b</summary>
	public static float GetLinearRoot( float a, float b ) => -b / a;
	public static float GetXIntercept( float a, float b ) => -b / a;

#endregion


#region INTERPOLATION
	public static float Lerp( float a, float b, float t ) => ( 1f - t ) * a + t * b;
	public static double Lerp( double a, double b, double t ) => ( 1f - t ) * a + t * b;
	public static float InverseLerp( float a, float b, float value ) => ( value - a ) / ( b - a );
	public static float InverseLerpClamped( float a, float b, float value ) => Clamp01( ( value - a ) / ( b - a ) );
    public static float Fade(float t) => (t*t*t*(t*(t*6-15)+10));
    public static double Fade(double t) => (t*t*t*(t*(t*6-15)+10));
    public static float CbLerp( float a, float b, float t ) => ( b - a ) * t + a;
    public static double CbLerp( double a, double b, double t ) => ( b - a ) * t + a;
    public static float LerpClamped( float a, float b, float t ) {
		t = Clamp01( t );
		return ( 1f - t ) * a + t * b;
	}

	public static float CbLerpClamped( float a, float b, float t ) {
		t = Clamp01( t );
		return CbLerp(a,b,t);
	}

	public static double LerpClamped( double a, double b, double t ) {
		t = Clamp01( t );
		return ( 1f - t ) * a + t * b;
	}

	public static float Eerp( float a, float b, float t ) => Pow( a, 1 - t ) * Pow( b, t );
	public static float InverseEerp( float a, float b, float v ) => Log( a / v ) / Log( a / b );

    public static float Remap( float iMin, float iMax, float oMin, float oMax, float value ) {
		float t = InverseLerp( iMin, iMax, value );
		return Lerp( oMin, oMax, t );
	}

	public static float RemapClamped( float iMin, float iMax, float oMin, float oMax, float value ) {
		float t = InverseLerpClamped( iMin, iMax, value );
		return Lerp( oMin, oMax, t );
	}

	public static float InverseLerpSmooth( float a, float b, float value ) => Smooth01( Clamp01( ( value - a ) / ( b - a ) ) );

	public static float LerpSmooth( float a, float b, float t ) {
		t = Smooth01( Clamp01( t ) );
		return ( 1f - t ) * a + t * b;
	}

    public static float MoveTowards( float current, float target, float maxDelta ) {
		if( Abs( target - current ) <= maxDelta )
			return target;
		return current + Sign( target - current ) * maxDelta;
	}


#endregion


#region CONVERSIONS

	/// <summary>
	/// Converts the float to an int
	/// </summary>
	/// <param name="v"></param>
	/// <returns></returns>
	public static int ToInt(this float v) => RoundToInt(v);

	/// <summary>
	/// Converts the float to an int
	/// </summary>
	/// <param name="v"></param>
	/// <returns></returns>
	public static int ToInt(this double v) => RoundToInt(v);

	/// <summary>
	/// Converts a boolean to an int value
	/// </summary>
	/// <param name="v"></param>
	/// <returns></returns>
	public static int ToInt(this bool v) => (v == true) ? 1 : 0;



#endregion


    
} //end class


