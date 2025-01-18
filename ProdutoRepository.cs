using Microsoft.EntityFrameworkCore;

namespace Projetinho
{
    public class ProdutoRepository
    {
        public static void Save(Produto produto)
        {
            try
            {
                using (Repository repo = new Repository())
                {
                    if (produto.Id == 0)
                    {
                        repo.Produtos.Add(produto);
                    }
                    else
                    {
                        repo.Entry(produto).State = EntityState.Modified;
                    }
                    repo.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Produto> FindAll()
        {
            using (Repository repo = new Repository())
            {
                return repo.Produtos.ToList();
            }
        }

        public static Produto FindbyId(int id)
        {
            using (Repository repo = new Repository())
            {
                return repo.Produtos.Find(id);
            }
        }

        public static void Remove(Produto produto)
        {
            using (Repository repo = new Repository())
            {
                repo.Produtos.Attach(produto);
                repo.Produtos.Remove(produto);
                repo.SaveChanges();
            }
        }

    }
}
