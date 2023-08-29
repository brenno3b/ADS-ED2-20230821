using ADS_ED2_20230821.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS_ED2_20230821.Controllers
{
    internal class ContatoController
    {
        private string _email;
        private string _nome;
        private DataController _dtNasc;
        private List<TelefoneModel> _telefones;

        public string Email { get { return _email; } }
        public string Nome { get { return _nome; } }
        public DataController DtNasc { get { return _dtNasc; } }
        public List<TelefoneModel> Telefones { get { return _telefones; } }

        public ContatoController(string email, string nome, DataController dtNasc, List<TelefoneModel> telefones)
        {
            _email = email;
            _nome = nome;
            _dtNasc = dtNasc;
            _telefones = telefones;
        }

        public ContatoController(string email)
        {
            _email = email;
            _nome = "";
            _dtNasc = new DataController();
            _telefones = new List<TelefoneModel>();
        }

        public ContatoController()
        {
            _email = "";
            _nome = "";
            _dtNasc = new DataController();
            _telefones = new List<TelefoneModel>();
        }

        public int getIdate()
        {
            return -1;
        }

        public void adicionarTelefone(TelefoneModel t)
        {
            _telefones.Add(t);
        }

        public string getTelefonePrincipal()
        {
            int i = 0;

            while (i < _telefones.Count && !_telefones[i].Principal)
            {
                i++;
            }

            if (i < _telefones.Count)
            {
                return _telefones[i].Numero;
            }

            return "";
        }

        public override string? ToString()
        {
            return $"Email: {_email}, Nome: {_nome}, DtNasc: {_dtNasc}, Telefone principal: {getTelefonePrincipal()}";
        }

        public override bool Equals(object? obj)
        {
            return obj is ContatoController controller &&
                   _email == controller._email &&
                   _nome == controller._nome &&
                   EqualityComparer<DataController>.Default.Equals(_dtNasc, controller._dtNasc) &&
                   EqualityComparer<List<TelefoneModel>>.Default.Equals(_telefones, controller._telefones);
        }
    }
}
