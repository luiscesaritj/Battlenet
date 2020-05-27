using System.ComponentModel.DataAnnotations;

namespace Battlenet.Web.Data.Models
{
    public class Connection
    {
        [Key]
        public string ConnectionId { get; set; }
        public bool ConnectedUser { get; set; }
        public Character Character { get; set; }
        public string CharacterId { get; set; }
    }
}
