namespace Recognizer
{
	public static class GrayscaleTask
	{
		 // Яркость = (0.299*R + 0.587*G + 0.114*B) / 255
		public static double[,] ToGrayscale(Pixel[,] original)
		{
			int xLength = original.GetLength(0);
			int yLength = original.GetLength(1);
			double[,] result = new double[xLength, yLength];
			for (int i = 0; i < xLength; i++)
			{
				for (int j = 0; j < yLength; j++)
				{
					result[i, j] = (0.299 * original[i, j].R + 0.587 * original[i, j].G + 0.114 * original[i, j].B) / 255;
                }
			}
			return result;
		}
	}
}