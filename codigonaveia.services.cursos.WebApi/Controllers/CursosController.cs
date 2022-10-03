using codigonaveia.services.cursos.Domain.Entities;
using codigonaveia.services.cursos.Repositories.Interface;
using codigonaveia.services.cursos.Repositories.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace codigonaveia.services.cursos.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly ICursosRepository _cursosRepository;

        public CursosController(ICursosRepository cursosRepository)
        {
            _cursosRepository = cursosRepository;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(EntidadeCursos entidadeCursos)
        {
            if(entidadeCursos == null) 
            {
                return BadRequest($"{entidadeCursos}não pode ser nulo");
            }   
            await   _cursosRepository.insert(entidadeCursos);
            return Ok("Curso Registrado com sucessso!");
        }

        [HttpGet("ObterTodosCursos")]
        public async Task<IActionResult> ObterTodosCursos()
        {
            var resultado = await _cursosRepository.getall();
            return Ok(resultado.ToList());
        }

        [HttpGet("ObterCursoPorId/{Id}")]
        public async Task<IActionResult> ObterCursoPorId(int Id)
        {
            var resultado = await _cursosRepository.GetById(Id);
            if (resultado == null)
            {
                return NotFound($"{Id}, não encontrado");
            }
            return Ok(resultado);
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var resultado = await _cursosRepository.GetById(Id);
            if (resultado == null)
            {
                return NotFound($"{Id}, não encontrado");
            }
            await _cursosRepository.delete(Id);
            return Ok(resultado);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id , EntidadeCursos entidadeCursos)
        {
            if (Id != entidadeCursos.Id)
            {
                return BadRequest($"O Código {Id} não encontrado" );
            }
            try
            {
                await _cursosRepository.update(Id, entidadeCursos);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.Message);
            }
            return Ok("Dados atualizados com sucesso");
        }

    }
}
