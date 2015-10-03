namespace VRMS.App_Code.DTO
{
    public class UsersDTO
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int IdPermission { get; set; }
        public string Permission { get; set; }

        public UsersDTO() { }
    }


}
