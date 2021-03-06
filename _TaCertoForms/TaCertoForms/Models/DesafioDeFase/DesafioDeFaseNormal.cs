using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaCertoForms.Models;
using Util;

namespace TaCertoForms.Models{
    public class DesafioDeFaseNormal : IDesafioDeFase{
        private int id;
        [Key]
        public int Id { get{return id;} set{id = value;} }
        private int faseId;
        public int FaseId { get{return faseId;} set{faseId = value;} }
        private string significado;
        public string Significado { get{return significado;} set{significado = value;} }
        private string dica;
        public string Dica { get{return dica;} set{dica = value;} }
        public string Palavra { get; set; }
        public bool eCorreto { get; set; }
    }
    
}