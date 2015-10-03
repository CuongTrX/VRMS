namespace VRMS.App_Code.DTO
{
    public class PermissionDTO
    {
        public int IdPermission { get; set; }
        public string Permission { get; set; }
        public PermissionDTO() { }
        public PermissionDTO(int IdPermission, string Permission) {
            this.IdPermission = IdPermission;
            this.Permission = Permission;
        }
    }
}
