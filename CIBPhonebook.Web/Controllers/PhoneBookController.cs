using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CIBPhonebook.Domain.Services.Interfaces;
using CIBPhonebook.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CIBPhonebook.Web.Controllers
{
    [Route("api/phonebook")]
    public class PhoneBookController : Controller
    {
        [HttpGet, Route("getall")]
        public async Task<IEnumerable<PhoneBookDto>> GetAll([FromServices] IGetPhoneBookRecord getPhoneBookRecord)
        {
            return await getPhoneBookRecord.GetAllPhoneBookEntries();
        }

        [HttpGet, Route("getbyname")]
        public async Task<IEnumerable<PhoneBookDto>> GetByName([Required][FromHeader] string name,
            [FromServices] IGetPhoneBookRecord getPhoneBookRecord)
        {
            return await getPhoneBookRecord.GetPhoneBookByName(name);
        }


        [HttpGet, Route("getbysurname")]
        public async Task<IEnumerable<PhoneBookDto>> GetBySurname([Required][FromHeader] string surname,
            [FromServices] IGetPhoneBookRecord getPhoneBookRecord)
        {
            return await getPhoneBookRecord.GetPhoneBookBySurname(surname);
        }


        [HttpGet, Route("getbyphonebook")]
        public async Task<IEnumerable<PhoneBookDto>> GetByPhoneNumber([Required][FromHeader] string phonenumber,
            [FromServices] IGetPhoneBookRecord getPhoneBookRecord)
        {
            return await getPhoneBookRecord.GetPhoneBookByPhoneNumber(phonenumber);
        }


        [HttpPost, Route("addphonebook")]
        public async Task<ActionResult<ValidationResponseDto>> AddPhoneBook([FromBody]PhoneBookDto phoneBook,
            [FromServices] IAddPhoneBookRecord addPhoneBookRecord,
            CancellationToken cancellationtoken)
        {
            var response = await addPhoneBookRecord.CreatePhoneBookRecord(phoneBook, cancellationtoken);

            if(!response.IsValid)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
