using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CashPleaseController : ControllerBase
    {
        private readonly ILogger<CashPleaseController> _logger;

        private static List<Contact> _list = new List<Contact>()
        {
            new()
            {
                Id = 1,
                Avatar = "https://sessionize.com/image/124e-400o400o2-wHVdAuNaxi8KJrgtN3ZKci.jpg",
                FirstName = "Web API - Shruti",
                LastName = "Kapoor",
                Twitter = "@shrutikapoor08"
            },
            new()
            {
                Id = 2,
                Avatar = "https://sessionize.com/image/1940-400o400o2-Enh9dnYmrLYhJSTTPSw3MH.jpg",
                FirstName = "Web API - Glenn",
                LastName = "Reyes",
                Twitter = "@glnnrys"
            },
            new()
            {
                Id = 3,
                Avatar = "https://sessionize.com/image/9273-400o400o2-3tyrUE3HjsCHJLU5aUJCja.jpg",
                FirstName = "Web API - Ryan",
                LastName = "Florence",
                Twitter = "@Florence"
            },
            new()
            {
                Id = 4,
                Avatar = "https://sessionize.com/image/d14d-400o400o2-pyB229HyFPCnUcZhHf3kWS.png",
                FirstName = "Web API - Oscar",
                LastName = "Newman",
                Twitter = "@__oscarnewman"
            },
            new()
            {
                Id = 5,
                Avatar = "https://sessionize.com/image/fd45-400o400o2-fw91uCdGU9hFP334dnyVCr.jpg",
                FirstName = "Web API - Michael",
                LastName = "Jackson",
                Twitter = "@Jackson"
            },
        };

        public CashPleaseController(ILogger<CashPleaseController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// GET: CashPlease/Contacts
        /// Get a list of all contacts
        /// </summary>
        /// <returns></returns>
        [HttpGet("Contacts")]
        public IEnumerable<Contact> GetContacts()
        {
            return _list;
        }

        /// <summary>
        /// GET CashPlease/Contacts?name=User 1
        /// Get a list of contacts by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("Contacts/name={name}")]
        public IEnumerable<Contact> GetContactByName(string name)
        {
            var contact = _list.Where(x => x.FirstName.Contains(name) || x.LastName.Contains(name));
            contact ??= new List<Contact>();

            return contact;
        }

        /// <summary>
        /// GET CashPlease/Contacts/1
        /// Get a contact by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Contacts/{id}")]
        public Contact GetContact(int id)
        {
            var contact = _list.FirstOrDefault(x => x.Id == id);
            contact ??= new Contact();

            return contact;
        }

        /// <summary>
        /// POST CreateContact/firstName=Lee/lastName=Thoai
        /// Create a new contact
        /// Required: firstName, lastName
        /// Optional: avatar
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="avatar"></param>
        /// <returns></returns>
        [HttpPost("CreateContact/firstName={firstName}/lastName={lastName}")]
        public Contact CreateContact(string firstName, string lastName, string? avatar) 
        {
            var id = _list.Max(x => x.Id) + 1;

            var contact = new Contact { Id = id, FirstName = firstName, LastName = lastName, Avatar = avatar };

            _list.Add(contact);

            return contact;
        }

        [HttpPost("CreateContact")]
        public Contact CreateContact(Contact contact)
        {
            var id = _list.Max(x => x.Id) + 1;

            contact ??= new Contact();
            contact.Id = id;

            _list.Add(contact);

            return contact;
        }

        /// <summary>
        /// PUT UpdateContact/id=1/firstName=test/lastName=user 1
        /// Update a contact by id
        /// Required: id, firstName, lastName
        /// Optional: avatar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("UpdateContact/id={id}/firstName={firstName}/lastName={lastName}")]
        public Contact UpdateContact(int id, string firstName, string lastName, string? avatar) 
        { 
            var contact = _list.Find(x => x.Id == id);
            if (contact != null)
            {
                contact.FirstName = firstName;
                contact.LastName = lastName;
                contact.Avatar = avatar;
            }
            else
            {
                contact = new Contact();
            }

            return contact;
        }

        [HttpPut("UpdateContact")]
        public Contact UpdateContact(Contact contact)
        {
            var result = _list.Find(x => x.Id == contact.Id);
            if (result != null)
            {
                result.FirstName = contact.FirstName;
                result.LastName = contact.LastName;
                result.Avatar = contact.Avatar;
                result.Email = contact.Email;
            }

            result ??= new Contact();
            return result;
        }

        /// <summary>
        /// DELETE DeleteContact/1
        /// Delete a contact by id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("DeleteContact/{id}")]
        public Contact DeleteContact(int id) 
        {
            var contac = _list.Find(x => x.Id == id);
            if ( contac != null )
            {
                _list.Remove(contac);
            }
            else
            {
                contac = new Contact();
            }

            return contac;
        }
    }
}
