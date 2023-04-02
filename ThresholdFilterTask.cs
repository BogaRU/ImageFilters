using System;
using System.Collections.Generic;

namespace Recognizer
{
	public static class ThresholdFilterTask
	{
		public static double[,] ThresholdFilter(double[,] original, double whitePixelsFraction)
		{
			int rows = original.GetLength(0);
			int columns = original.GetLength(1);
            int whitePixelsCount = (int)Math.Floor(original.Length * whitePixelsFraction);
			if (original.Length == 1) return whitePixelsCount > 0 ? new double[,] { { 1.0 } } : new double[,] { { 0.0 } };
			double[,] result = new double[rows, columns];
            List<double> sortedOriginal = new List<double>();
            foreach (var x in original)
                sortedOriginal.Add(x);
            sortedOriginal.Sort();
			int offset = (whitePixelsCount == 0) ? 1 : 0;
			double T = sortedOriginal[sortedOriginal.Count - Math.Max(whitePixelsCount, 1)]
				+ offset * sortedOriginal[sortedOriginal.Count - Math.Max(whitePixelsCount, 1)] / 100;
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					if (original[i, j] >= T) result[i, j] = 1.0;
					else result[i, j] = 0.0;
				} 
			}
			return result;
		}
	}
}