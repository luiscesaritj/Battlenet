using System.ComponentModel.DataAnnotations;

namespace Battlenet.Web.Data.Models
{
    public class Character
    {
        [Key]
        public string CharacterId { get; set; }
        public string CharacterName { get; set; }
        public int CharacterLevel { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
