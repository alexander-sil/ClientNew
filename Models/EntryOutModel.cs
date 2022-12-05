using System;

namespace Client.Models
{
    public class EntryOutModel
    {
        public int Id { get; set; }

        public string State { get; set; }

        public string Name { get; set; }

        public uint Quantity { get; set; }

        public string Unit { get; set; }

        public string Description { get; set; }

        public string Owner { get; set; }

        public List<PersonOutModel>? BorrowingPeople { get; set; }

        public override string ToString()
        {
            return $"МЧ {Id} Назв {Name} Числ.вз {BorrowingPeople.Count}";
        }
    }
}

