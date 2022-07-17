using dp.business.Enums;

namespace dp.business.Models
  
{
    public class Member
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Membership Membership { get; set; }
        
    }
}