using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DAL.Common.Repositories;
using TestApp.Helpers;
using TestApp.Models;

namespace TestApp.Controllers
{
    [RoutePrefix("api/dictionaries")]
    public class DictionaryController : ApiController
    {
        private IDictionaryRepository _dictionaryRepository;

        public DictionaryController(IDictionaryRepository dictionaryRepository)
        {
            _dictionaryRepository = dictionaryRepository;
        }

        [Route("{type}")]
        [ResponseType(typeof(IEnumerable<DictionaryModel>))]
        public IHttpActionResult Get(string type)
        {
            var items = _dictionaryRepository.GetAll(type);
            return Ok(items.MapEachTo<DictionaryModel>());
        }
    }
}
