using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sln_kebutuhan.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sln_kebutuhan.Controllers
{
    [Route("api/Kebutuhan")]
    [ApiController]
    public class KebutuhanController : ControllerBase
    {
        private readonly LatihanContext db;

        public KebutuhanController(LatihanContext _db)
        {
            db = _db;
        }


        // GET: api/<KebutuhanController>
        //[Authorize]
        [HttpGet]
        public IEnumerable<object> Get()
        {
            var query = (from q in db.Kebutuhans select new { id = q.keb_id, nama = q.keb_nama, ket = q.keterangan }).ToList();
            //return new string[] { "value1", "value2" };
            return query;
        }

        [HttpGet]
        [Route("test")]
        //public IEnumerable<object> test()
        public string test()
        {
            var query = (from q in db.Kebutuhans select new { id = q.keb_id, nama = q.keb_nama, ket = q.keterangan }).ToList();
            //return new string[] { "value1", "value2" };
            var ser_obj = JsonConvert.SerializeObject(query);
            return ser_obj;
        }

        // GET api/<KebutuhanController>/5
        //[Authorize]
        [HttpGet("{id}")]
        public object Get(int id)
        {
            var query = (from q in db.Kebutuhans where q.keb_id == id select new { id = q.keb_id, nama = q.keb_nama, ket = q.keterangan }).FirstOrDefault();
            //return new string[] { "value1", "value2" };
            return query;
        }

        // POST api/<KebutuhanController>
        [Authorize]
        [HttpPost]
        public string Post([FromBody] Kebutuhan data)
        {
            try
            {
                Kebutuhan baru = new Kebutuhan();
                baru.keb_nama = data.keb_nama;
                baru.keterangan = data.keterangan;
                db.Kebutuhans.Add(baru);
                db.SaveChanges();
                return "Berhasil simpan data";
            }
            catch (Exception ex)
            {
                //return ex.Message;
                return "Gagal simpan data";
            }
        }

        // PUT api/<KebutuhanController>/5
        [Authorize]
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Kebutuhan data)
        {
            try
            {
                Kebutuhan lama = (from q in db.Kebutuhans where q.keb_id == id select q).FirstOrDefault();
                lama.keb_nama = data.keb_nama;
                lama.keterangan = data.keterangan;
                db.Kebutuhans.Add(lama);
                db.SaveChanges();
                return "Berhasil ubah data";

            }
            catch (Exception ex)
            {

                //return ex.Message;
                return "Gagal ubah data";
            }
        }

        // DELETE api/<KebutuhanController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                Kebutuhan lama = (from q in db.Kebutuhans where q.keb_id == id select q).FirstOrDefault();
                var keb_detail = (from q in db.Kebutuhan_Details where q.keb_id == lama.keb_id select q);
                foreach (var det in keb_detail)
                {
                    db.Kebutuhan_Details.Remove(det);
                }
                db.Kebutuhans.Remove(lama);
                db.SaveChanges();
                return "berhasil hapus data";

            }
            catch (Exception ex)
            {

                //return ex.Message;
                return "gagal hapus data";
            }
        }
    }
}
