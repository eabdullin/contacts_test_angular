using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BLL;
using DAL.Common.Repositories;
using TestApp.Extenstions;
using TestApp.Helpers;
using TestApp.Models;

namespace TestApp.Controllers
{
    [RoutePrefix("api/contacts")]
    public class ContactController : ApiController
    {
        private IContactRepository _contactRepository;
        private IContactService _contactService;

        public ContactController(IContactRepository contactRepository, IContactService contactService)
        {
            _contactRepository = contactRepository;
            _contactService = contactService;
        }

        [Route]
        [ResponseType(typeof(PaginationModel<ContactShortModel>))]
        public IHttpActionResult GetContacts(int? page = null, int? countPerPage = null, string q = null, string genderId = null, string companyId = null,
            string jobTitleId = null)
        {
            int totalCount;
            var contacts = _contactRepository.Get(out totalCount, page, countPerPage, q, genderId, companyId, jobTitleId);
            return Ok(new PaginationModel<ContactShortModel>()
            {
                Items = contacts.MapEachTo<ContactShortModel>(),
                TotalCount = totalCount
            });
        }


        [HttpPost]
        [Route]
        public IHttpActionResult Create(ContactModel model)
        {
            var result = _contactService.CreateContact(model);
            if (!result.Succeeded)
            {
                return this.GetErrorResult(result);
            }
            return Ok();
        }


        [HttpPut]
        [Route("{id:long}")]
        public IHttpActionResult Put(long id, ContactModel model)
        {
            var result = _contactService.EditContact(id, model);
            if (!result.Succeeded)
            {
                return this.GetErrorResult(result);
            }
            return Ok();
        }
        [Route("{id:long}")]
        [ResponseType(typeof(ContactModel))]
        public IHttpActionResult GetContact(long id)
        {
            var contacts = _contactRepository.Find(id);
            return Ok(contacts.MapTo<ContactModel>());
        }

        [HttpDelete]
        [Route("{id:long}")]
        public IHttpActionResult Delete(long id)
        {
             _contactService.DeleteContact(id);
            return Ok();
        }
    }
}
