using Microsoft.EntityFrameworkCore;

namespace CarShowRoomProject.Models
{
    public class CarShowRoomDbContext : DbContext
    {
        public CarShowRoomDbContext(DbContextOptions<CarShowRoomDbContext> options) : base(options) { }

        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<BookedCar> BookedCar { get; set; }
        public DbSet<BrandCar> BrandCar { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<ModelCar> ModelCar { get; set; }
        public DbSet<PictureCar> PictureCar { get; set; }
        public DbSet<TransmissionCar> TransmissionCar { get; set; }
        public DbSet<TypeEngine> TypeEngine { get; set; }
        public DbSet<YearRelease> YearRelease { get; set; }
    }
}
