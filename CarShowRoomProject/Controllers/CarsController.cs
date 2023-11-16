using AutoMapper;
using CarShowRoomProject.DTO;
using CarShowRoomProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarShowRoomProject.Controllers
{
    [Route("api/Cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarShowRoomDbContext _context;
        private readonly IMapper _mapper;

        public CarsController(CarShowRoomDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetCars")]
        public async Task<ActionResult<IEnumerable<CarDTO>>> GetCars()
        {
            try
            {
                var cars = await _context.Car.ToListAsync();

                if (cars == null)
                {
                    return NotFound();
                }

                var carDtos = await _context.Car
                    .Include(c => c.BrandCar)
                    .Include(c => c.YearRelease)
                    .Include(c => c.TypeEngine)
                    .Include(c => c.TransmissionCar)
                    .Include(c => c.PictureCar)
                    .Select(car => new CarDTO
                    {
                        CarId = car.CarId,
                        BrandCar = car.BrandCar.BrandCarName,
                        ModelCar = car.BrandCar.ModelCar.ModelCarName,
                        YearRelease = car.YearRelease.YearReleaseName,
                        TypeEngine = car.TypeEngine.TypeEngineName,
                        TransmissionCar = car.TransmissionCar.TransmissionCarName,
                        Price = car.Price,
                        Mileage = car.Mileage,
                        Power = car.Power,
                        EngineCapacity = car.EngineCapacity,
                        PictureOne = car.PictureCar.PictureOne,
                        PictureTwo = car.PictureCar.PictureTwo,
                        PictureThree = car.PictureCar.PictureThree,
                    })
                    .ToListAsync();

                return carDtos;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDTO>> GetCar(int id)
        {
            try
            {
                var carDtos = await _context.Car
                    .Include(c => c.BrandCar)
                    .Include(c => c.YearRelease)
                    .Include(c => c.TypeEngine)
                    .Include(c => c.TransmissionCar)
                    .Include(c => c.PictureCar)
                    .Select(car => new CarDTO
                    {
                        CarId = car.CarId,
                        BrandCar = car.BrandCar.BrandCarName,
                        ModelCar = car.BrandCar.ModelCar.ModelCarName,
                        YearRelease = car.YearRelease.YearReleaseName,
                        TypeEngine = car.TypeEngine.TypeEngineName,
                        TransmissionCar = car.TransmissionCar.TransmissionCarName,
                        Price = car.Price,
                        Mileage = car.Mileage,
                        Power = car.Power,
                        EngineCapacity = car.EngineCapacity,
                        PictureOne = car.PictureCar.PictureOne,
                        PictureTwo = car.PictureCar.PictureTwo,
                        PictureThree = car.PictureCar.PictureThree,
                    }).FirstOrDefaultAsync(c => c.CarId == id);

                if (carDtos == null)
                {
                    return NotFound();
                }

                return carDtos;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
