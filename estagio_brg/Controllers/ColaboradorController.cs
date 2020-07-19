using estagio_brg.Contracts;
using estagio_brg.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace estagio_brg.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ColaboradorController : Controller
    {
        private IRepositoryWrapper _repoWrapper;

        public ColaboradorController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        /// <summary>
        /// Retornar lista de colaboradores
        /// </summary>
        [HttpGet("[action]")]
        public IActionResult Get()
        {
            var colaboradores = _repoWrapper.Colaborador.FindAll();

            return Ok(colaboradores);
        }

        /// <summary>
        /// Retornar colaborador filtrado
        /// </summary>
        /// <param name="guid">Id do colaborador</param>
        [HttpGet("[action]/{guid}")]
        public IActionResult Get(Guid guid)
        {
            var colaborador = _repoWrapper.Colaborador.FindById(x => x.IdColaborador == guid);

            if (colaborador is null)
                return NotFound();

            return Ok(colaborador);
        }


        /// <summary>
        /// Adicionar colaborador
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/Colaborador/Create
        ///     {
        ///        "Cargo": "Analista de treinamento e capacitação",
        ///        "Departamento": "RH",
        ///     }
        ///
        /// </remarks>
        /// <param name="entity">Objeto colaborador</param>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>  
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody]Colaborador entity)
        {
            _repoWrapper.Colaborador.Create(entity);
            _repoWrapper.Save();

            return Ok("Criado com sucesso");
        }

        /// <summary>
        /// Atualizar colaborador
        /// </summary>
        ///  <remarks>
        /// Sample request:
        ///
        ///     POST api/Colaborador/Update/
        ///     {
        ///        "IdColaborador": "16eb3b70-2512-45df-8081-25474341460e",
        ///        "Cargo": "Gestor de recrutamento e seleção",
        ///        "Departamento": "RH",
        ///         }
        ///     }
        ///
        /// </remarks>
        /// <param name="entity">Objeto colaborador contendo as mudanças</param>
        [HttpPut("[action]")]
        public IActionResult Update([FromBody] Colaborador entity)
        {
            var colaborador = _repoWrapper.Colaborador.FindById(s => s.IdColaborador == entity.IdColaborador);
            if (colaborador is null)
                return NotFound();

            _repoWrapper.Colaborador.Update(entity);
            _repoWrapper.Save();

            return Ok("Atualizado com sucesso");
        }

        /// <summary>
        /// Deletar colaborador
        /// </summary>
        /// <param name="IdColaborador">Id do colaborador a ser deletado</param>
        [HttpDelete("[action]")]
        public IActionResult Delete(Guid IdColaborador)
        {
            var colaborador = _repoWrapper.Colaborador.FindById(s => s.IdColaborador == IdColaborador).FirstOrDefault();
            if (colaborador is null)
                return NotFound();

            _repoWrapper.Colaborador.Delete(colaborador);
            _repoWrapper.Save();

            return Ok("Deletado com sucesso");
        }
    }
}
