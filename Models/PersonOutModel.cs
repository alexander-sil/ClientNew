namespace Client.Models
{
    public class PersonOutModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Class { get; set; }

        public string Building { get; set; }

        public override string ToString()
        {
            return $"МЧ {Id} Им {Name} Кл {Class} Зд {Building}";
        }
    }
}

