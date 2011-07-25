using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessObjects
{
   public class metrica1
    {

        int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        string _numero;

        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
        DateTime? _fecha;

        public DateTime? Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        bool _exceptuado;

        public bool Exceptuado
        {
            get { return _exceptuado; }
            set { _exceptuado = value; }
        }
        string _observacion;

        public string Observacion
        {
            get { return _observacion; }
            set { _observacion = value; }
        }

    }
}
