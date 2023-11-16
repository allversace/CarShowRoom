using AutoMapper;
using CarShowRoomProject.DTO;
using CarShowRoomProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CarShowRoomProject.Controllers
{
    [Route("api/BookedCar")]
    [ApiController]
    public class BookedCarController : ControllerBase
    {
        private readonly CarShowRoomDbContext _context;
        private readonly IMapper _mapper;


        public BookedCarController(CarShowRoomDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private Client clientCurrent = new Client();
  
        /// <summary>
        /// Метод POST для создания записи в таблице Client и BookedCar
        /// </summary>
        [HttpPost]
        [Route("PostBookedCar")]
        public async Task<ActionResult<BookedCarDTO>> PostBookedCar(BookedCarDTO bookedCarDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (IsValidNameFormat(bookedCarDto.SecondName) && IsValidNameFormat(bookedCarDto.FirstName) && IsValidNameFormat(bookedCarDto.Surname))
            {
                await ProcessClientAsync(bookedCarDto);
                await ProcessBookedCarAsync(bookedCarDto);

                return Ok();
            }

            return BadRequest();
        }

        private async Task ProcessClientAsync(BookedCarDTO bookedCarDto)
        {
            var numberPhone = bookedCarDto.NumberPhone;

            if (numberPhone[0] == '+')
            {
                numberPhone = numberPhone.Substring(1);
            }

            var checkClient = await _context.Client
                .FirstOrDefaultAsync(x => x.SecondName == bookedCarDto.SecondName && x.FirstName == bookedCarDto.FirstName && x.Surname == bookedCarDto.Surname && x.NumberPhone == numberPhone);

            if (checkClient == null)
            {
                CreateNewClient(bookedCarDto, numberPhone);
            }
            else
            {
                bookedCarDto.ClientId = checkClient.ClientId;
            }

            await _context.SaveChangesAsync();
        }
        
        private void CreateNewClient(BookedCarDTO bookedCarDto, string actualNumber)
        {
            clientCurrent.SecondName = bookedCarDto.SecondName;
            clientCurrent.FirstName = bookedCarDto.FirstName;
            clientCurrent.Surname = bookedCarDto.Surname;
            clientCurrent.NumberPhone = actualNumber;
            _context.Client.Add(clientCurrent);
            bookedCarDto.ClientId = clientCurrent.ClientId;
        }

        private async Task ProcessBookedCarAsync(BookedCarDTO bookedCarDto)
        {
            bookedCarDto.SecondName = bookedCarDto.SecondName;
            bookedCarDto.FirstName = bookedCarDto.FirstName;
            bookedCarDto.Surname = bookedCarDto.Surname;
            bookedCarDto.BookingDate = DateTime.Now;
            bookedCarDto.BookingPrice = bookedCarDto.BookingPrice;
            bookedCarDto.CarId = bookedCarDto.CarId;

            var bookedCar = _mapper.Map<BookedCar>(bookedCarDto);
            _context.BookedCar.Add(bookedCar);
            await _context.SaveChangesAsync();
        }

        private bool IsValidNameFormat(string name)
        {
            return !name.Any(x => Char.IsDigit(x) && Char.IsWhiteSpace(x));
        }
    }
}
