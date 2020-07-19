using estagio_brg.Contracts;
using estagio_brg.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace estagio_brg.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class TrilhaController : Controller
    {
        private IRepositoryWrapper _repoWrapper;

        public TrilhaController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        /// <summary>
        /// Retornar lista de trilhas
        /// </summary>
        [HttpGet("[action]")]
        public IActionResult Get()
        {
            var trilhas = _repoWrapper.Trilha.FindAll().Include(c => c.Colaborador).Include(s => s.Habilidade);

            return Ok(trilhas);
        }

        /// <summary>
        /// Retornar trilha filtrada
        /// </summary>
        /// <param name="guid">Id da trilha</param>
        [HttpGet("[action]/{guid}")]
        public IActionResult Get(Guid guid)
        {
            var trilha = _repoWrapper.Trilha.FindById(x => x.IdTrilha == guid);

            if (trilha is null)
                return NotFound();

            return Ok(trilha);
        }


        /// <summary>
        /// Adicionar trilha
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/Trilha/Create
        ///       {
        ///        "Prazo": "25/05/2020",
        ///        "ColaboradorIdColaborar": {
        ///             "IdColaborador": 1
        ///             }
        ///        "HabilidadeIdHabilidade": {
        ///        "IdHabilidade": 1
        ///        }
        ///     }
        ///
        /// </remarks>
        /// <param name="trilha">Objeto trilha</param>
        [HttpPost("[action]")]
        public IActionResult Create([FromBody] Trilha trilha)
        {
            _repoWrapper.Trilha.Create(trilha);
            _repoWrapper.Save();

            return Ok("Criado com sucesso");
        }

        /// <summary>
        /// Atualizar trilha
        /// </summary>
        ///  <remarks>
        /// Sample request:
        ///
        ///     POST api/Trilha/Update/1
        ///     {
        ///        "Prazo": "25/08/2020",
        ///        "ColaboradorIdColaborar": {
        ///             "IdColaborador": 1
        ///             }
        ///             "HabilidadeIdHabilidade": {
        ///             "IdHabilidade": 1
        ///             }
        ///     }
        ///
        /// </remarks>
        /// <param name="entity">Objeto trilha contendo as mudanças</param>
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Trilha entity)
        {
            var trilha = _repoWrapper.Trilha.FindById(s => s.IdTrilha == entity.IdTrilha);
            if (trilha is null)
                return NotFound();

            _repoWrapper.Trilha.Update(entity);
            _repoWrapper.Save();

            return Ok("Atualizado com sucesso");
        }

        /// <summary>
        /// Deletar trilha
        /// </summary>
        /// <param name="IdTrilha">Objeto do entity a ser deletado</param>
        [HttpDelete("[action]")]
        public IActionResult Delete(Guid IdTrilha)
        {
            var trilha = _repoWrapper.Trilha.FindById(s => s.IdTrilha == IdTrilha).FirstOrDefault();
            if (trilha is null)
                return NotFound();

            _repoWrapper.Trilha.Delete(trilha);
            _repoWrapper.Save();

            return Ok("Deletado com sucesso");
        }
    }
}
