using Microsoft.EntityFrameworkCore;

namespace Projetinho 
{
    public class UsuarioRepository
    {
        public static void Save(Usuario usuario)
        {
            try
            {
                using (Repository repo = new Repository())
                {
                    if (usuario.Id == 0)
                    {
                        repo.Usuarios.Add(usuario);
                    }
                    else
                    {
                        repo.Entry(usuario).State = EntityState.Modified;
                    }
                    repo.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Usuario> FindAll()
        {
            using (Repository repo = new Repository())
            {
                return repo.Usuarios.ToList();
            }
        }

        public static Usuario FindbyId(int id)
        {
            using (Repository repo = new Repository())
            {
                return repo.Usuarios.Find(id);
            }
        }

        public static void Remove(Usuario usuario)
        {
            using (Repository repo = new Repository())
            {
                repo.Usuarios.Attach(usuario);
                repo.Usuarios.Remove(usuario);
                repo.SaveChanges(); //Foda ai em the goat
            }
        }
        public static Usuario FindByIdWCredencial(UInt64 id)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Usuarios
                        .Include("Credencial")
                        .Where(u => u.Id == id)
                        .FirstOrDefault<Usuario>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Usuario> FindByPartialName(String partialName)
        {
            try
            {
                using (Repository dbContext = new Repository())
                {
                    return dbContext.Usuarios
                        .Where(u => u.Nome.Contains(partialName))
                        .ToList<Usuario>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Usuario Autenticar(String email, String senha)
        {
            try
            {
                using (Repository repo = new Repository())
                {
                    return repo.Usuarios
                        .Include("Credencial")
                        .Where(u => u.Credencial.Email == email &&
                               u.Credencial.Senha == senha)
                        .FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
