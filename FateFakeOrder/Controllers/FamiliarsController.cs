using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FateFakeOrder.Data;
using FateFakeOrder.Model.Models.Familiar;
using FateFakeOrder.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FateFakeOrder.API.Controllers
{
    [Route("api/familiars")]
    [Authorize(AuthenticationSchemes = "Bearer")]

    [ApiController]
    public class FamiliarsController : ControllerBase
    {
        private readonly IFamiliarService _ifam;
        private readonly IMapper _mapper;

        public FamiliarsController(IFamiliarService iFam,IMapper mapper)
        {
            _ifam = iFam;
            _mapper = mapper;
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<FamiliarReadModel>>> GetAll()
        {
            IEnumerable<FamiliarReadModel> familiars =  _mapper.Map<IEnumerable<FamiliarReadModel>>(await _ifam.GetAll());

            return Ok(familiars); //(_iMapper.Map<IEnumerable<MasterCreateModel>>(masters)

        }
        [HttpGet("{id}", Name = "GetFamiliarById")]

        public async Task<ActionResult<Familiar>> GetFamiliarById(int id)
        {
            return Ok(await _ifam.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<Familiar>> SaveFamiliar(FamiliarCreateModel familiarCreateModel)
        {
            var familiarModel = _mapper.Map<Familiar>(familiarCreateModel);
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