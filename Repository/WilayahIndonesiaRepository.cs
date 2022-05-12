using kecamatan.Model;
using provinsi.Model;
using kota.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using kelurahan.Model;
using ApiWilayahIndonesia.Interface;
using Microsoft.AspNetCore.Hosting;

namespace WilayahIndonesia.Repository
{
    public class WilayahIndonesiaRepository : IWilayahIndonesiaInterface
    {
        public readonly IWebHostEnvironment _env;
        public WilayahIndonesiaRepository(IWebHostEnvironment hostEnvironment)
        {
            _env = hostEnvironment;
        }

        #region Provinsi
        public List<ProvinsiList> GetAllProvinsi(int? provinsiid)
        {
            string fileName = Path.Combine(_env.WebRootPath, "csv","provinces.csv");

            List<ProvinsiList> provinsiLists = new();
            if(provinsiid == null)
            {
                provinsiLists = File.ReadAllLines(fileName).Select(a => ReadCsvProvinsi(a)).ToList();
            }
            else
            {
                provinsiLists = File.ReadAllLines(fileName).Select(a => ReadCsvProvinsi(a)).Where(a=> a.Id == provinsiid).ToList();
            }

            return provinsiLists;
        }

        public static ProvinsiList ReadCsvProvinsi(string data)
        {
            string[] values = data.Split(',');

            ProvinsiList provinsi = new();

            provinsi.Id = Convert.ToInt32(values[0]);
            provinsi.Nama = values[1];

            return provinsi;
        }
        #endregion

        #region Kota
        public List<KotaList> GetKota(int provinsiId)
        {
            string fileName = Path.Combine(_env.WebRootPath, "csv", "regencies.csv");

            List<KotaList> kotaLists = new();

            kotaLists = File.ReadAllLines(fileName).Select(a => ReadCsvKota(a)).Where(a => a.ProvinsiId == provinsiId).ToList();

            return kotaLists;
        }

        public static KotaList ReadCsvKota(string dataCsv)
        {
            string[] values = dataCsv.Split(',');

            KotaList kota = new();

            kota.Id = Convert.ToInt32(values[0]);
            kota.ProvinsiId = Convert.ToInt32(values[1]);
            kota.Nama = values[2];

            return kota;
        }
        #endregion

        #region Kecamatan
        public List<KecamatanList> GetKecamatan(int kotaId)
        {
            string fileName = Path.Combine(_env.WebRootPath, "csv", "districts.csv");

            List<KecamatanList> kecamatanLists = new();

            kecamatanLists = File.ReadAllLines(fileName).Select(a => ReadCsvKecamatan(a)).Where(a => a.KotaId == kotaId).ToList();

            return kecamatanLists;
        }

        public static KecamatanList ReadCsvKecamatan(string dataCsv)
        {
            string[] values = dataCsv.Split(',');

            KecamatanList kecamatan = new();

            kecamatan.Id = long.Parse(values[0]);
            kecamatan.KotaId = Convert.ToInt32(values[1]);
            kecamatan.Nama = values[2];

            return kecamatan;
        }
        #endregion

        #region Kelurahan
        public List<KelurahanList> GetKelurahan(long kecamatanId)
        {
            string fileName = Path.Combine(_env.WebRootPath, "csv", "villages.csv");

            List<KelurahanList> kelurahanLists = new();

            kelurahanLists = File.ReadAllLines(fileName).Select(a => ReadCsvKelurahan(a)).Where(a => a.KecamatanId == kecamatanId).ToList();

            return kelurahanLists;
        }

        public static KelurahanList ReadCsvKelurahan(string dataCsv)
        {
            string[] values = dataCsv.Split(',');

            KelurahanList kelurahan = new();

            kelurahan.Id = long.Parse(values[0]);
            kelurahan.KecamatanId = long.Parse(values[1]);
            kelurahan.Nama = values[2];

            return kelurahan;
        }
        #endregion

    }
}
