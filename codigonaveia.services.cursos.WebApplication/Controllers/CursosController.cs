﻿using codigonaveia.services.cursos.WebApplication.enumVerbs;
using codigonaveia.services.cursos.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace codigonaveia.services.cursos.WebApplication.Controllers
{
    public class CursosController : Controller
    {
        readonly string apiUri;
        private readonly IConfiguration _config;

        public CursosController(IConfiguration config)
        {
            _config = config;
            apiUri = _config.GetValue<string>("Uri");
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListaCursos()
        {
            return View(await GetCursos());
        }

        public async Task<IEnumerable<CursosViewModel>?> GetCursos()
        {
            using (HttpClient httpclient = new HttpClient())
            {
                var cursos = new CursosViewModel();
                HttpResponseMessage response = await httpclient.GetAsync(apiUri + enumActions.ObterTodosCursos);
                if (response.IsSuccessStatusCode)
                {
                    var dados = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<CursosViewModel>>(dados);

                }
                return new List<CursosViewModel>(); 
            }
        }
    }
}
