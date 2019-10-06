using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeServer.Events.Query;
using PokeServer.Models.Pokemon;
using PokeServer.Models.PokeServer;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IMediator _mediator = null;
        public PokemonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("name/{name}")]
        public async Task<ActionResult<PokemonResponse>> GetPokemon(string name)
        {
            var pokemonQuery = new GetPokemonQuery()
            {
                Identifier = name
            };

            var pokemon = await _mediator.Send(pokemonQuery);

            if (pokemon == null)
            {
                return NotFound(pokemonQuery.RequestId);
            }

            return Ok(new PokemonResponse()
            {
                Pokemon = pokemon,
                RequestId = pokemonQuery.RequestId
            });
        }

        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("number/{number}")]
        public async Task<ActionResult<PokemonResponse>> GetPokemon(int number)
        {
            var pokemonQuery = new GetPokemonQuery()
            {
                Identifier = number
            };

            var pokemon = await _mediator.Send(pokemonQuery);

            if(pokemon==null)
            {
                return NotFound(pokemonQuery.RequestId);
            }

            return Ok(new PokemonResponse()
            {
                Pokemon = pokemon,
                RequestId = pokemonQuery.RequestId
            });
        }
    }
}
