using System.Linq;
namespace Datalayer;

public class DatabaseCalls : DBInterface
{
    private readonly WebSiteDBContext _context;
    
    public DatabaseCalls(WebSiteDBContext context)
    {
        _context = context;
    }

    public async Task<User> createUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<Boolean> checkIfUserExists(string username)
    {
        Console.WriteLine("checking if username exists");
        return await _context.Users.AnyAsync(tuser => tuser.username == username);
    }

    public async Task<User> loginUser(string username, string password)
    {
        User temp = await fetchUser(username, password);
        if(temp.password != "" || temp.password != null)
        {
            // returns user if username is found
            return temp;
        }
        temp = new User();
        temp.username = await checkIfUserExists(username) ? username : username;
        //temp = new User();
        //temp.username = username;
        return temp;//await checkIfUserExists(username) is true ? temp : new User();
    }

/*
    public async Task<string> checkIfUsernameExists(string toCheck)
    {
        // should be either email address or username
        string username = 
    }
*/
    public async Task<User> updateUser(User user)
    {
        // should 1 email be tied to a user???
        User temporaryUser = await _context.Users.FirstOrDefaultAsync(temp => temp.username == user.username) ?? new User();
        temporaryUser.firstname = user.firstname;
        temporaryUser.lastname = user.lastname;
        temporaryUser.bio = user.bio;
        temporaryUser.password = user.password;
        await _context.SaveChangesAsync();
        return temporaryUser;
    }

    public async Task deleteUser(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User> fetchUser(string username, string password)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.username == username && user.password == password) ?? new User();
    }

    public async Task resetPassword(string email, string username)
    {
        await _context.SaveChangesAsync();
    }
    
    public async Task<List<Pokemon>> getRandomPokemonList(int amount)
    {
        Random rand = new Random();
        int count = _context.Pokemon.Count(), toSkip = rand.Next(1,count);
        /*
        List<Pokemon> temp = await _context.Pokemon.Skip(toSkip).Take(1).ToListAsync();
        amount--;
        if(amount > 0 )
        {
            toSkip = rand.Next(0,count);
            temp.Add(_context.Pokemon.Skip(toSkip).Take(1).First());
            amount--;
        }*/
        List<Pokemon> temp = new List<Pokemon>();
        while(amount > 0)
        {
            toSkip = rand.Next(0, count);
            temp.Add(await _context.Pokemon.OrderBy(p=>p.id).Skip(toSkip).Take(1).FirstAsync());
            amount--;
        }
        return temp;
        /*List<Pokemon> temp = new List<Pokemon>();

        while(amount > 0)
        {
            toSkip = rand.Next(1, count);
            temp.Add(_context.Pokemon.Skip(toSkip).Take(1).First());
            amount--;
        }
        return await _context.Pokemon.OrderBy(e=>EF.Functions.Random()).Take(amount).ToListAsync().ConfigureAwait(true);
        */
        //toSkip = rand.Next(1,count);
        //return await _context.Pokemon.Skip(toSkip).Take(amount).ToListAsync();
        //return await _context.Pokemon.AsNoTracking().Take(amount).ToListAsync().ConfigureAwait(false);
    }

    public async Task createPokemon(Pokemon pkmn)
    {
        _context.Pokemon.Add(pkmn);
        await _context.SaveChangesAsync();
    }

    public async Task deletePokemon(Pokemon pkmn)
    {
        _context.Pokemon.Remove(pkmn);
        await _context.SaveChangesAsync();
    }
    public async Task updatePokemonEntity(Pokemon pokemon)
    {
        Pokemon dummy = await _context.Pokemon.FirstOrDefaultAsync(pkmn => pkmn.id == pokemon.id) ?? new Pokemon();
        dummy.pokemonId = pokemon.pokemonId;
        dummy.name = pokemon.name;
        dummy.hp = pokemon.hp;
        dummy.atk = pokemon.atk;
        dummy.def = pokemon.def;
        dummy.spatk = pokemon.spatk;
        dummy.spdef = pokemon.spdef;
        dummy.spd = pokemon.spd;
        dummy.type1 = pokemon.type1;
        dummy.type2 = pokemon.type2;
        dummy.ability = pokemon.ability;
        await _context.SaveChangesAsync();
    }
    
    public async Task<Match> getMatchAsync(int uid, int oid)
    {
        Match match = await _context.Matches.FirstOrDefaultAsync(m=>m.opponentID == oid && m.userId == uid) ?? new Match();
        return match;
    }

    public async Task<List<Match>> getMyMatchesAsync(int uid)
    {
        List<Match> temp = await _context.Matches.Where(m=> m.userId == uid).ToListAsync();
        return temp;
    }

    public async Task<List<Match>> getAllMatchHistoryAsync()
    {
        return await _context.Matches.ToListAsync();
    }

    public async Task<Match> createMatch(int uid, int oid, int defaultResult)
    {
        Match match = new Match(uid,oid, defaultResult);
        _context.Matches.Add(match);
        await _context.SaveChangesAsync();
        return match;
    }

    public async Task deleteMatch(int matchId)
    {
        Match temp = await _context.Matches.FirstOrDefaultAsync(m=>m.id == matchId) ?? new Match();
        _context.Matches.Remove(temp);
        await _context.SaveChangesAsync();
    }

    public async Task matchResult(int matchId, int result)
    {
        Match match = await _context.Matches.FirstOrDefaultAsync(m => m.id == matchId) ?? new Match();
    
        match.matchResult = result;
        await _context.SaveChangesAsync();
    }
    
}
