using System;
using System.Collections.Generic;

namespace MxPlayer.Models
{
    public partial class SongsTable
    {
        public SongsTable()
        {
            AddPlay = new HashSet<AddPlay>();
        }

        public int Id { get; set; }
        public string SongName { get; set; }
        public int? DefaultSequence { get; set; }

        public virtual ICollection<AddPlay> AddPlay { get; set; }
    }
}
