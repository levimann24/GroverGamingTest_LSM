internal class Program
{
    private static void Main(string[] args)
    {
        // List of all stats for each game configuration.
        List<GameStatistics> gameStatsList = new List<GameStatistics>();
        int numberOfGamesPerPick = 100000;

        GameStatistics.DisplayStatHeader();

        #region Main Loop -----------------------------------------------------
        for (int i = GameSettings.lowestNumberOfPicks; i <= GameSettings.highestNumberOfPicks; i++)
        {
            var newStats = new GameStatistics(i);
            for (int j = 0; j < numberOfGamesPerPick; j++)
            {
                var newGamePlayerPicks = new PlayerPicks(i);
                var newGame = new Game(newGamePlayerPicks);
                newGame.PlayGame();
                newStats.AddGameResults(newGame);
                newStats.DisplaySingleRowStats();
            }
            Console.WriteLine();
            gameStatsList.Add(newStats);
        }
        #endregion

        Console.WriteLine();
        Console.WriteLine("Press Enter to close..... ");
        Console.Read();

    }
}