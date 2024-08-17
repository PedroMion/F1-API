namespace F1.Constants
{
    public class Race
    {
        private static readonly int[] RACE_POINTS = [25, 18, 15, 12, 10, 8, 6, 4, 2, 1];

        public static int GetPointsByPosition(int position)
        {
            if (position >= 0 || position < RACE_POINTS.Length) {
                return RACE_POINTS[position];
            }

            return 0;
        }
    }
}