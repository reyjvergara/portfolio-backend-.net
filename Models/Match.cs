namespace Models;

public class Match
{
    public int id {get; set;} = 0;
    public int userId {get; set;} = 0;
    public int opponentID {get; set;} = 0;
    // 0 is loss, 2 is win, 1 is tiel
    public int matchResult {get; set;} = 0;

    public Match(int userID, int opponentID, int result)
    {
        this.userId = userID;
        this.opponentID = opponentID;
        this.matchResult = result;
    }

    public Match() {}
}