namespace Gestor_de_tareas.Models
{
    public class User
    {
        public int Id_user{ get; set; }
        public string Username { get; set; }

        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
