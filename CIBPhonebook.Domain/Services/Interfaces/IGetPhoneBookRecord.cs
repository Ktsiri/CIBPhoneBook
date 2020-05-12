using System.Collections.Generic;
using System.Threading.Tasks;
using CIBPhonebook.Dtos;

namespace CIBPhonebook.Domain.Services.Interfaces
{
    public interface IGetPhoneBookRecord
    {
        Task<IEnumerable<PhoneBookDto>> GetAllPhoneBookEntries();
        Task<IEnumerable<PhoneBookDto>> GetPhoneBookByName(string name);
        Task<IEnumerable<PhoneBookDto>> GetPhoneBookBySurname(string surname);
        Task<IEnumerable<PhoneBookDto>> GetPhoneBookByPhoneNumber(string phonenumber);
    }
}
