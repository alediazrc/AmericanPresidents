using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
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

        [HttpGet("DeceasedByAscending")]
        public ActionResult<IEnumerable<Presidents>> GetByAscending()
        {
            List<Presidents> _presidentsList = new List<Presidents>();
            List<Presidents> _alivePresidents = new List<Presidents>();
            List<CustomPresident> _customPresidents = new List<CustomPresident>();
            CustomPresident _president = new CustomPresident();
            try
            {
                _presidentsList = _repository.context.Presidents.Where(deseced => deseced.DeathPlace != "" || deseced.Birthday.Year < 1900).OrderBy(death => death.DeathDay).ToList();
                _alivePresidents = _repository.context.Presidents.Where(deseced => deseced.DeathPlace == "" && deseced.Birthday.Year > 1900).OrderBy(birth => birth.Birthday).ToList();
                _presidentsList.AddRange(_alivePresidents); foreach (Presidents _item in _presidentsList)
                {
                    if (_item.DeathPlace != "" && _item.DeathPlace!=null)
                    {
                        _customPresidents.Add(new CustomPresident()
                        {


                            Birthday = _item.Birthday,
                            Birthplace = _item.Birthplace,
                            DeathDay = _item.DeathDay,
                            DeathPlace = _item.DeathPlace,
                            President = _item.President,
                            Id = _item.Id,
                            ShortBirthDate = _item.Birthday.ToString("MM/dd/yyyy"),
                            ShortDiedDate = _item.DeathDay.ToString("MM/dd/yyyy")

                        });
                    }
                    else
                    {
                        _customPresidents.Add(new CustomPresident()
                        {
                            Birthday = _item.Birthday,
                            Birthplace = _item.Birthplace,
                            President = _item.President,
                            DeathDay = null,
                            DeathPlace = null,
                            Id = _item.Id,
                            ShortBirthDate = _item.Birthday.ToString("MM/dd/yyyy"),
                            ShortDiedDate = null
                        });
                    }
                    
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
                _presidentsList = _repository.context.Presidents.OrderBy(birth => birth.Birthday).ToList();
                foreach (Presidents _item in _presidentsList)
                {
                    if (_item.DeathPlace != "" && _item.DeathPlace != null)
                    {
                        _customPresidents.Add(new CustomPresident()
                        {


                            Birthday = _item.Birthday,
                            Birthplace = _item.Birthplace,
                            DeathDay = _item.DeathDay,
                            DeathPlace = _item.DeathPlace,
                            President = _item.President,
                            Id = _item.Id,
                            ShortBirthDate = _item.Birthday.ToString("MM/dd/yyyy"),
                            ShortDiedDate = _item.DeathDay.ToString("MM/dd/yyyy")

                        });
                    }
                    else
                    {
                        _customPresidents.Add(new CustomPresident()
                        {
                            Birthday = _item.Birthday,
                            Birthplace = _item.Birthplace,
                            President = _item.President,
                            DeathDay = null,
                            DeathPlace = null,
                            Id = _item.Id,
                            ShortBirthDate = _item.Birthday.ToString("MM/dd/yyyy"),
                            ShortDiedDate = null
                        });
                    }

                }
                return Ok(_customPresidents);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpGet("DeceasedByDecending")]
        public ActionResult<IEnumerable<Presidents>> GetByDecending()
        {
            List<Presidents> _presidentsList = new List<Presidents>();
            List<Presidents> _alivePresidents = new List<Presidents>();
            List<CustomPresident> _customPresidents = new List<CustomPresident>();
            CustomPresident _president = new CustomPresident();
            try
            {
                _presidentsList = _repository.context.Presidents.Where(deseced => deseced.DeathPlace != "" || deseced.Birthday.Year < 1900).OrderByDescending(death => death.DeathDay).ToList();
                _alivePresidents = _repository.context.Presidents.Where(deseced => deseced.DeathPlace == "" && deseced.Birthday.Year > 1900).OrderBy(birth => birth.Birthday).ToList();
                _presidentsList.AddRange(_alivePresidents);
                foreach (Presidents _item in _presidentsList)
                {
                    if (_item.DeathPlace != "" && _item.DeathPlace != null)
                    {
                        _customPresidents.Add(new CustomPresident()
                        {
                            Birthday = _item.Birthday,
                            Birthplace = _item.Birthplace,
                            DeathDay = _item.DeathDay,
                            DeathPlace = _item.DeathPlace,
                            President = _item.President,
                            Id = _item.Id,
                            ShortBirthDate = _item.Birthday.ToString("MM/dd/yyyy"),
                            ShortDiedDate = _item.DeathDay.ToString("MM/dd/yyyy")
                            
                        });
                    }
                    else
                    {
                        _customPresidents.Add(new CustomPresident()
                        {
                            Birthday = _item.Birthday,
                            Birthplace = _item.Birthplace,
                            President = _item.President,
                            DeathDay = null,
                            DeathPlace = null,
                            Id = _item.Id,
                            ShortBirthDate = _item.Birthday.ToString("MM/dd/yyyy"),
                            ShortDiedDate = null
                        });
                    }

                }
                return Ok(_customPresidents);
            }
            
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpGet("BirthDayByDecending")]
        public ActionResult<IEnumerable<Presidents>> GetBirthDayByDecending()
        {
            List<Presidents> _presidentsList = new List<Presidents>();
            List<CustomPresident> _customPresidents = new List<CustomPresident>();
            CustomPresident _president = new CustomPresident();
            try
            {
                _presidentsList = _repository.context.Presidents.OrderByDescending(birth => birth.Birthday).ToList();
                foreach (Presidents _item in _presidentsList)
                {
                    if (_item.DeathPlace != "" && _item.DeathPlace != null)
                    {
                        _customPresidents.Add(new CustomPresident()
                        {


                            Birthday = _item.Birthday,
                            Birthplace = _item.Birthplace,
                            DeathDay = _item.DeathDay,
                            DeathPlace = _item.DeathPlace,
                            President = _item.President,
                            Id = _item.Id,
                            ShortBirthDate = _item.Birthday.ToString("MM/dd/yyyy"),
                            ShortDiedDate = _item.DeathDay.ToString("MM/dd/yyyy")

                        });
                    }
                    else
                    {
                        _customPresidents.Add(new CustomPresident()
                        {
                            Birthday = _item.Birthday,
                            Birthplace = _item.Birthplace,
                            President = _item.President,
                            DeathDay = null,
                            DeathPlace = null,
                            Id = _item.Id,
                            ShortBirthDate = _item.Birthday.ToString("MM/dd/yyyy"),
                            ShortDiedDate = null
                        });
                    }

                }
                return Ok(_customPresidents);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
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
