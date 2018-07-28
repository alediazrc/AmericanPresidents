using System;
using System.Collections.Generic;
using System.Globalization;
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
            List<Presidents> _presidentsList = new List<Presidents>();
            List<CustomPresident> _customPresidents = new List<CustomPresident>();
            CustomPresident _president = new CustomPresident();
            try
            {
                _presidentsList = _repository.context.Presidents.OrderBy(deseced => deseced.DeathDay).ToList();
                foreach (Presidents _item in _presidentsList)
                {
                    _president.Birthday = _item.Birthday;
                    _president.Birthplace = _item.Birthplace;
                    _president.DeathDay = _item.DeathDay;
                    _president.DeathPlace = _item.DeathPlace;
                    _president.President = _item.President;
                    _president.Id = _item.Id;
                    _president.ShortBirthDate = _item.Birthday.ToShortDateString();
                    _president.ShortDiedDate = _item.DeathDay.ToShortDateString();
                    _customPresidents.Add(_president);
                }
                return Ok(_customPresidents);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            } 
           
        }

        [HttpGet("BirthDayByAscending")]
        public ActionResult<IEnumerable<Presidents>> GetBirthDayByAscending()
        {
            List<Presidents> _presidentsList = new List<Presidents>();
            List<CustomPresident> _customPresidents = new List<CustomPresident>();
            CustomPresident _president = new CustomPresident();
            try
            {
                _presidentsList = _repository.context.Presidents.OrderBy(deseced => deseced.Birthday).ToList();
                foreach (Presidents _item in _presidentsList)
                {
                    _president.Birthday = _item.Birthday;
                    _president.Birthplace = _item.Birthplace;
                    _president.DeathDay = _item.DeathDay;
                    _president.DeathPlace = _item.DeathPlace;
                    _president.President = _item.President;
                    _president.Id = _item.Id;
                    _president.ShortBirthDate = _item.Birthday.ToShortDateString();
                    _president.ShortDiedDate = _item.DeathDay.ToShortDateString();
                    _customPresidents.Add(_president);
                }
                return Ok(_customPresidents);
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
            List<Presidents> _presidentsList = new List<Presidents>();
            List<CustomPresident> _customPresidents = new List<CustomPresident>();
            CustomPresident _president = new CustomPresident();

            try
            {
                _presidentsList = _repository.context.Presidents.OrderByDescending(deseced => deseced.DeathDay).ToList();
                foreach (Presidents _item in _presidentsList)
                {
                    _president.Birthday = _item.Birthday;
                    _president.Birthplace = _item.Birthplace;
                    _president.DeathDay = _item.DeathDay;
                    _president.DeathPlace = _item.DeathPlace;
                    _president.President = _item.President;
                    _president.Id = _item.Id;
                    _president.ShortBirthDate = _item.Birthday.ToShortDateString();
                    _president.ShortDiedDate = _item.DeathDay.ToShortDateString();
                    _customPresidents.Add(_president);
                }
                return Ok(_customPresidents);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        // GET api/values/5
        [HttpGet("BirthDayByDecending")]
        public ActionResult<IEnumerable<Presidents>> GetBirthDayByDecending()
        {
            List<Presidents> _presidentsList = new List<Presidents>();
            List<CustomPresident> _customPresidents = new List<CustomPresident>();
            CustomPresident _president = new CustomPresident();
            try
            {
                
                _presidentsList = _repository.context.Presidents.OrderByDescending(president => president.Birthday).ToList();
               
                return Ok(_presidentsList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        // GET api/values/5
        [HttpGet("PresidentsByName")]
        public ActionResult<IEnumerable<Presidents>> GetPresidentsByName(string name)
        {
            try
            {
                var _presidentsList = _repository.context.Presidents.Where(president => president.President.Contains(name.ToLower())).ToList();
                return Ok(_presidentsList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
