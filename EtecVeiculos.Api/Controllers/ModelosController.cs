using EtecVeiculos.Api.Data;
using EtecVeiculos.Api.DTOs;
using EtecVeiculos.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EtecVeiculos.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ModelosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ModelosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Modelo>>> Get()
    {
        var tipos = await _context.Modelo.ToListAsync();
        return Ok(tipos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Modelo>> Get(int id)
    {
        var tipo = await _context.Modelo.FindAsync(id);
        if (tipo == null)
            return NotFound("Modelo não localizado!");
        return Ok(tipo);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Create(ModeloVM modeloVM)
    {
         if (ModelState.IsValid)
         {            
           Modelo modelo = new(){
                Nome = modeloVM.Nome
            };
            await _context.AddAsync(modelo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new {id = modelo.Id});
         }
         return BadRequest("Verifique os dados informados!");
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Edit(int id, Modelo modelo)
    {
        if (ModelState.IsValid)
        {
            try
            {
                if(!_context.Modelo.Any(q => q.Id == id))
                    return NotFound("Modelo não encontrado!");
                if (id != modelo.Id)
                    return BadRequest("Verifique os dados informados");

                _context.Entry(modelo).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um problema: {ex.Message}");
            }
        }
        return BadRequest("Verifique os dados informados!");
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var modelo = await _context.Modelo
                .FirstOrDefaultAsync(q => q.Id == id);
            if (modelo == null)
                return NotFound("Modelo não encontrado");

                _context.Remove(modelo);
                await _context.SaveChangesAsync();
            
                return NoContent();
        }
        catch (Exception ex)
        {
             return BadRequest($"Ocorreu um problema: {ex.Message}");
        }
    }
}
