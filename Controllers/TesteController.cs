using Microsoft.AspNetCore.Mvc;

namespace PrimeiraApiCli.Controllers;

[ApiController]
[Route("api/demo")]
public class TesteController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new Produto { Id = 1, Nome = "Teste" });
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Produto), StatusCodes.Status404NotFound)]
    public IActionResult Get(int id)
    {
        return Ok(new Produto { Id = 1, Nome = "Teste" });
    }

    [HttpPost]
    [ProducesResponseType(typeof(Produto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(Produto), StatusCodes.Status400BadRequest)]
    public IActionResult Post(Produto produto)
    {
        return CreatedAtAction("Get", new { id = produto.Id }, produto);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(Produto), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Produto), StatusCodes.Status400BadRequest)]
    public IActionResult Put(int id, Produto produto)
    {
        if (id != produto.Id) return BadRequest();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Produto), StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}