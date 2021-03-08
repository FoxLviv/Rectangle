using System;
using System.Collections.Generic;
using System.Linq;

namespace Rectangle.Impl
{
	public static class Service
	{
		/// <summary>
		/// See TODO.txt file for task details.
		/// Do not change contracts: input and output arguments, method name and access modifiers
		/// </summary>
		/// <param name="points"></param>
		/// <returns></returns>
		public static Rectangle FindRectangle(List<Point> points)
		{
			if (points == null)
				throw new ArgumentNullException();
			else if (points.Count < 2)
				throw new Exception(message:"Should contain at least 2 points.");

			foreach(var A in points)
				foreach(var B in points)
					if (A.X == B.X && A.Y == B.Y)
						throw new Exception(message: "There shouldn't be points with a same coordinates.");


			int minX = points[0].X, maxX = points[0].X, minY = points[0].Y, maxY = points[0].Y;
			
			int countMinX = 1, countMaxX = 1, countMinY = 1, countMaxY = 1;

			for(int i = 1; i<points.Count;i++)
            {
				if (points[i].X > maxX)
				{
					maxX = points[i].X;					
					countMaxX = 1;
				}
				else if (points[i].X < minX)
				{
					minX = points[i].X;                    
                    countMinX = 1;
                }
				else if (points[i].X == maxX)					
					countMaxX += 1;
				else if (points[i].X == minX)				
					countMinX += 1;

				if (points[i].Y > maxY)
				{
					maxY = points[i].Y;					
					countMaxY = 1;
				}
				else if (points[i].Y < minY)
				{
					minY = points[i].Y;					
					countMinY = 1;
				}
				else if (points[i].Y == maxY)					
					countMaxY += 1;
				else if (points[i].Y == minY)					
					countMinY += 1;
			}

			if (countMinX == 1)
				return new Rectangle() { X = minX + 1, Y = minY, Height = maxY - minY, Width = maxX - minX - 1 };
			else if (countMaxX == 1)
				return new Rectangle() { X = minX, Y = minY, Height = maxY - minY, Width = maxX - minX - 1 };
			else if (countMinY == 1)
				return new Rectangle() { X = minX, Y = minY + 1, Height = maxY - minY - 1, Width = maxX - minX };
			else if (countMaxY == 1)
				return new Rectangle() { X = minX, Y = minY, Height = maxY - minY - 1, Width = maxX - minX };
			else
				throw new Exception(message: "The input list is invalid.");

		}
	}
}
