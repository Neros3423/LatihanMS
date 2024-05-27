using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sln_rencana_bulanan.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sln_rencana_bulanan.Controllers
{
    [Route("api/AlokasiPenghasilan")]
    [ApiController]
    public class AlokasiPenghasilanController : ControllerBase
    {
        private readonly LatihanContext db;

        public AlokasiPenghasilanController(LatihanContext _db)
        {
            db = _db;
        }
        // GET: api/<AlokasiPenghasilanController>
        //[Authorize]
        [HttpGet]
        public IEnumerable<object> Get()
        {
            //var query = (from q in db.Alokasi_Penghasilans select new {id=q.peng_id,pem_id=q.pem_id,nama=q.peng_nama,persen=q.peng_persen,ket=q.keterangan });
            var query = db.List_Pem_Alokasis;
            //return new string[] { "value1", "value2" };
            return query;
        }

        // GET api/<AlokasiPenghasilanController>/5
        //[Authorize]
        [HttpGet("{id}")]
        public object Get(int id)
        {
            //var query = (from q in db.Alokasi_Penghasilans where q.peng_id==id select new { id = q.peng_id, pem_id = q.pem_id, nama = q.peng_nama, persen = q.peng_persen, ket = q.keterangan });
            var query=db.List_Pem_Alokasis;
            //return "value";
            return query.Where(w=>w.peng_id==id).FirstOrDefault();
        }

        // POST api/<AlokasiPenghasilanController>
        [Authorize]
        [HttpPost]
        public string Post([FromBody] Alokasi_Penghasilan data)
        {
            Alokasi_Penghasilan baru = new Alokasi_Penghasilan();
            baru.peng_nama = data.peng_nama;
            baru.keterangan = data.keterangan;
            baru.pem_id = data.pem_id;
            db.Alokasi_Penghasilans.Add(baru);
            db.SaveChanges();
            return "";
        }

        // PUT api/<AlokasiPenghasilanController>/5
        [Authorize]
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Alokasi_Penghasilan data)
        {
            Alokasi_Penghasilan lama = (from q in db.Alokasi_Penghasilans where q.peng_id==id select q).FirstOrDefault();
            lama.peng_nama = data.peng_nama;
            lama.keterangan = data.keterangan;
            lama.pem_id = data.pem_id;
            db.SaveChanges();
            return "";
        }

        // DELETE api/<AlokasiPenghasilanController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            Alokasi_Penghasilan lama = (from q in db.Alokasi_Penghasilans where q.peng_id == id select q).FirstOrDefault();
            db.Alokasi_Penghasilans.Remove(lama);
            db.SaveChanges();
            return "";
        }
    }
}
