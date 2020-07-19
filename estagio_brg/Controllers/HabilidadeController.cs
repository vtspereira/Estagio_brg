using estagio_brg.Contracts;
using estagio_brg.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace estagio_brg.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class HabilidadeController : Controller
    {
        private IRepositoryWrapper _repoWrapper;

        public HabilidadeController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        /// <summary>
        /// Retornar lista de habilidades
        /// </summary>
        [HttpGet("[action]")]
        public IActionResult Get()
        {
            var habilidades = _repoWrapper.Habilidade.FindAll();

            return Ok(habilidades);
        }

        /// <summary>
        /// Retornar habilidade filtrada
        /// </summary>
        /// <param name="guid">Id da habilidade</param>
        [HttpGet("[action]/{guid}")]
        public IActionResult Get(Guid guid)
        {
            var habilidade = _repoWrapper.Habilidade.FindById(x => x.IdHabilidade == guid);

            if (habilidade is null)
                return NotFound();

            return Ok(habilidade);
        }


        /// <summary>
        /// Adicionar habilidade
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/Habilidade/Create
        ///     {
        ///        "Tipo": "Soft Skill",
        ///        "Nome": "Etica",
        ///     }
        ///
        /// </remarks>
        /// <param name="entity">Objeto habilidade</param>
        [HttpPost("[action]")]
        public IActionResult Create([FromBody]Habilidade entity)
        {
            _repoWrapper.Habilidade.Create(entity);
            _repoWrapper.Save();

            return Ok("Criado com sucesso");
        }

        /// <summary>
        /// Atualizar habilidade
        /// </summary>
        ///  <remarks>
        /// Sample request:
        ///
        ///     POST api/Habilidade/Update/1
        ///     {
        ///        "Tipo": "Hard Skill",
        ///        "Departamento": "Graduação",
        ///         }
        ///     }
        ///
        /// </remarks>
        /// <param name="entity">Objeto habilidade contendo as mudanças</param>
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Habilidade entity)
        {
            var habilidade = _repoWrapper.Habilidade.FindById(s => s.IdHabilidade == entity.IdHabilidade);
            if (habilidade is null)
                return NotFound();

            _repoWrapper.Habilidade.Update(entity);
            _repoWrapper.Save();

            return Ok("Atualizado com sucesso");
        }

        /// <summary>
        /// Deletar habilidade
        /// </summary>
        /// <param name="IdHabilidade">Id da habilidade a ser deletado</param>
        [HttpDelete("[action]")]
        public IActionResult Delete(Guid IdHabilidade)
        {
            var habilidade = _repoWrapper.Habilidade.FindById(s => s.IdHabilidade == IdHabilidade).FirstOrDefault();
            if (habilidade is null)
                return NotFound();

            _repoWrapper.Habilidade.Delete(habilidade);
            _repoWrapper.Save();

            return Ok("Deletado com sucesso");
        }
    }
}
