using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndpointApp.Models;
using EndpointApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EndpointApp.Controllers
{
    [Route("api/AmericanPresidents/")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private PresidentsRepository _repository;

        public ValuesController(PresidentsRepository presidentRepository)
        {
            _repository = presidentRepository;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Presidents>> Get()
        {
            try
            {
                return Ok(_repository.context.Presidents.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/values/5
        [HttpGet("DeceasedByAscending")]
        public ActionResult<IEnumerable<Presidents>> GetByAscending()
        {
            try
            {
                var _presidentsList = _repository.context.Presidents.OrderBy(deseced => deseced.DeathDay).ToList();
                
                return Ok(_presidentsList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            } 
           
        }

        // GET api/values/5
        [HttpGet("DeceasedByDecending")]
        public ActionResult<IEnumerable<Presidents>> GetByDecending()
        {
            try
            {
                var _presidentsList = _repository.context.Presidents.OrderByDescending(deseced => deseced.DeathDay).ToList();
                return Ok(_presidentsList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
