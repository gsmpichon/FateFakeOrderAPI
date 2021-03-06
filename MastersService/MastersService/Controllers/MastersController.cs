﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FateFakeOrder.Data;
using FateFakeOrder.Model.Models;
using MastersService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FateFakeOrder.API.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/masters")]
    [ApiController]

  public class MastersController : ControllerBase
    {
        private readonly IMasterService _iMaster;

        public MastersController(IMasterService iMaster)
        {
            _iMaster = iMaster;
        }

     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Master>>> GetAll()
        {
            IEnumerable<Master> masters = await _iMaster.GetAll();

            return Ok(masters); 

        }
        
        [HttpGet("{id}", Name = "GetMasterById")]
        public async Task<ActionResult<Master>> GetMasterById(int id)
        {
            return Ok(await _iMaster.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<Master>> SaveMaster(Master masterCreate)
        {
            Master masterModel = masterCreate; // change into mapped model

            await _iMaster.Save(masterModel);

            
            return CreatedAtRoute(nameof(GetMasterById), new { Id = masterModel.Id }, masterModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMaster(int id)
        {
            await _iMaster.Delete(id);
            return NoContent();
        }

        #region Research More on Patch
        //[HttpPatch("{id}")]
        //public async Task<ActionResult> UpdateMaster(int id, JsonPatchDocument<MasterUpdateModel> patchMaster)
        //{
        //    var masterFromDb = await _iMaster.Get(id);

        //    if(masterFromDb == null)
        //    {
        //        return NotFound();
        //    }

        //    var masterToUpdate = _iMapper.Map<MasterUpdateModel>(masterFromDb); // change to mapper
        //    try
        //    {
        //        patchMaster.ApplyTo(masterToUpdate, ModelState);

        //        if (!TryValidateModel(masterToUpdate))
        //        {
        //            return ValidationProblem(ModelState);
        //        }
        //    }
        //    catch(Exception ex)
        //    {

        //    }



        //    await _iMaster.Update();

        //    return NoContent();

        //}
        #endregion
    }
}