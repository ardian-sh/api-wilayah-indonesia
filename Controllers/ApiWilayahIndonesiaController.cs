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
using Microsoft.AspNetCore.Hosting;
using ApiWilayahIndonesia.Interface;

namespace ApiWilayahIndonesia.Controllers
{
    [Route("api/wilayah-indonesia")]
    [ApiController]
    public class ApiWilayahIndonesiaController : ControllerBase
    {
        readonly IWilayahIndonesiaInterface _dataRepo;

        public ApiWilayahIndonesiaController(IWilayahIndonesiaInterface dataRepo)
        {
            _dataRepo = dataRepo;
        }


        [HttpGet("provinsi")]
        public ActionResult GetProvinsi(string Id)
        {
            IProvinsi provinsi = new();
            try
            {
                if (!int.TryParse(Id, out int ProvinsiIdCheck) && !string.IsNullOrEmpty(Id))
                {
                    provinsi.Deskripsi = string.Format("Nilai {0} tidak valid", Id);
                    provinsi.Kode = StatusCodes.Status400BadRequest;
                    provinsi.Provinsi = new();

                    return BadRequest(provinsi);
                }

                int? idProvinsi = string.IsNullOrEmpty(Id) ? null: ProvinsiIdCheck;

                List<ProvinsiList> provinsiLists = _dataRepo.GetAllProvinsi(idProvinsi);
                if(provinsiLists.Count > 0)
                {
                    provinsi.Deskripsi = "OK";
                    provinsi.Kode = StatusCodes.Status200OK;
                    provinsi.Provinsi = provinsiLists;

                    return Ok(provinsi);
                }
                else
                {
                    provinsi.Deskripsi = "Data tidak ditemukan";
                    provinsi.Kode = StatusCodes.Status404NotFound;
                    provinsi.Provinsi = new();

                    return NotFound(provinsi);
                }
            }
            catch
            {
                provinsi.Deskripsi = "Terjadi kesalahan saat memproses permintaan";
                provinsi.Kode = StatusCodes.Status500InternalServerError;
                provinsi.Provinsi = new();

                return StatusCode(StatusCodes.Status500InternalServerError, provinsi);
            }
            
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
                    kota.Kode = StatusCodes.Status400BadRequest;
                    kota.Kota = new();

                    return BadRequest(kota);
                }

                List<KotaList> kotaLists = _dataRepo.GetKota(idProvinsi);
                if (kotaLists.Count > 0)
                {
                    kota.Deskripsi = "OK";
                    kota.Kode = StatusCodes.Status200OK;
                    kota.Kota = kotaLists;

                    return Ok(kota);
                }
                else
                {
                    kota.Deskripsi = "Data tidak ditemukan";
                    kota.Kode = StatusCodes.Status404NotFound;
                    kota.Kota = new();

                    return NotFound(kota);
                }
            }
            catch
            {
                kota.Deskripsi = "Terjadi kesalahan saat memproses permintaan";
                kota.Kode = StatusCodes.Status500InternalServerError;
                kota.Kota = new();

                return StatusCode(StatusCodes.Status500InternalServerError, kota);
            }
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
                    kecamatan.Kode = StatusCodes.Status400BadRequest;
                    kecamatan.Kecamatan = new();

                    return BadRequest(kecamatan);
                }

                List<KecamatanList> kecamatanLists = _dataRepo.GetKecamatan(kotaId);

                if (kecamatanLists.Count > 0)
                {
                    kecamatan.Deskripsi = "OK";
                    kecamatan.Kode = StatusCodes.Status200OK;
                    kecamatan.Kecamatan = kecamatanLists;


                    return Ok(kecamatan);
                }
                else
                {
                    kecamatan.Deskripsi = "Data tidak ditemukan";
                    kecamatan.Kode = StatusCodes.Status404NotFound;
                    kecamatan.Kecamatan = new();

                    return NotFound(kecamatan);
                }
            }
            catch
            {
                kecamatan.Deskripsi = "Terjadi kesalahan saat memproses permintaan";
                kecamatan.Kode = 500;
                kecamatan.Kecamatan = new();

                return StatusCode(StatusCodes.Status500InternalServerError, kecamatan);
            }
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
                    kelurahan.Kode = StatusCodes.Status400BadRequest;
                    kelurahan.Kelurahan = new();

                    return BadRequest(kelurahan);
                }

                List<KelurahanList> kelurahanLists = _dataRepo.GetKelurahan(kecamatanId);

                if (kelurahanLists.Count > 0)
                {
                    kelurahan.Deskripsi = "OK";
                    kelurahan.Kode = StatusCodes.Status200OK;
                    kelurahan.Kelurahan = kelurahanLists;

                    return Ok(kelurahan);
                }
                else
                {
                    kelurahan.Deskripsi = "Data tidak ditemukan";
                    kelurahan.Kode = StatusCodes.Status404NotFound;
                    kelurahan.Kelurahan = new();

                    return NotFound(kelurahan);
                }
            }
            catch
            {
                kelurahan.Deskripsi = "Terjadi kesalahan saat memproses permintaan";
                kelurahan.Kode = StatusCodes.Status500InternalServerError;
                kelurahan.Kelurahan = new();

                return StatusCode(StatusCodes.Status500InternalServerError, kelurahan);
            }
        }
    }

    
}
