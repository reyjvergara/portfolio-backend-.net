namespace Datalayer;
public interface DBInterface
{
    Task<User> createUser(User user);
    Task<User> loginUser(string username, string password);
    Task<Boolean> checkIfUserExists(string username);
    Task<User> updateUser(User user);
    Task deleteUser(User user);
    Task<User> fetchUser(string username, string password);
    Task resetPassword(string email, string username);

    Task<List<Pokemon>> getRandomPokemonList(int amount);
    Task createPokemon(Pokemon pkmn);
    Task deletePokemon(Pokemon pkmn);
    Task updatePokemonEntity(Pokemon pkmn);
    
    Task<Match> createMatch(int userId, int opponentId, int defaultResult);
    Task matchResult(int matchId, int result);
    Task deleteMatch(int matchId);
    Task<Match> getMatchAsync(int userId, int opponentId);
    Task<List<Match>> getMyMatchesAsync(int userId);
    Task<List<Match>> getAllMatchHistoryAsync();
    
    //Task createTempPassword()
    //Task<List<
}
