using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sln_kebutuhan.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sln_kebutuhan.Controllers
{
    [Route("api/KebutuhanDetail")]
    [ApiController]
    public class KebutuhanDetailController : ControllerBase
    {
        private readonly LatihanContext db;

        public KebutuhanDetailController(LatihanContext _db)
        {
            db = _db;
        }
        // GET: api/<KebutuhanDetailController>
        //[Authorize]
        [HttpGet]
        public IEnumerable<object> Get()
        {
            //var query = (from q in db.Kebutuhan_Details select new {nama=q.keb_det_nama, id=q.keb_det_id, keb_id=q.keb_id,status=q.status });
            var query = db.List_Kebutuhan_Details;
            return query;
            //return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("test")]
        public IEnumerable<object> test()
        {
            //var query = (from q in db.Kebutuhan_Details select new {nama=q.keb_det_nama, id=q.keb_det_id, keb_id=q.keb_id,status=q.status });
            var query = from q in db.List_Kebutuhan_Details select new { keb_id=q.keb_id, keb_det_nama = q.keb_det_nama };
            var ser_obj= JsonConvert.SerializeObject(query);
            return query.ToList();
            //return new string[] { "value1", "value2" };
        }

        // GET api/<KebutuhanDetailController>/5
        //[Authorize]
        [HttpGet("{id}")]
        public object Get(int id)
        {
            //var query = (from q in db.Kebutuhan_Details where q.keb_det_id==id select new { nama = q.keb_det_nama, id = q.keb_det_id, keb_id = q.keb_id, status = q.status }).FirstOrDefault();
            var query = db.List_Kebutuhan_Details;
            return query.Where(w=>w.keb_det_id==id).FirstOrDefault();
        }

        // POST api/<KebutuhanDetailController>
        [Authorize]
        [HttpPost]
        public string Post([FromBody] Kebutuhan_Detail data)
        {
            Kebutuhan_Detail baru = new Kebutuhan_Detail();
            baru.keb_id = data.keb_id;
            baru.keb_det_nama = data.keb_det_nama;
            baru.status = data.status;
            db.Kebutuhan_Details.Add(baru);
            db.SaveChanges();
            return "";
        }

        // PUT api/<KebutuhanDetailController>/5
        [Authorize]
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Kebutuhan_Detail data)
        {
            Kebutuhan_Detail lama = (from q in db.Kebutuhan_Details where q.keb_det_id==id select q).FirstOrDefault();
            lama.keb_id = data.keb_id;
            lama.keb_det_nama = data.keb_det_nama;
            lama.status = data.status;
            db.SaveChanges();
            return "";
        }

        // DELETE api/<KebutuhanDetailController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            Kebutuhan_Detail lama = (from q in db.Kebutuhan_Details where q.keb_det_id == id select q).FirstOrDefault();
            db.Kebutuhan_Details.Remove(lama);
            db.SaveChanges();
            return "";
        }
    }
}
