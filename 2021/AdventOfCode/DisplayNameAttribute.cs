using System;

namespace AdventOfCode
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DisplayNameAttribute : Attribute
    {
        private readonly string name;

        public DisplayNameAttribute(string name)
        {
            this.name = name;
        }

        public virtual string Name => name;
    }
}
