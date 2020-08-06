using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TissiniModels;
using TissiniunitOfWork;

namespace TissiniWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class SupplierController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SupplierController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Supplier.GetById(id));
        }

        [HttpGet]
        [Route("GetPaginatedSupplier/{page:int}/{rows:int}")]
        IActionResult GetPaginatedSupplier(int page, int rows)
        {
            return Ok(_unitOfWork.Supplier.SupplierPagedList(page, rows));
        }

        [HttpPost]
        public IActionResult Post([FromBody]Supplier supplier)
        {
            if (ModelState.IsValid) return BadRequest();
            return Ok(_unitOfWork.Supplier.Insert(supplier));
        }

        [HttpPut]
        public IActionResult Put([FromBody]Supplier supplier)
        {
            if (ModelState.IsValid && _unitOfWork.Supplier.Update(supplier))
            {
                return Ok(new { Message = "The supplier is updated" });
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]Supplier supplier)
        {
            if (supplier.Id > 0)
            {
                return Ok(_unitOfWork.Supplier.Delete(supplier));
            }
            return BadRequest();
        }
    }
}