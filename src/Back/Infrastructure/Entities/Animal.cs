using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public ICollection<AnimalRequest> AnimalRequests { get; set; }
    }
}