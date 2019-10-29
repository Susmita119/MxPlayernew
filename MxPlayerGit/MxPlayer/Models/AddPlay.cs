using System;
using System.Collections.Generic;

namespace MxPlayer.Models

{
    public partial class AddPlay
    {
        public int PlayId { get; set; }
        public int? Id { get; set; }
        public string PlaySongs { get; set; }

        public virtual SongsTable IdNavigation { get; set; }
    }
}
