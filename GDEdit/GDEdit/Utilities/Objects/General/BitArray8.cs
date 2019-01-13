﻿namespace GDEdit.Utilities.Objects.General
{
    /// <summary>Represents an array of 8 bits compactly stored in a <seealso cref="byte"/>.</summary>
    public struct BitArray8
    {
        // The LSB has index 0 and the MSB has index 7
        public byte bits;
        
        /// <summary>Initializes a new instance of the <seealso cref="BitArray8"/> struct.</summary>
        /// <param name="defaultValue">The default value to set to all the bits.</param>
        public BitArray8(bool defaultValue)
        {
            if (defaultValue)
                bits = 0b1111_1111; // Hardcode for perfomance
            else
                bits = 0;
        }
        
        /// <summary>Gets a bit of the <seealso cref="BitArray8"/> at the specified index as a <seealso cref="bool"/>.</summary>
        /// <param name="index">The index of the bit to get.</param>
        public bool GetBoolBit(int index) => GetBool(GetBit(index));
        /// <summary>Sets a bit of the <seealso cref="BitArray8"/> at the specified index as a <seealso cref="bool"/>.</summary>
        /// <param name="index">The index of the bit to set.</param>
        /// <param name="b">The bit to set at the specified index as a <seealso cref="bool"/>.</param>
        public void SetBoolBit(int index, bool b) => SetBit(index, GetByte(b));
        
        // All those casts are retarded
        /// <summary>Gets a bit of the <seealso cref="BitArray8"/> at the specified index.</summary>
        /// <param name="index">The index of the bit to get.</param>
        public byte GetBit(int index) => (byte)((byte)(bits << (7 - index)) >> 7);
        /// <summary>Sets a bit of the <seealso cref="BitArray8"/> at the specified index.</summary>
        /// <param name="index">The index of the bit to set.</param>
        /// <param name="b">The bit to set at the specified index.</param>
        public void SetBit(int index, byte b)
        {
            int left = (bits >> (index + 1)) << (index + 1);
            int right = (byte)(bits << (8 - index)) >> (8 - index);
            bits = (byte)(left | (b << index) | right);
        }
        
        /// <summary>Gets or sets a bit of the <seealso cref="BitArray8"/> at the specified index.</summary>
        /// <param name="index">The index of the bit to get or set.</param>
        public bool this[int index]
        {
            get => GetBoolBit(index);
            set => SetBoolBit(index, value);
        }
        
        // Methods are private to avoid handling exceptions
        private static bool GetBool(byte b) => b == 1;
        private static byte GetByte(bool b) => b ? (byte)1 : (byte)0;
    }
}