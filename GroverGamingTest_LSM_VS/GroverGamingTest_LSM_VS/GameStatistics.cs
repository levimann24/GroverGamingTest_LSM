public class GameStatistics
{
    #region Fields, Properties and Constructor --------------------------------
    // Identifier
    public readonly int numberOfPicks;

    // History
    List<Game> gameHistoryList = new List<Game>();

    // Changing Props
    int moneyIn = 0;
    int moneyOut = 0;
    int bonusCount = 0;
    int numberOfGames = 0;
    int numberOfGameWins = 0;

    // Running Statistics
    double hitRatio = 0;
    double RTP = 0;
    double bonusFrequency = 0;


    public GameStatistics(int numberOfPicks)
    {
        this.numberOfPicks = numberOfPicks;
    }
    #endregion

    #region Private Methods ---------------------------------------------------
    private void CalculateStatistics()
    {
        RTP = moneyOut / (double)moneyIn * 100;
        hitRatio = numberOfGameWins / (double)numberOfGames * 100;
        bonusFrequency = bonusCount / (double)numberOfGames * 100;
    }

    // Makes sure the table displays nicely.
    private string DisplayFormat(string value, int totalSpace)
    {
        int spacesAdded = 0;
        string newValue = value;
        while (newValue.Count() < totalSpace)
        {
            if (spacesAdded % 2 == 0) { newValue = newValue + " "; }
            else { newValue = " " + newValue; }
            spacesAdded++;
        }
        return newValue;
    }
    #endregion

    #region Public Methods ----------------------------------------------------
    // Displays current values.
    public void DisplaySingleRowStats()
    {
        Console.Write($"\r|{DisplayFormat($"{numberOfPicks}", 9)}"
        + $"|{DisplayFormat($"${moneyIn.ToString()}", 11)}"
        + $"|{DisplayFormat($"${moneyOut.ToString()}", 12)}"
        + $"|{DisplayFormat($"{hitRatio.ToString("0.00")}%", 13)}"
        + $"|{DisplayFormat($"{RTP.ToString("0.00")}%", 11)}"
        + $"|{DisplayFormat($"{bonusFrequency.ToString("0.00")}%", 17)}|");
    }

    // Uses all of the data from the specific game and re-calculates the parameters.
    // Also stores the game in the history list if it needs to be referenced later.
    public void AddGameResults(Game game)
    {
        gameHistoryList.Add(game);
        moneyIn += game.GetPlayerBet();
        moneyOut += game.GetGamePayout();
        if (game.GetGamePayout() > 0) { numberOfGameWins++; }
        if (game.GetBonusPayoutResult()) { bonusCount++; }
        numberOfGames++;
        CalculateStatistics();
    }
    #endregion

    #region Static Methods ----------------------------------------------------
    public static void DisplayStatHeader()
    {
        Console.WriteLine();
        Console.WriteLine($"                                  GAME STATS                                    ");
        Console.WriteLine($"--------------------------------------------------------------------------------");
        Console.WriteLine($"|  Picks  |  MoneyIn  |  MoneyOut  |  Hit Ratio  |    RTP    | Bonus Frequency |");
        Console.WriteLine($"|---------|-----------|------------|-------------|-----------|-----------------|");
        // Console.WriteLine($"|    9    |     11    |      12    |      13     |     11    |        17       |");
    }
    #endregion
}