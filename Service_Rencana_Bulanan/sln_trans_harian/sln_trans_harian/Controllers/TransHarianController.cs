using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sln_trans_harian.Models;
using sln_trans_harian.ModelsMeta;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sln_trans_harian.Controllers
{
    [Route("api/TransHarian")]
    [ApiController]
    public class TransHarianController : ControllerBase
    {
        private readonly Latihan2Context db;
        //private static readonly HttpClient client = new HttpClient();
        public TransHarianController(Latihan2Context _db)
        {
            db = _db;
        }

        //[HttpGet]
        //[Route("GetKeb")]
        //public async Task<IActionResult> list_keb_detailAsync()
        //{
        //    var obj_Kebutuhan_Detail = new List<List_Kebutuhan_Detail>();
        //    var obj_Pem_Alokasi = new List<List_Pem_Alokasi>();
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            string fullpath = "http://localhost:5149/api/KebutuhanDetail";
        //            var resp = await client.GetAsync(fullpath);
        //            var respBody = await resp.Content.ReadAsStringAsync();
        //            //var listOfInstances = JsonConvert.DeserializeObject<List<dynamic>>(respBody);
        //            //var listOfInstances = JsonConvert.DeserializeObject<List<Kebutuhan>>(respBody);
        //            //var listOfInstances = JsonConvert.DeserializeObject<List<List_Kebutuhan_Detail>>(respBody);
        //            //var DataKebDetail = JsonConvert.DeserializeObject<List<List_Kebutuhan_Detail>>(respBody);
        //            var DataKebDetail = JsonConvert.DeserializeObject<List<List_Kebutuhan_Detail>>(respBody);
        //            //foreach (var data in DataKebDetail)
        //            //{
        //            //    obj_Kebutuhan_Detail.Add(data);
        //            //}

        //            string fullpath_alokasi = "http://localhost:5014/api/AlokasiPenghasilan";
        //            var resp_alokasi = await client.GetAsync(fullpath_alokasi);
        //            var respBody_alokasi = await resp_alokasi.Content.ReadAsStringAsync();
        //            //var listOfInstances = JsonConvert.DeserializeObject<List<dynamic>>(respBody);
        //            //var listOfInstances = JsonConvert.DeserializeObject<List<Kebutuhan>>(respBody);
        //            //var listOfInstances = JsonConvert.DeserializeObject<List<List_Kebutuhan_Detail>>(respBody);
        //            //var Data_alokasi = JsonConvert.DeserializeObject<List<List_Pem_Alokasi>>(respBody_alokasi);
        //            var Data_alokasi = JsonConvert.DeserializeObject<List<List_Pem_Alokasi>>(respBody_alokasi);
        //            //foreach (var data in Data_alokasi)
        //            //{
        //            //    obj_Pem_Alokasi.Add(data);
        //            //}
        //            return Ok(query);
        //        }
        //        return Ok();
        //    }
        //    catch (Exception)
        //    {

        //        return BadRequest();
        //    }
        //}

        [HttpGet]
        [Route("GetKeb")]
        public async Task<IEnumerable<List_Kebutuhan_Detail>> list_keb_detailAsync()
        {
            var obj_Kebutuhan_Detail = new List<List_Kebutuhan_Detail>();
            var obj_Pem_Alokasi = new List<List_Pem_Alokasi>();
            try
            {
                using (var client = new HttpClient())
                {
                    string fullpath = "http://localhost:5149/api/KebutuhanDetail";
                    var resp = await client.GetAsync(fullpath);
                    var respBody = await resp.Content.ReadAsStringAsync();
                    //var listOfInstances = JsonConvert.DeserializeObject<List<dynamic>>(respBody);
                    //var listOfInstances = JsonConvert.DeserializeObject<List<Kebutuhan>>(respBody);
                    //var listOfInstances = JsonConvert.DeserializeObject<List<List_Kebutuhan_Detail>>(respBody);
                    //var DataKebDetail = JsonConvert.DeserializeObject<List<List_Kebutuhan_Detail>>(respBody);
                    var DataKebDetail = JsonConvert.DeserializeObject<List<List_Kebutuhan_Detail>>(respBody);
                    //foreach (var data in DataKebDetail)
                    //{
                    //    obj_Kebutuhan_Detail.Add(data);
                    //}


                    return DataKebDetail;
                }
                return obj_Kebutuhan_Detail;
            }
            catch (Exception)
            {

                return obj_Kebutuhan_Detail;
            }
        }

        [HttpGet]
        [Route("GetPemAlokasi")]
        public async Task<IEnumerable<List_Pem_Alokasi>> list_Pem_AlokasiAsync()
        {
            var obj_Kebutuhan_Detail = new List<List_Kebutuhan_Detail>();
            var obj_Pem_Alokasi = new List<List_Pem_Alokasi>();
            try
            {
                using (var client = new HttpClient())
                {
                    string fullpath_alokasi = "http://localhost:5014/api/AlokasiPenghasilan";
                    var resp_alokasi = await client.GetAsync(fullpath_alokasi);
                    var respBody_alokasi = await resp_alokasi.Content.ReadAsStringAsync();
                    //var listOfInstances = JsonConvert.DeserializeObject<List<dynamic>>(respBody);
                    //var listOfInstances = JsonConvert.DeserializeObject<List<Kebutuhan>>(respBody);
                    //var listOfInstances = JsonConvert.DeserializeObject<List<List_Kebutuhan_Detail>>(respBody);
                    //var Data_alokasi = JsonConvert.DeserializeObject<List<List_Pem_Alokasi>>(respBody_alokasi);
                    var Data_alokasi = JsonConvert.DeserializeObject<List<List_Pem_Alokasi>>(respBody_alokasi);
                    //foreach (var data in Data_alokasi)
                    //{
                    //    obj_Pem_Alokasi.Add(data);
                    //}
                    return Data_alokasi;
                }
                return obj_Pem_Alokasi;
            }
            catch (Exception)
            {

                return obj_Pem_Alokasi;
            }
        }

        // GET: api/<TransHarianController>
        //[Authorize]
        [HttpGet]
        [Route("Gabungan")]
        //public IEnumerable<object> Get()
        public async Task<IEnumerable<object>> GetGabungan()
        {
            var data1 = await list_keb_detailAsync();
            var data2 = await list_Pem_AlokasiAsync();

            //var query = (from q in db.Trans_Harians
            //             join t in data1.AsEnumerable() on q.keb_det_id equals t.keb_det_id
            //             select q).ToList();
            //var query1 = (from q in data1 select q).ToList();
            //var query2 = (from q in data2 select q).ToList();
            //var gab = (from q in query1
            //           join t in query2 on q.keb_det_id equals t.peng_id
            //           select q).ToList();

            var gab2 = (from q in db.Trans_Harians.AsEnumerable()
                        join t in data1 on q.keb_det_id equals t.keb_det_id
                        join r in data2 on q.peng_id equals r.peng_id
                        select new
                        {
                            q.trans_id,q.keb_det_id,q.peng_id,q.jumlah,q.tahun,q.bulan,t.keb_det_nama,r.peng_nama
                        }).ToList();
            return gab2;
        }

        // GET: api/<TransHarianController>
        //[Authorize]
        [HttpGet]
        //public IEnumerable<object> Get()
        public IEnumerable<object> Get()
        {
            var query = (from q in db.Trans_Harians
                         select new
                         {
                             trans_id = q.trans_id,
                             keb_det_id = q.keb_det_id,
                             peng_id = q.peng_id,
                             jumlah = q.jumlah,
                             ket = q.keterangan,
                             tahun = q.tahun,
                             bulan = q.bulan
                         });
            return query;
        }

        // GET api/<TransHarianController>/5
        //[Authorize]
        [HttpGet("{id}")]
        public object Get(int id)
        {
            var query = (from q in db.Trans_Harians
                         where q.trans_id == id
                         select new
                         {
                             trans_id = q.trans_id,
                             keb_det_id = q.keb_det_id,
                             peng_id = q.peng_id,
                             jumlah = q.jumlah,
                             ket = q.keterangan,
                             tahun = q.tahun,
                             bulan = q.bulan
                         }).FirstOrDefault();
            return query;
        }

        // POST api/<TransHarianController>
        [Authorize]
        [HttpPost]
        public void Post([FromBody] Trans_Harian data)
        {
            Trans_Harian baru = new Trans_Harian();
            baru.keb_det_id = data.keb_det_id;
            baru.peng_id = data.peng_id;
            baru.jumlah = data.jumlah;
            baru.keterangan = data.keterangan;
            baru.tahun = data.tahun;
            baru.bulan = data.bulan;
            db.Trans_Harians.Add(baru);
            db.SaveChanges();
        }

        // PUT api/<TransHarianController>/5
        [Authorize]
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Trans_Harian data)
        {
            Trans_Harian lama = (from q in db.Trans_Harians where q.trans_id == id select q).FirstOrDefault();
            lama.keb_det_id = data.keb_det_id;
            lama.peng_id = data.peng_id;
            lama.jumlah = data.jumlah;
            lama.keterangan = data.keterangan;
            lama.tahun = data.tahun;
            lama.bulan = data.bulan;
            db.SaveChanges();
            return "";
        }

        // DELETE api/<TransHarianController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            Trans_Harian lama = (from q in db.Trans_Harians where q.trans_id == id select q).FirstOrDefault();
            db.Trans_Harians.Remove(lama);
            db.SaveChanges();
            return "";
        }
    }
}
