using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sln_rencana_bulanan.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sln_rencana_bulanan.Controllers
{
    [Route("api/RencanaBulanan")]
    [ApiController]
    public class RencanaBulananController : ControllerBase
    {
        private readonly LatihanContext _db;

        public RencanaBulananController(LatihanContext db)
        {
            _db = db;
        }
        // GET: api/<RencanaBulananController>
        [HttpGet]
        public IEnumerable<object> Get()
        {
            var List_Rencana = from q in _db.Rencana_Bulanans select new { id = q.ren_bul_id,tahun=q.tahun, bulan = q.bulan, peng = q.rup_peng, tab = q.rup_tab, tak_terduga = q.rup_takterduga };
            //return new string[] { "value1", "value2" };
            return List_Rencana;
        }

        // GET api/<RencanaBulananController>/5
        [HttpGet("{id}")]
        public object Get(int id)
        {
            var List_Rencana = from q in _db.Rencana_Bulanans where q.ren_bul_id==id select new { id = q.ren_bul_id, tahun = q.tahun, bulan = q.bulan, peng = q.rup_peng, tab = q.rup_tab, tak_terduga = q.rup_takterduga };
            //return "value";
            return List_Rencana.FirstOrDefault();
        }

        // POST api/<RencanaBulananController>
        [HttpPost]
        public void Post([FromBody] Rencana_Bulanan value)
        {
            Rencana_Bulanan obj = new Rencana_Bulanan();
            obj.tahun = value.tahun;
            obj.bulan = value.bulan;
            obj.pers_peng = value.pers_peng;
            obj.rup_peng = value.rup_peng;
            obj.pers_tab = value.pers_tab;
            obj.rup_tab = value.rup_tab;
            obj.pers_takterduga = value.pers_takterduga;
            obj.rup_takterduga = value.rup_takterduga;
            //obj.ren_bul_id = -1;
            _db.Rencana_Bulanans.Add(obj);
            _db.SaveChanges();
            //var data_input = JsonConvert.DeserializeObject<Rencana_Bulanan>(value);

        }

        // PUT api/<RencanaBulananController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RencanaBulananController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
