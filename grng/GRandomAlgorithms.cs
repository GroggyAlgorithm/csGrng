using System;
using System.Collections;
using System.Collections.Generic;




    /// <summary>
    /// Class for random algorithms
    /// </summary>
    public static class GRandomAlgorithms 
    {


#region XORshift32
        
        /// <summary>
        /// Performs an xorshift 32 algorithm
        /// </summary>
        /// <param name="value">The value to perform xor shift on</param>
        /// <returns>A random value</returns>
        public static int xorshift32(int value) {
            int rand = value;
            rand ^= (value << 13);
            rand ^= (value >> 17);
            rand ^= (value << 5);
            return rand;
        }


        /// <summary>
        /// Performs an xorshift 32 algorithm
        /// </summary>
        /// <param name="value">The value to perform xor shift on</param>
        /// <returns>A random value</returns>
        public static uint xorshift32(uint value) {
            uint rand = value;
            rand ^= (value << 13);
            rand ^= (value >> 17);
            rand ^= (value << 5);
            return rand;
        }


        /// <summary>
        /// Performs an xorshift 32 algorithm
        /// </summary>
        /// <param name="value">The value to perform xor shift on</param>
        /// <returns>A random value</returns>
        public static long xorshift32(long value) {
            long rand = value;
            rand ^= (value << 13);
            rand ^= (value >> 17);
            rand ^= (value << 5);
            return rand;
        }


        /// <summary>
        /// Performs an xorshift 32 algorithm
        /// </summary>
        /// <param name="value">The value to perform xor shift on</param>
        /// <returns>A random value</returns>
        public static ulong xorshift32(ulong value) {
            ulong rand = value;
            rand ^= (value << 13);
            rand ^= (value >> 17);
            rand ^= (value << 5);
            return rand;
        }

#endregion


#region XORshift64

        /// <summary>
        /// Performs an xorshift 64 algorithm
        /// </summary>
        /// <param name="value">The value to perform xor shift on</param>
        /// <returns>A random value</returns>
        public static int xorshift64(int value) {
            int rand = value;
            rand ^= (value << 13);
            rand ^= (value >> 7);
            rand ^= (value << 17);
            return rand;
        }


        /// <summary>
        /// Performs an xorshift 64 algorithm
        /// </summary>
        /// <param name="value">The value to perform xor shift on</param>
        /// <returns>A random value</returns>
        public static uint xorshift64(uint value) {
            uint rand = value;
            rand ^= (value << 13);
            rand ^= (value >> 7);
            rand ^= (value << 17);
            return rand;
        }


        /// <summary>
        /// Performs an xorshift 64 algorithm
        /// </summary>
        /// <param name="value">The value to perform xor shift on</param>
        /// <returns>A random value</returns>
        public static long xorshift64(long value) {
            long rand = value;
            rand ^= (value << 13);
            rand ^= (value >> 7);
            rand ^= (value << 17);
            return rand;
        }


        /// <summary>
        /// Performs an xorshift 64 algorithm
        /// </summary>
        /// <param name="value">The value to perform xor shift on</param>
        /// <returns>A random value</returns>
        public static ulong xorshift64(ulong value) {
            ulong rand = value;
            rand ^= (value << 13);
            rand ^= (value >> 7);
            rand ^= (value << 17);
            return rand;
        }


#endregion


#region REVERSED

    /// <summary>
    /// Xor shift variation: (value >> 17) ^ (value >> 34) ^ (value >> 51) & <data type max value>
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int reverse17(int value) {
        return ((value ^ (value >> 17) ^ (value >> 34) ^ (value >> 51)) & int.MaxValue);
    }

    /// <summary>
    /// Xor shift variation: (value >> 17) ^ (value >> 34) ^ (value >> 51) & <data type max value>
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static uint reverse17(uint value) {
        return ((value ^ (value >> 17) ^ (value >> 34) ^ (value >> 51)) & uint.MaxValue);
    }

    /// <summary>
    /// Xor shift variation: (value >> 17) ^ (value >> 34) ^ (value >> 51) & <data type max value>
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static long reverse17(long value) {
        return ((value ^ (value >> 17) ^ (value >> 34) ^ (value >> 51)) & long.MaxValue);
    }

    /// <summary>
    /// Xor shift variation: (value >> 17) ^ (value >> 34) ^ (value >> 51) & <data type max value>
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ulong reverse17(ulong value) {
        return ((value ^ (value << 23) ^ (value << 46)) & ulong.MaxValue);
    }


    /// <summary>
    /// Xor shift variation: (value << 23) ^ (value << 46)) & <data type max value>
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int reverse23(int value) {
        return ((value ^ (value << 23) ^ (value << 46)) & int.MaxValue);
    }

    /// <summary>
    ///Xor shift variation: (value << 23) ^ (value << 46)) & <data type max value>
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static uint reverse23(uint value) {
        return ((value ^ (value << 23) ^ (value << 46)) & uint.MaxValue);
    }

    /// <summary>
    /// Xor shift variation: (value << 23) ^ (value << 46)) & <data type max value>
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static long reverse23(long value) {
        return ((value ^ (value << 23) ^ (value << 46)) & long.MaxValue);
    }

    /// <summary>
    /// Xor shift variation: (value << 23) ^ (value << 46)) & <data type max value>
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ulong reverse23(ulong value) {
        return ((value ^ (value << 23) ^ (value << 46)) & ulong.MaxValue);
    }


#endregion


#region  XORshift128

        /// <summary>
        /// Performs an xorshift 128 algorithm
        /// </summary>
        /// <param name="value">The value to perform xor shift on</param>
        /// <returns>A random value</returns>
        public static int xorshift128(int value) {
            int val2 = reverse23(reverse17(value));
            int rand = value;
            rand ^= (rand << 23);
            rand ^= (rand << 17);
            rand ^= val2;
            rand ^= (val2 >> 7);
            return rand;
        }


        /// <summary>
        /// Performs an xorshift 128 algorithm
        /// </summary>
        /// <param name="value">The value to perform xor shift on</param>
        /// <returns>A random value</returns>
        public static uint xorshift128(uint value) {
            uint val2 = reverse23(reverse17(value));
            uint rand = value;
            rand ^= (rand << 23);
            rand ^= (rand << 17);
            rand ^= val2;
            rand ^= (val2 >> 7);
            return rand;
        }


        /// <summary>
        /// Performs an xorshift 128 algorithm
        /// </summary>
        /// <param name="value">The value to perform xor shift on</param>
        /// <returns>A random value</returns>
        public static long xorshift128(long value) {
            long val2 = reverse23(reverse17(value));
            long rand = value;
            rand ^= (rand << 23);
            rand ^= (rand << 17);
            rand ^= val2;
            rand ^= (val2 >> 7);
            return rand;
        }


        /// <summary>
        /// Performs an xorshift 128 algorithm
        /// </summary>
        /// <param name="value">The value to perform xor shift on</param>
        /// <returns>A random value</returns>
        public static ulong xorshift128(ulong value) {
            ulong val2 = reverse23(reverse17(value));
            ulong rand = value;
            rand ^= (rand << 23);
            rand ^= (rand << 17);
            rand ^= val2;
            rand ^= (val2 >> 7);
            return rand;
        }



#endregion


#region LEHMER

    /// <summary>
    /// A version of the Lehmer 64 algorithm
    /// </summary>
    /// <param name="value">The value to put through the algorithm</param>
    /// <returns>The psuedo random number created</returns>
    public static int Lehmer64(int value) {
        return (int)(((UInt64)value * 0xda942042e4dd58b5) >> 64);
    }

    /// <summary>
    /// A version of the Lehmer 64 algorithm
    /// </summary>
    /// <param name="value">The value to put through the algorithm</param>
    /// <returns>The psuedo random number created</returns>
    public static uint Lehmer64(uint value) {
        return (uint)(((UInt64)value * 0xda942042e4dd58b5) >> 64);
    }

    /// <summary>
    /// A version of the Lehmer 64 algorithm
    /// </summary>
    /// <param name="value">The value to put through the algorithm</param>
    /// <returns>The psuedo random number created</returns>
    public static long Lehmer64(long value) {
        return (long)(((UInt64)value * 0xda942042e4dd58b5) >> 64);
    }


    /// <summary>
    /// A version of the Lehmer 64 algorithm
    /// </summary>
    /// <param name="value">The value to put through the algorithm</param>
    /// <returns>The psuedo random number created</returns>
    public static ulong Lehmer64(ulong value) {
        return (((UInt64)value * 0xda942042e4dd58b5) >> 64);
    }


#endregion


#region AdaptedLehmer



    /// <summary>
    /// A version of the Lehmer algorithm
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static UInt32 AdaptedLehmer32(UInt32 value) {
        value += 0xe120fc15;
        UInt64 tmp = (UInt64)value * 0x4a39b70d;
        UInt32 m1 = (UInt32)((tmp >> 32) ^ tmp);
        tmp = (UInt64)m1 * 0x12fad5c9;
        return(UInt32)((tmp >> 32)^tmp);
    }

    /// <summary>
    /// A version of the Lehmer algorithm
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Int32 AdaptedLehmer32(Int32 value) {
        value += Int32.MaxValue;
        Int64 tmp = (Int64)value * 0x4a39b70d;
        Int32 m1 = (Int32)((tmp >> 32) ^ tmp);
        tmp = (Int64)m1 * 0x12fad5c9;
        return(Int32)((tmp >> 32)^tmp);
    }

    /// <summary>
    /// A version of the Lehmer algorithm
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static UInt64 AdaptedLehmer32(UInt64 value) {
        value += 0xe120fc15;
        UInt64 tmp = value * 0x4a39b70d;
        UInt64 m1 = ((tmp >> 32) ^ tmp);
        tmp = m1 * 0x12fad5c9;
        return ((tmp >> 32)^tmp);
    }

    /// <summary>
    /// A version of the Lehmer algorithm
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Int64 AdaptedLehmer32(Int64 value) {
        value += Int32.MaxValue;
        Int64 tmp = (Int64)value * 0x4a39b70d;
        Int64 m1 = ((tmp >> 32) ^ tmp);
        tmp = m1 * 0x12fad5c9;
        return ((tmp >> 32)^tmp);
    }



#endregion


#region WYHASH

    /// <summary>
    /// A version of the wyhash hash algorithm by Wang Yi
    /// </summary>
    /// <param name="value">The value to put through the algorithm</param>
    /// <returns>The psuedo random number created</returns>
    public static int wyhash(int value) {
        var v = value + (0x60bee2bee120fc15);
        var tmp = v * (0x60bee2bee120fc15);
        var m1 = ((tmp << 16) ^ tmp);
        tmp = m1 * (0x1b03738712fad5c9);
        var m2 = (tmp >> 16) ^ tmp;
        return (int)m2;
    }


    /// <summary>
    /// A version of the wyhash hash algorithm by Wang Yi
    /// </summary>
    /// <param name="value">The value to put through the algorithm</param>
    /// <returns>The psuedo random number created</returns>
    public static uint wyhash(uint value) {
        var v = value + (0x60bee2bee120fc15);
        var tmp = v * (0x60bee2bee120fc15);
        var m1 = ((tmp << 16) ^ tmp);
        tmp = m1 * (0x1b03738712fad5c9);
        var m2 = (tmp >> 16) ^ tmp;
        return (uint)m2;
    }

    /// <summary>
    /// A version of the wyhash hash algorithm by Wang Yi
    /// </summary>
    /// <param name="value">The value to put through the algorithm</param>
    /// <returns>The psuedo random number created</returns>
    public static long wyhash(long value) {
        var v = value + (0x60bee2bee120fc15);
        var tmp = v * (0x60bee2bee120fc15);
        var m1 = ((tmp << 16) ^ tmp);
        tmp = m1 * (0x1b03738712fad5c9);
        var m2 = (tmp >> 16) ^ tmp;
        return (long)m2;
    }


    /// <summary>
    /// A version of the wyhash hash algorithm by Wang Yi
    /// </summary>
    /// <param name="value">The value to put through the algorithm</param>
    /// <returns>The psuedo random number created</returns>
    public static ulong wyhash(ulong value) {
        var v = value + (0x60bee2bee120fc15);
        var tmp = v * (0x60bee2bee120fc15);
        var m1 = ((tmp << 16) ^ tmp);
        tmp = m1 * (0x1b03738712fad5c9);
        var m2 = (tmp >> 16) ^ tmp;
        return (ulong)m2;
    }


#endregion




    } //End class



