﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessObjects
{
    public class CentroDeServicio
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
    }
}
