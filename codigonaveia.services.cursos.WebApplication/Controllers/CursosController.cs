using codigonaveia.services.cursos.WebApplication.enumVerbs;
using codigonaveia.services.cursos.WebApplication.Interfaces;
using codigonaveia.services.cursos.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing.Imaging;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;

namespace codigonaveia.services.cursos.WebApplication.Controllers
{
    public class CursosController : Controller
    {
        readonly string apiUri;
        private readonly IConfiguration _config;
        private readonly ICursosRepository _cursosRepository;

        public CursosController(IConfiguration config ,ICursosRepository cursosRepository)
        {
            _config = config;
            _cursosRepository = cursosRepository;
            apiUri = _config.GetValue<string>("Uri");
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(CursosViewModel mod)
        {
            //using(HttpClient client = new HttpClient())
            //{
            //    StringContent content   = new StringContent(JsonConvert.SerializeObject(mod), Encoding.UTF8,"Application/Json");
            //    string endpoint = apiUri + "/"+ enumActions.Register;
            //    using (var response = await client.PostAsync(endpoint, content))
            //    {
            //        if (response.StatusCode== HttpStatusCode.OK)
            //        {
            //            var result = JsonConvert.SerializeObject(mod);
            //            return RedirectToAction(nameof(ListaCursos));
            //        }
            //        else
            //        {
            //            ModelState.AddModelError("","Erro ao fazer um registro");
            //        }
            //    }
            //}
            //return View();
            await _cursosRepository.Registrar(mod);
            return RedirectToAction(nameof(ListaCursos));
        }

        public async Task<IActionResult> ListaCursos()
        {
            return View(await _cursosRepository.ObterCursos());
            //return View(await GetCursos());
        }

        //public async Task<IEnumerable<CursosViewModel>?> GetCursos()
        //{
        //    using (HttpClient httpclient = new HttpClient())
        //    {
        //        var cursos = new CursosViewModel();
        //        HttpResponseMessage response = await httpclient.GetAsync(apiUri + "/"+ enumActions.ObterTodosCursos);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var dados = await response.Content.ReadAsStringAsync();
        //            return JsonConvert.DeserializeObject<IEnumerable<CursosViewModel>>(dados);

        //        }
        //        return new List<CursosViewModel>(); 
        //    }
        //}
    }
}
