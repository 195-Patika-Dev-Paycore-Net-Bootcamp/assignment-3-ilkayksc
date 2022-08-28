using Microsoft.AspNetCore.Mvc;
using PatikaPaycoreBootcampHW3.Context;
using PatikaPaycoreBootcampHW3.Model;
using System;
using System.Collections.Generic;

using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PatikaPaycoreBootcampHW3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMapperSession session;
        public VehicleController(IMapperSession session)
        {
            this.session = session;
        }

        // Tüm araç kayıtlarını listeleyen endpoint
        [HttpGet]
        public ActionResult<List<Vehicle>> Get()
        {   // tüm araçları listeliyoruz.
            List<Vehicle> vehicles = session.Vehicles.ToList();
            // Eğer liste boş gelirse NotFound Error döndürüyoruz.
            return vehicles == null ? NotFound() : Ok(vehicles);
        }

        // İstenilen aracın id değerine göre filtreleyip listeleyen endpoint
        [HttpGet("GetVehicleById")]
        public ActionResult<Vehicle> Get([FromQuery]int id)
        {   // aracı id değerine göre arayıp listeliyoruz.
            Vehicle vehicle = session.Vehicles.Where(x=>x.Id == id).FirstOrDefault();
            // Eğer liste boş gelirse NotFound Error döndürüyoruz.
            return vehicle == null ? NotFound() : Ok(vehicle);
        }
        // Yeni araç kaydı için endpoint
        [HttpPost]
        public ActionResult Post([FromBody] Vehicle request)
        {
            try
            {   // Transaction başlatıp kaydı ekledik.
                session.BeginTransaction();
                session.Save(request);
                session.Commit();
            }
            catch (Exception ex)
            {   // Herhangi bir hata olması durumunda yapılan işlemleri geri aldık ve hata döndürdük.
                session.Rollback();
                return BadRequest(ex.Message);
          
            }
            finally
            {   // süreci sonlandırdık.
                session.CloseTransaction();
            }
            return Ok();
        }

        // Araç kaydını güncelleyen endpoint
        [HttpPut("{id}")]
        public ActionResult<Vehicle> Put([FromBody] Vehicle request)
        {   // istenilen kaydı bulup listeledik.
            Vehicle vehicle = session.Vehicles.Where(x => x.Id == request.Id).FirstOrDefault();
            if (vehicle == null)
            {   // Kaydı bulamadığı için NotFound hatası döndük.
                return NotFound();
            }
            try
            {   // süreci başlattık ve kaydı güncelledik.
                session.BeginTransaction();
                vehicle.VehicleName = request.VehicleName;
                vehicle.VehiclePlate = request.VehiclePlate;
                session.Save(vehicle);
                session.Commit();
            }
            catch(Exception ex)
            {   // Herhangi bir hata olması durumunda yapılan işlemleri geri aldık ve hata döndürdük.
                session.Rollback();
                return BadRequest(ex.Message);
            }
            finally
            {   // süreci sonlandırdık.
                session.CloseTransaction();
            }

            return Ok();
        }

        // İstenilen araç kaydını silen endpoint
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {   
            // istenilen kaydı bulup listeledik.
            Vehicle vehicle = session.Vehicles.Where(x => x.Id == id).FirstOrDefault();
            List<Container> containers = session.Containers.Where(x => x.VehicleId == id).ToList();
            if (vehicle == null)
            {   // Kaydı bulamadığı için NotFound hatası döndük.
                return NotFound();
            }

            try
            {
                // süreci başlattık ve kaydı güncelledik.
                session.BeginTransaction();
                session.Delete(vehicle);
                session.Commit();
            }
            catch
            {
                // Herhangi bir hata olması durumunda yapılan işlemleri geri aldık ve hata döndürdük.
                session.Rollback();
                return BadRequest();
            }
            finally
            {   // süreci sonlandırdık.
                session.CloseTransaction();
            }

            return Ok();
        }
    }
}
