using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamiliarsService.Interfaces;
using FateFakeOrder.Data;
using FateFakeOrder.Model.Models.Familiar;
using FateFakeOrder.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamiliarsService.Controllers
{
    [Route("api/familiars")]
    [ApiController]
    public class FamiliarsController : ControllerBase
    {
        private readonly IFamiliarService _ifam;

        public FamiliarsController(IFamiliarService iFam)
        {
            _ifam = iFam;
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Familiar>>> GetAll()
        {
            IEnumerable<Familiar> familiars = await _ifam.GetAll();

            return Ok(familiars); //(_iMapper.Map<IEnumerable<MasterCreateModel>>(masters)

        }
        [HttpGet("{id}", Name = "GetFamiliarById")]

        public async Task<ActionResult<Familiar>> GetFamiliarById(int id)
        {
            return Ok(await _ifam.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<Familiar>> SaveFamiliar(Familiar familiarCreateModel)
        {
            var familiarModel = familiarCreateModel;
            await _ifam.Save(familiarModel);

            return CreatedAtRoute(nameof(GetFamiliarById), new { Id = familiarModel.Id }, familiarModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFamiliar(int id)
        {
            await _ifam.Delete(id);
            return NoContent();
        }

    }
}