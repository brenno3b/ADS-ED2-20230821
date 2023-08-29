using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS_ED2_20230821.Controllers
{
    internal class ContatosController
    {
        private readonly List<ContatoController> _agenda;

        public List<ContatoController> Agenda { get { return _agenda; } }

        public ContatosController(List<ContatoController> agenda)
        {
            _agenda = agenda;
        }

        public ContatosController()
        {
            _agenda = new List<ContatoController>();
        }

        public bool Adicionar(ContatoController c)
        {
            if (_agenda.Contains(c))
            {
                return false;
            }

            _agenda.Add(c);

            return true;
        }

        public ContatoController pesquisar(ContatoController c)
        {
            int i = 0;

            while (i < _agenda.Count && c.Email != _agenda[i].Email)
            {
                i++;
            }

            if (i < _agenda.Count) { return _agenda[i]; }

            return new ContatoController();
        }

        public bool alterar(ContatoController c)
        {
            int index = _agenda.IndexOf(c);

            if (index == -1) { return false; }

            _agenda[index] = c;

            return true;
        }

        public bool remover(ContatoController c)
        {
            int index = _agenda.IndexOf(c);

            if (index == -1) { return false; }

            _agenda.RemoveAt(index);

            return true;
        }
    }
}
