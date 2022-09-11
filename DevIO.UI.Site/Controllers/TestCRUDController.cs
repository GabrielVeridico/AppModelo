using DevIO.UI.Site.Data;
using DevIO.UI.Site.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.UI.Site.Controllers
{
    public class TestCRUDController : Controller
    {
        private readonly MeuDbContext _contexto;

        public TestCRUDController(MeuDbContext context)
        {
            _contexto = context;
        }

        public IActionResult Index()
        {
            var aluno = new Aluno()
            {
                Nome = "Gabriel",
                DataNascimento = DateTime.Now,
                Email = "gabriel@email.com"
            };

            _contexto.Alunos.Add(aluno);
            _contexto.SaveChanges();

            var alunoTabela = _contexto.Alunos.Find(aluno.Id);
            var alunoTabela2 = _contexto.Alunos.FirstOrDefault(at => at.Email == aluno.Email);
            var alunoTabela3 = _contexto.Alunos.Where(at => at.Nome == "Gabriel");

            aluno.Nome = "João";

            _contexto.Alunos.Update(aluno);
            _contexto.SaveChanges();

            _contexto.Alunos.Remove(aluno);
            _contexto.SaveChanges();
            return View();
        }
    }
}
