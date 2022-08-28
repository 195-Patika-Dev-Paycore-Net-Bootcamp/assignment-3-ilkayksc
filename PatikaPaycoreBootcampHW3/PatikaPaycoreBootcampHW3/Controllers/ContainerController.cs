using Microsoft.AspNetCore.Mvc;
using PatikaPaycoreBootcampHW3.Context;
using PatikaPaycoreBootcampHW3.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PatikaPaycoreBootcampHW3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly IMapperSession session;
        public ContainerController(IMapperSession session)
        {
            this.session = session;
        }

        // Tüm containerlerin listesini veren endpoint.
        [HttpGet]
        public ActionResult<List<Container>> Get()
        {   // Tüm araç kayıtlarını listeledik.
            List<Container> containers = session.Containers.ToList();
            // Eğer liste boş gelirse NotFound Error döndürüyoruz.
            return containers == null ? NotFound() : Ok(containers);
        }

        // İstenilen containerı id değerine göre filtreleyip listeleyen endpoint
        [HttpGet("GetContainerById")]
        public ActionResult<Container> GetContainerById([FromQuery] int id)
        {   // containerı id değerine göre arayıp listeliyoruz.
            Container container = session.Containers.Where(x => x.Id == id).FirstOrDefault();
            // Eğer liste boş gelirse NotFound Error döndürüyoruz.
            return container == null ? NotFound() : Ok(container);
        }

        // Yeni container eklemek için endpoint
        [HttpPost]
        public ActionResult<List<Container>> Post([FromBody] Container request)
        {
            try
            {   // Transaction başlatıp kaydı ekledik.
                session.BeginTransaction();
                session.Save(request);
                session.Commit();
            }
            catch (Exception ex)
            {    // Herhangi bir hata olması durumunda yapılan işlemleri geri aldık ve hata döndürdük.
                session.Rollback();
                return BadRequest(ex.Message);
            }
            finally
            {    // süreci sonlandırdık.
                session.CloseTransaction();
            }
           
            return Ok();
        }

        // Container kaydını güncellemek için endpoint
        [HttpPut("{id}")]
        public ActionResult<Container> Put(int id, [FromBody] Container request)
        {   // istenilen kaydı bulup listeledik.
            Container container = session.Containers.Where(x => x.Id == request.Id).FirstOrDefault();
            if (container == null)
            {   // Kaydı bulamadığı için NotFound hatası döndük.
                return NotFound();
            }
            try
            {   // süreci başlattık ve kaydı güncelledik.
                session.BeginTransaction();
                container.ContainerName = request.ContainerName;
                container.Latitude = request.Latitude;
                session.Save(container);
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

        // Container kaydının silinmesi için endpoint
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {   // istenilen kaydı bulup listeledik.
            Container container = session.Containers.Where(x => x.Id == id).FirstOrDefault();
            if (container == null)
            {
                return NotFound();
            }

            try
            {   // süreci başlattık ve kaydı güncelledik.
                session.BeginTransaction();
                session.Delete(container);
                session.Commit();
            }
            catch
            {   // Herhangi bir hata olması durumunda yapılan işlemleri geri aldık ve hata döndürdük.
                session.Rollback();
                return BadRequest();
            }
            finally
            {   // süreci sonlandırdık.
                session.CloseTransaction();
            }

            return Ok();
        }

        // Araca ait tüm containerları listeyen endpoint
        [HttpGet("GetContainersByVehicleId")]
        public ActionResult<List<Container>> GetAllContainersByVehicleId([FromQuery]int vehicleId)
        {
            List<Container> result = session.Containers.Where(x => x.VehicleId == vehicleId).ToList();
            return Ok(result);
        }

        // Araca ait containerları eşit parçalar halinde istenilen sayıda gruba bölen endpoint

        // Örneğin araca ait 8 adet kayıt olduğunu varsayarsak ve bunları 5 adet eşit parçaya bölmek istiyorsak
        // bunları 2-2-2-1-1 şeklinde böler ve grupları liste halinde döner

        [HttpGet("{vehicleId}/{pieces}")]
        public ActionResult<List<List<Container>>> GetContainerPiecesByVehicleId(int vehicleId, int pieces)
        {
            List<Container> result = session.Containers.Where(x => x.VehicleId == vehicleId).ToList();
            List<List<Container>> partitions = new List<List<Container>>(pieces);
            partitions = result.Select((x, i) => new { Index = i, Value = x })
         .GroupBy(x => x.Index % pieces)
         .Select(x => x.Select(v => v.Value).ToList())
         .ToList();

            return Ok(partitions);
        }
    }
}
