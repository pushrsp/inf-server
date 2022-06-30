using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.DB
{
    [Table("Account")]
    public class AccountDb
    {
        public int AccoutDbId { get; set; }
        public string AccountName { get; set; }
        public ICollection<PlayerDb> Players { get; set; }
    }

    [Table("Player")]
    public class PlayerDb
    {
        public int PlayerDbId { get; set; }
        public string PlayerName { get; set; }
        public AccountDb Account { get; set; }
    }
}