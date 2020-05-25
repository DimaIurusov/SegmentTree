using System;
using System.Collections.Generic;
using System.Text;

namespace SegmentTree
{
    class Unit
    {
        public Type Type { get => Value.GetType(); }
        public object Value;

        public Unit(object value) =>
            this.Value = value;

        public static Unit operator + (Unit left, Unit right)
        {
            if (left.Type.Equals(right.Type))
                switch (left.Type.Name)
                {
                    case "Int32":
                        return new Unit((Int32)left.Value + (Int32)right.Value);
                    case "Double":
                        return new Unit((Double)left.Value + (Double)right.Value);
                    case "Single":
                        return new Unit((Single)left.Value + (Single)right.Value);
                }

            return null;
        }

        public static bool operator < (Unit left, Unit right)
        {
            if (left.Type.Equals(right.Type))
                switch (left.Type.Name)
                {
                    case "Int32":
                        return (Int32)left.Value < (Int32)right.Value;
                    case "Double":
                        return (Double)left.Value < (Double)right.Value;
                    case "Single":
                        return (Single)left.Value < (Single)right.Value;
                }
            throw new ArgumentException();
        }

        public static bool operator > (Unit left, Unit right)
        {
            if (left.Type.Equals(right.Type))
                switch (left.Type.Name)
                {
                    case "Int32":
                        return (Int32)left.Value > (Int32)right.Value;
                    case "Double":
                        return (Double)left.Value > (Double)right.Value;
                    case "Single":
                        return (Single)left.Value > (Single)right.Value;
                }
            throw new ArgumentException();
        }
    }
}
