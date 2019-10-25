using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using TaCertoForms.Attributes;
using TaCertoForms.Models;
using TaCertoForms.Contexts;
using TaCertoForms.Controllers.Base;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace TaCertoForms.Controllers
{
    [SomenteLogado]
    public class MidiaController : ControladoraBase {
        private TipoMidia GetTipoArquivo(string contentType)
        {
            switch (contentType)
            {
                case "image/png":
                case "image/jpg":
                case "image/jpeg":
                    return TipoMidia.Imagem;
                case "ytb":
                    return TipoMidia.YouTube;
                default: return TipoMidia.Indefinido;
            }
        }

        public JsonResult Index(int IdOrigem, string Tabela)
        {            
            return Json(db.Midia.Where(x => x.IdOrigem == IdOrigem && x.Tabela == Tabela).ToList(), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public async Task<JsonResult> Save(int id, string tabela) {            
            try
            {                   
                List<Midia> arquivos = new List<Midia>();                
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                    var hash = Guid.NewGuid();
                    if (file != null && file.ContentLength > 0)
                    {
                        Midia fileDetail = new Midia()
                        {
                            IdMidia = hash,
                            IdOrigem = id,
                            Tabela = tabela,
                            Filename = Path.GetFileName(file.FileName),
                            Extensao = Path.GetExtension(Path.GetFileName(file.FileName)),
                            Tipo = GetTipoArquivo(file.ContentType)
                        };
                        arquivos.Add(fileDetail);
                        string caminho = System.Web.HttpContext.Current.Server.MapPath("~/Content/images/upload/" + tabela + '/');

                        var path = Path.Combine(caminho, fileDetail.IdMidia + fileDetail.Extensao);
                        if (!Directory.Exists(caminho))
                        {
                            Directory.CreateDirectory(caminho);
                        }
                        file.SaveAs(path);
                        db.Midia.Add(fileDetail);
                        db.SaveChanges();
                    }
                    if (tabela == "Instituicao" || tabela == "Pessoa" || tabela == "Questao")
                    { //Caso tenha alguma mídia já salva
                        Midia DeleteMidia = db.Midia.Where(x => x.IdOrigem == id && x.Tabela == tabela && x.IdMidia != hash).FirstOrDefault();
                        if (DeleteMidia != null)
                        {
                            Delete(DeleteMidia.IdMidia);
                        }
                    }
                }                              
                return Json(arquivos);
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Erro no upload");
            }
        }

        public bool Delete(Guid id)
        {
            Midia midia = db.Midia.Find(id);
            if (midia != null)
            {
               //Deletando arquivo
                var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/images/upload/" + midia.Tabela + '/'), midia.IdMidia + midia.Extensao);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                db.Midia.Remove(midia);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}