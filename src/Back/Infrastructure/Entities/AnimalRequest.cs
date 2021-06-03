using System;

namespace Infrastructure.Entities
{
    public class AnimalRequest
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string Message { get; set; }
        public string ContactInfo { get; set; }

        public int AnimalId { get; set; }
        public Animal Animal { get; set; }

        public DateTime Date { get; set; }
    }
}