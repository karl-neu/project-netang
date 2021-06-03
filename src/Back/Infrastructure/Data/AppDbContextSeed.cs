using Infrastructure.Entities;
using System.Linq;

namespace Infrastructure.Data
{
    public class AppDbContextSeed
    {
        public AppDbContextSeed(AppDbContext context)
        {
            if (context.Animals.Any()) return;

            var animals = new Animal[]
            {
                new Animal{Name="Bobik", Breed="Buldog"},
                new Animal{Name="Murzik", Breed="Sfinx"},
                new Animal{Name="Kesha", Breed="Kenor"},
            };

            context.Animals.AddRange(animals);
            context.SaveChanges();
        }
    }
}