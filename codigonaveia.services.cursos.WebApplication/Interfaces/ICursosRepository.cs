using codigonaveia.services.cursos.WebApplication.Models;
using Refit;

namespace codigonaveia.services.cursos.WebApplication.Interfaces
{
    public interface ICursosRepository
    {
        [Post("/Register")]
        Task Registrar(CursosViewModel mod);

        [Get("/ObterTodosCursos")]
        Task<IEnumerable<CursosViewModel>> ObterCursos();
    }
}
