using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class MatchController : ControllerBase
{
    private readonly DBInterface _db;

    public MatchController(DBInterface db)
    {
        _db = db;
    }

    [HttpPost("createMatch/{userId}/{opponentId}/{defaultResult}")]
    public async Task<Match> createMatch(int userId, int opponentId, int defaultResult)
    {
        return await _db.createMatch(userId, opponentId, defaultResult);
    }

    [HttpGet("myMatches/{userId}")]
    public async Task<List<Match>> getMyMatchesAsync(int userId)
    {
        return await _db.getMyMatchesAsync(userId);
    }

    [HttpGet("allMatches")]
    public async Task<List<Match>> getAllMatchHistoryAsync()
    {
        return await _db.getAllMatchHistoryAsync();
    }

    [HttpGet("getMatchAsync/{userId}/{opponentId}")]
    public async Task<Match> getMatchAsync(int userId, int opponentId)
    {
        return await _db.getMatchAsync(userId, opponentId);
    }

    [HttpPut("updateMatch/{matchId}/{result}")]
    public async Task updateMatch(int matchId, int result)
    {
        await _db.matchResult(matchId, result);
    }

    [HttpDelete("deleteMatch/{matchId}")]
    public async Task deleteMatch(int matchId)
    {
        await _db.deleteMatch(matchId);
    }

}