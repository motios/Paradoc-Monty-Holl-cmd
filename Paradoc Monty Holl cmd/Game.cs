namespace Paradoc_Monty_Holl_cmd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Game
    {
        public long ID { get; set; }

        public bool? is_need_to_change_room { get; set; }

        public int? door_with_prize { get; set; }

        public int? door_selected_by_gamer_start { get; set; }

        public int? door_selected_by_gamer_final { get; set; }

        public bool? game_winner { get; set; }

        public DateTime? game_start_time { get; set; }

        public DateTime? game_end_time { get; set; }

        [StringLength(1000)]
        public string notes { get; set; }
    }
}
