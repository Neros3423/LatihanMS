using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sln_rencana_bulanan.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sln_rencana_bulanan.Controllers
{
    [Route("api/Pemasukkan")]
    [ApiController]
    public class PemasukkanController : ControllerBase
    {
        private readonly LatihanContext db;

        public PemasukkanController(LatihanContext _db)
        {
            db = _db;
        }
        // GET: api/<PemasukkanController>
        [Authorize]
        [HttpGet]
        public IEnumerable<object> Get()
        {
            var query = (from q in db.Pemasukkans select new { nama = q.pem_nama, tahun = q.tahun, bulan = q.bulan, jumlah = q.jumlah, ket = q.keterangan });
            return query;
            //return new string[] { "value1", "value2" };
        }

        // GET api/<PemasukkanController>/5
        [Authorize]
        [HttpGet("{id}")]
        public object Get(int id)
        {
            var query = (from q in db.Pemasukkans where q.pem_id == id select new { nama = q.pem_nama, tahun = q.tahun, bulan = q.bulan, jumlah = q.jumlah, ket = q.keterangan }).FirstOrDefault();
            //return "value";
            return query;
        }

        // POST api/<PemasukkanController>
        [Authorize]
        [HttpPost]
        public string Post([FromBody] Pemasukkan data)
        {
            try
            {
                Pemasukkan baru = new Pemasukkan();
                baru.pem_nama = data.pem_nama;
                baru.jumlah = data.jumlah;
                baru.keterangan = data.keterangan;
                baru.tahun = data.tahun;
                baru.bulan = data.bulan;
                db.Pemasukkans.Add(baru);
                db.SaveChanges();
                return "Data Berhasil ditambah";

            }
            catch (Exception)
            {
                return "Data Gagal ditambah";
            }
        }

        // PUT api/<PemasukkanController>/5
        [Authorize]
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Pemasukkan data)
        {
            Pemasukkan lama =(from q in db.Pemasukkans where q.pem_id==id select q).FirstOrDefault();
            lama.pem_nama = data.pem_nama;
            lama.jumlah = data.jumlah;
            lama.keterangan = data.keterangan;
            lama.tahun = data.tahun;
            lama.bulan = data.bulan;
            db.SaveChanges();
            return "Data Berhasil dirubah";
        }

        // DELETE api/<PemasukkanController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            Pemasukkan lama = (from q in db.Pemasukkans where q.pem_id == id select q).FirstOrDefault();
            var alok_detail = (from q in db.Alokasi_Penghasilans where q.pem_id==lama.pem_id select q);
            foreach (var det in alok_detail)
            {
                db.Alokasi_Penghasilans.Remove(det);
            }
            db.Pemasukkans.Remove(lama);
            db.SaveChanges();
            return "Data Berhasil dirubah";
        }
    }
}
