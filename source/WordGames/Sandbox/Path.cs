using System;
using System.Collections;
using System.Collections.Generic;

namespace Sandbox
{
    public class Path : IEnumerable<Point>, ICloneable
    {
        private List<Point> _points;

        public int Length { get { return _points.Count; } }
        public Point Last { get { return _points[_points.Count - 1]; } }
        public Point this[int index] { get { return _points[index]; } }

        public Path()
        {
            _points = new List<Point>();
        }
        public Path(IEnumerable<Point> path) { _points = new List<Point>(path); }

        public void Add(Point point) { _points.Add(point); }
        public bool Contains(Point point) { return _points.Contains(point); }

        #region IEnumerable<Point> members

        public IEnumerator<Point> GetEnumerator()
        {
            return _points.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _points.GetEnumerator();
        }
        #endregion

        #region ICloneable members
        
        public object Clone() { return new Path(_points); }
        #endregion

        public override string ToString()
        {
            return string.Join(" -> ", _points);
        }
    }
}
