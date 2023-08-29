using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS_ED2_20230821.Models
{
    internal class TelefoneModel
    {
        private string _tipo;
        private string _numero;
        private bool _principal;

        public string Tipo { get { return _tipo; } }
        public string Numero { get { return _numero; } }
        public bool Principal { get { return _principal; } }

        public TelefoneModel(string tipo, string numero, bool principal)
        {
            _tipo = tipo;
            _numero = numero;
            _principal = principal;
        }

        public TelefoneModel()
        {
            _tipo = "";
            _numero = "";
            _principal = false;
        }
    }
}
