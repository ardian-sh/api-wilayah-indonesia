using kecamatan.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiWilayahIndonesia;
using provinsi.Model;
using kota.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WilayahIndonesia.Repository;
using kelurahan.Model;

namespace ApiWilayahIndonesia.Controllers
{
    [Route("api/wilayah-indonesia")]
    [ApiController]
    public class ApiWilayahIndonesiaController : ControllerBase
    {
        readonly WilayahIndonesiaRepository dataRepo = new();

        [HttpGet("provinsi")]
        public ActionResult GetProvinsi(string Id)
        {
            IProvinsi provinsi = new();
            try
            {
                if (!int.TryParse(Id, out int ProvinsiIdCheck) && !string.IsNullOrEmpty(Id))
                {
                    provinsi.Deskripsi = string.Format("Nilai {0} tidak valid", Id);
                    provinsi.Kode = 400;
                    provinsi.Provinsi = new();

                    return Ok(provinsi);
                }

                int? idProvinsi = string.IsNullOrEmpty(Id) ? null: ProvinsiIdCheck;

                List<ProvinsiList> provinsiLists = dataRepo.GetAllProvinsi(idProvinsi);
                if(provinsiLists.Count > 0)
                {
                    provinsi.Deskripsi = "OK";
                    provinsi.Kode = 200;
                    provinsi.Provinsi = provinsiLists;
                }
                else
                {
                    provinsi.Deskripsi = "Data tidak ditemukan";
                    provinsi.Kode = 404;
                    provinsi.Provinsi = new();
                }
            }
            catch(Exception e)
            {
                provinsi.Deskripsi = "Terjadi kesalahan saat memproses permintaan "+e.Message;
                provinsi.Kode = 500;
                provinsi.Provinsi = new();
            }


            return Ok(provinsi);
        }

        [HttpGet("kota")]
        public IActionResult GetKota(string provinsi)
        {
            Ikota kota = new();
            try
            {
                if (!int.TryParse(provinsi, out int idProvinsi))
                {
                    kota.Deskripsi = string.Format("Nilai {0} tidak valid", provinsi);
                    kota.Kode = 400;
                    kota.Kota = new();

                    return Ok(kota);
                }

                List<KotaList> kotaLists = dataRepo.GetKota(idProvinsi);
                if (kotaLists.Count > 0)
                {
                    kota.Deskripsi = "OK";
                    kota.Kode = 200;
                    kota.Kota = kotaLists;
                }
                else
                {
                    kota.Deskripsi = "Data tidak ditemukan";
                    kota.Kode = 404;
                    kota.Kota = new();
                }
            }
            catch
            {
                kota.Deskripsi = "Terjadi kesalahan saat memproses permintaan";
                kota.Kode = 500;
                kota.Kota = new();
            }

            return Ok(kota);
        }

        [HttpGet("kecamatan")]
        public IActionResult GetKecamatan(string kota)
        { 
            Ikecamatan kecamatan = new();
            try
            {
                if (!int.TryParse(kota, out int kotaId))
                {
                    kecamatan.Deskripsi = string.Format("Nilai {0} tidak valid", kota);
                    kecamatan.Kode = 400;
                    kecamatan.Kecamatan = new();

                    return Ok(kecamatan);
                }

                List<KecamatanList> kecamatanLists = dataRepo.GetKecamatan(kotaId);

                if (kecamatanLists.Count > 0)
                {
                    kecamatan.Deskripsi = "OK";
                    kecamatan.Kode = 200;
                    kecamatan.Kecamatan = kecamatanLists;
                }
                else
                {
                    kecamatan.Deskripsi = "Data tidak ditemukan";
                    kecamatan.Kode = 404;
                    kecamatan.Kecamatan = new();
                }
            }
            catch
            {
                kecamatan.Deskripsi = "Terjadi kesalahan saat memproses permintaan";
                kecamatan.Kode = 500;
                kecamatan.Kecamatan = new();
            }

            return Ok(kecamatan);
        }

        [HttpGet("kelurahan")]
        public IActionResult GetKelurahan(string kecamatan)
        {
            Ikelurahan kelurahan = new();
            try
            {
                if (!long.TryParse(kecamatan, out long kecamatanId))
                {
                    kelurahan.Deskripsi = string.Format("Nilai {0} tidak valid", kecamatan);
                    kelurahan.Kode = 400;
                    kelurahan.Kelurahan = new();

                    return Ok(kelurahan);
                }

                List<KelurahanList> kelurahanLists = dataRepo.GetKelurahan(kecamatanId);

                if (kelurahanLists.Count > 0)
                {
                    kelurahan.Deskripsi = "OK";
                    kelurahan.Kode = 200;
                    kelurahan.Kelurahan = kelurahanLists;
                }
                else
                {
                    kelurahan.Deskripsi = "Data tidak ditemukan";
                    kelurahan.Kode = 404;
                    kelurahan.Kelurahan = new();
                }
            }
            catch
            {
                kelurahan.Deskripsi = "Terjadi kesalahan saat memproses permintaan";
                kelurahan.Kode = 500;
                kelurahan.Kelurahan = new();
            }

            return Ok(kelurahan);
        }
    }

    
}
