public static class PayTable
{
    public static Dictionary<int, int[]> payout = new Dictionary<int, int[]>()
    {
        {2, new int[]{0, 0, 11}},
        {3, new int[]{0, 0, 2, 26}},
        {4, new int[]{0, 0, 1, 5, 60}},
        {5, new int[]{0, 0, 1, 2, 11, 75}},
        {6, new int[]{0, 0, 0, 2, 7, 30, 125}},
        {7, new int[]{0, 0, 0, 1, 4, 12, 75, 200}},
        {8, new int[]{0, 0, 0, 1, 2, 6, 17, 120, 500}},
        {9, new int[]{0, 0, 0, 0, 2, 5, 14, 55, 200, 1000}},
        {10, new int[]{0, 0, 0, 0, 1, 4, 8, 24, 100, 500, 1000}},
    };
}