using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStorePractice.Models
{
    public class Artist
    {
        public int ArtistID { get; set; }
        public string Name { get; set; }

        public ICollection<Album>? Albums { get; set; }
    }
}
