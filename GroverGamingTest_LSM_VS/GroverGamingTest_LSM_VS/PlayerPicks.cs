public class PlayerPicks
{
    #region Fields, Properties and Constructor --------------------------------
    private int minNumber = GameSettings.minGameNumber;
    private int maxNumber = GameSettings.maxGameNumber;
    private readonly List<int> playerPicksList = new List<int>();
    public readonly int bet;
    public readonly int qtyOfPicks;

    public PlayerPicks(int qtyOfPicks, int bet = 1)
    {
        this.qtyOfPicks = qtyOfPicks;
        this.bet = bet;
        GetQuickPicks();
    }
    #endregion

    #region Private Methods ---------------------------------------------------
    private void GetQuickPicks()
    {
        for (int i = 0; i < qtyOfPicks; i++)
        {
            int newPick = GetNewUniquePick();
            playerPicksList.Add(newPick);
        }
    }
    #endregion

    #region Public Methods ----------------------------------------------------
    public int GetNewUniquePick()
    {
        Random random = new Random();
        int newNum;
        do
        {
            newNum = random.Next(minNumber, maxNumber + 1);
        } while (playerPicksList.Contains(newNum));
        playerPicksList.Add(newNum);
        return newNum;
    }
    #endregion

    #region Getters -----------------------------------------------------------
    public List<int> GetPlayerPicks() { return playerPicksList; }
    #endregion
}