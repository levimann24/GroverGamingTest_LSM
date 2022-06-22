public class Game
{
    #region Fields, Properties and Constructor --------------------------------
    // Game Props
    int minGameNum = GameSettings.minGameNumber;
    int maxGameNum = GameSettings.maxGameNumber;
    int numberOfHits = 0;
    bool hitOnfirstNumber = false;
    int payout = 0;
    List<int> gamePickedNumbers = new List<int>();

    // Player Props
    public readonly PlayerPicks playerPicks;

    public Game(PlayerPicks playerPicks)
    {
        this.playerPicks = playerPicks;
    }
    #endregion

    #region Private Methods ---------------------------------------------------
    private int GetNewUniqueGamePick()
    {
        Random random = new Random(20);
        int newGameNum;
        do
        {
            newGameNum = random.Next(minGameNum, maxGameNum + 1);
        } while (gamePickedNumbers.Contains(newGameNum));
        gamePickedNumbers.Add(newGameNum);
        return newGameNum;
    }
    private void CalculateWinnings()
    {
        if (PayTable.payout.ContainsKey(playerPicks.qtyOfPicks))
        {
            int[] pickPayout = PayTable.payout[playerPicks.qtyOfPicks];
            if (numberOfHits >= 0 && numberOfHits < pickPayout.Count())
            {
                int payoutMultiple = pickPayout[numberOfHits];
                // Check if bonus was achieved.
                if (hitOnfirstNumber) { payoutMultiple *= 4; }
                payout = payoutMultiple * playerPicks.bet;
            }
        }
    }
    #endregion

    #region Public Methods ----------------------------------------------------
    public void PlayGame()
    {
        for (int i = 0; i < 20; i++)
        {
            int newGameNum = GetNewUniqueGamePick();
            if (playerPicks.GetPlayerPicks().Contains(newGameNum))
            {
                if (i == 0) { hitOnfirstNumber = true; }
                numberOfHits++;
            }
            // Console.WriteLine(newGameNum);
        }
        // Console.WriteLine("Number of matches: " + numberOfHits);
        CalculateWinnings();
    }
    #endregion

    #region Getters -----------------------------------------------------------
    public int GetGamePayout() { return payout; }
    public int GetPlayerBet() { return playerPicks.bet; }
    public bool GetBonusPayoutResult() { return hitOnfirstNumber; }
    public int GetNumberOfHits() { return numberOfHits; }
    #endregion
}





