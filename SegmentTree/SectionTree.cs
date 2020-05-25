using System;
using System.Collections.Generic;
using System.Text;

namespace SegmentTree
{
    class SectionTree<T> where T : struct
    {
        private Unit[] _summ;
        private T[] _values;
        public int Capacity { get; private set; }

        public SectionTree(T[] data, int size)
        {
            if (data.Length > 0 && data[0] is bool) 
                throw new FormatException();

            _values = data;
            Capacity = size;
            _summ = new Unit[size * 4];

            BuildTree(data, 1, 0, size - 1);
        }

        private void BuildTree(T[] data, int currentPeak, int leftBound, int rightBound)
        {
            if (leftBound.Equals(rightBound))
                _summ[currentPeak] = new Unit(data[leftBound]);
            else
            {

                int midlePosition = (leftBound + rightBound) / 2;
                BuildTree(data, currentPeak * 2, leftBound, midlePosition);
                BuildTree(data, currentPeak * 2 + 1, midlePosition + 1, rightBound);
                _summ[currentPeak] = _summ[currentPeak * 2] + _summ[(currentPeak * 2) + 1]; 
            }
        }

        public Unit CalculateSumm(int lBoundCall, int rBoundCall) =>
            CalculateSumm(1, 0, Capacity - 1, lBoundCall, rBoundCall);

        private Unit CalculateSumm(int peak, int lBound, int rBound, int lBoundCall, int rBoundCall)
        {

            if (lBound >= lBoundCall && rBound <= rBoundCall)
                return _summ[peak];

            if (rBound < lBoundCall || rBoundCall < lBound)
                return new Unit(0);

            int middleBound = (lBound + rBound) / 2;
            return CalculateSumm(peak * 2, lBound, middleBound, lBoundCall, rBoundCall) +
                CalculateSumm(peak * 2 + 1, middleBound + 1, rBound, lBoundCall, rBoundCall);

        }

        public void UpdateValue(int index, T value) =>
            UpdateValue(index, value, 1, 0, Capacity - 1);

        private void UpdateValue(int index, T value, int peak, int lBound,int rBohnd)
        {

            if(index.Equals(lBound) && index.Equals(rBohnd))
            {
                _summ[peak] = new Unit(value);
                _values[peak] = value;
                return;
            }

            if (index < lBound || index > rBohnd)
                return;

            int middlePosition = (lBound + rBohnd) / 2;
            UpdateValue(index, value, peak * 2, lBound, middlePosition);
            UpdateValue(index, value, peak * 2 + 1, middlePosition + 1, rBohnd);
            _summ[peak] = _summ[peak * 2] + _summ[peak * 2 + 1];

        }

        public Unit MinUnit(int lBoundCall, int rBoundCall)
        {
            Unit minUnit = new Unit(0);

            if (lBoundCall > rBoundCall || rBoundCall < lBoundCall) 
                return minUnit;

            return MinUnit(1, 0, Capacity - 1, lBoundCall, rBoundCall, minUnit);
        }

        private Unit MinUnit(int peak, int lBound, int rBound, int lBoundCall, int rBoundCall, Unit minUnit)
        {

            if (lBound >= lBoundCall && rBound <= rBoundCall)
                if(_summ[peak] < minUnit)
                {
                    minUnit = _summ[peak];
                    return minUnit;
                }

            if (rBound < lBoundCall || rBoundCall < lBound)
                return new Unit(0);

            int middleBound = (lBound + rBound) / 2;

            return minUnit;

        }

    }
}
