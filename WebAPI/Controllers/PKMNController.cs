using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonController : ControllerBase
{
    private readonly DBInterface _db;

    public PokemonController(DBInterface db)
    {
        _db = db;
    }

    [HttpGet("getRandomPokemonList/{amount}")]
    public async Task<List<Pokemon>> getRandomPokemonList(int amount)
    {
        return await _db.getRandomPokemonList(amount);
    }

    [HttpPost("createPokemon/{pokemon}")]
    public async Task createPokemon(Pokemon pokemon)
    {
        await _db.createPokemon(pokemon);
    }

    [HttpPut("updatePokemon/{pokemon}")]
    public async Task updatePokemon(Pokemon pokemon)
    {
        await _db.updatePokemonEntity(pokemon);
    }

    [HttpDelete("deletePokemon/{pokemon}")]
    public async Task deletePokemon(Pokemon pokemon)
    {
        await _db.deletePokemon(pokemon);
    }
    
}
