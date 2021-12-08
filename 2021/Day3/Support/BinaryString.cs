using System;

namespace Day3.Support
{
    public readonly struct BinaryString
    {
        private readonly char[] digits;

        public char[] Digits => digits;

        public char this[int index]
        {
            get
            {
                return Digits[index];
            }
        }

        public int Length
        {
            get
            {
                return Digits.Length;
            }
        }

        public BinaryString(int value) : this(Convert.ToString(value, 2))
        {
        }

        public BinaryString(string value) : this(value.ToCharArray())
        {
        }

        public BinaryString(char[] value)
        {
            digits = value;
        }

        public int ToInt32()
        {
            return Convert.ToInt32(ToString(), 2);
        }

        public override string ToString()
        {
            return string.Join("", Digits);
        }

        public static implicit operator int(BinaryString value)
        {
            return value.ToInt32();
        }

        public static explicit operator BinaryString(int value)
        {
            return new BinaryString(value);
        }

        public static explicit operator BinaryString(string value)
        {
            return new BinaryString(value);
        }

        public static explicit operator BinaryString(char[] value)
        {
            return new BinaryString(value);
        }

        public static BinaryString operator *(BinaryString a, BinaryString b)
        {
            return new BinaryString((int)a * b);
        }
    }
}
