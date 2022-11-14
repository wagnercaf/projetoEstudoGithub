using codigonaveia.services.cursos.WebApplication.Models;
using Refit;
using System.Diagnostics;

namespace codigonaveia.services.cursos.WebApplication.Interfaces
{
    public interface ICursosRepository
    {
        [Post("/Register")]
        Task Registrar(CursosViewModel mod);

        [Get("/ObterTodosCursos")]
        Task<IEnumerable<CursosViewModel>> ObterCursos();

        [Delete("/Delete/{Id}")]
        Task Delete(int Id);

        [Get("/ObterCursoPorId/{Id}")]
        Task<CursosViewModel> ObterCursosPorId(int Id);

        [Put("/{Id}")]
        Task Update(int Id, CursosViewModel mod);

    }
}
