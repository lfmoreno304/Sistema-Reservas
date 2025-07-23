using Microsoft.EntityFrameworkCore;
using ReservaInteligente.Models.Entities;
namespace ReservaInteligente.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Schedules> Schedules { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Administrador" },
                new Role { Id = 2, Name = "Usuario" },
                new Role { Id = 3, Name = "Medico" });
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Admin", Email = "admin@gmail.com", Password = "123456", RoleId = 1 });
            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, Name = "Nutrición", Description = "Cita de nutrición" },
                new Service { Id = 2, Name = "Psicología", Description = "Cita de psicología" },
                new Service { Id = 3, Name = "Medicina General", Description = "Cita de medicina general" });
        }
    }
}

