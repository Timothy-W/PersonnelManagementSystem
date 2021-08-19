using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonnelMgtBackend.DataAccess.Repository.IRepository;
using PersonnelMgtBackend.Models;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace PersonnelMgtBackend.Controllers
{
    [ApiController]
    //[EnableCors("VueCorsPolicy")]
    [Route("api/person")] // translate top "api/person/  ie drops "Controller" from "PersonController"
    public class PersonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        //[EnableCors("VueCorsPolicy")]
        public async Task<ActionResult> GetAllPersonnel()
        {
            try
            {
                return Ok(await _unitOfWork.Personnel.GetAllAsync());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving all personnel data");
            }
        }

        //"{id:int}" forces api to be mapped to int only, "api/Person/Ten" will not map to this method
        [HttpGet("{id:int}")]
        //[EnableCors("VueCorsPolicy")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            try
            {
                var result = await _unitOfWork.Personnel.GetAsync(id);

                return result == null ? NotFound() : result;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving personnel data with Id: {id} ");
            }
        }

        [HttpPost]
        //[EnableCors("VueCorsPolicy")]
        public async Task<ActionResult<Person>> AddPerson(Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            try
            {
                await _unitOfWork.Personnel.AddAsync(person);
                _unitOfWork.Save();

                return CreatedAtAction(nameof(GetPerson), new {id = person.Id}, person);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding personnel data");
            }
        }

        [HttpPut("{id:int}")]
        //[EnableCors("VueCorsPolicy")]
        public async Task<ActionResult<Person>> UpdatePerson(int id, Person person)
        {
            try
            {
                //Appears to be not needed as that would mean there is no body?
                //if (person == null)
                //{
                //    return BadRequest("Person can not be null");
                //}

                if (id != person.Id)
                {
                    return BadRequest("Id value passed does not match Id of Person object");
                }

                var personToUpdate = await _unitOfWork.Personnel.GetAsync(id);

                if (personToUpdate == null)
                {
                    return NotFound($"Person with Id: {id} not found");
                }
                
                await _unitOfWork.Personnel.UpdateAsync(person);
                _unitOfWork.Save();

                return person;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating personnel data with Id: {id} ");
            }
        }


        [HttpDelete("{id:int}")]
        //[EnableCors("VueCorsPolicy")]
        public async Task<ActionResult> DeletePerson(int id)
        {
            try
            {
          
                var personToDelete = await _unitOfWork.Personnel.GetAsync(id);

                if (personToDelete == null)
                {
                    return NotFound($"Delete failed. Person with Id: {id} not found");
                }
                
                await _unitOfWork.Personnel.RemoveAsync(id);
                _unitOfWork.Save();

                return Ok($"Person with Id: {id} deleted successfully");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting personnel data with Id: {id} ");
            }
        }

    }
}
