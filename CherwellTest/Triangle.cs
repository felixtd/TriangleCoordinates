using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CherwellTest
{
	public class Triangle
	{
		private int Y;
		private int X;
		private bool isLowerTriangle;

		public Triangle(int X, int Y)
		{
			this.Y = Y;
			this.X = X;
			isLowerTriangle = X % 2 != 0;
		}

		public Triangle(Point V1, Point V2, Point V3)
		{
			this.V1 = V1;
			this.V2 = V2;
			this.V3 = V3;
			isLowerTriangle = V2.Y > V1.Y;
		}

		public void ComputeCoordinates()
		{
			if (isLowerTriangle)
			{
				int x = X - 1;
				int offset = (x / 2);
				V1 = new Point((x - offset) * 10, (Y - 1) * 10);
				V2 = new Point(V1.X, V1.Y + 10);
				V3 = new Point(V2.X + 10, V2.Y);
			}
			else
			{
				int x = X - 2;
				int offset = (x / 2);
				V1 = new Point((x - offset) * 10, (Y - 1) * 10);
				V2 = new Point(V1.X + 10, V1.Y);
				V3 = new Point(V2.X, V2.Y + 10);
			}
		}

		public int VertexToColumn(Point vertex)
		{
			int x = vertex.X;

			if (isLowerTriangle)
			{
				return 2 * (x / 10) + 1;
			}
			else
			{
				return 2 * (x / 10);
			}
		}

		public int VertexToRow(Point vertex)
		{
			if (isLowerTriangle)
			{
				return vertex.Y / 10;
			}
			else
			{
				return vertex.Y / 10 + 1;
			}
		}

		public Point V1 { get; private set; }

		public Point V2 { get; private set; }

		public Point V3 { get; private set; }

		public override string ToString()
		{
			return $"V1 = {V1.ToString()}, V2 = {V2.ToString()}, V3 = {V3.ToString()}";
		}
	}
}
