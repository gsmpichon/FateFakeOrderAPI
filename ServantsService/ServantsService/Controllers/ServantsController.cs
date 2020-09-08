using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FateFakeOrder.Data;
using FateFakeOrder.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servants.Interfaces;

namespace ServantsService.Controllers
{
    [Route("api/servants")]
    [ApiController]
    public class ServantsController : Controller
    {
        private readonly IServantService _iServant;
        //private readonly IMapper _iMapper;

        public ServantsController(IServantService iServant)
        {
            _iServant = iServant;
            //_iMapper = mapper;
        }

        [HttpGet("{id}", Name = "GetServantById")]
        public async Task<ActionResult<Servant>> GetServantById(int id)
        {
            return Ok(await _iServant.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<Servant>> SaveServant(Servant servant)
        {
            var servantModel = servant;
            await _iServant.Save(servantModel);

            return CreatedAtRoute(nameof(GetServantById), new { Id = servantModel.Id }, servantModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteServant(int id)
        {
            await _iServant.Remove(id);
            return NoContent();
        }
    }
}