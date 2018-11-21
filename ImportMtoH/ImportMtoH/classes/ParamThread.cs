using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportMtoH.classes
{
    class ParamThread
    {
        private String Instancia, NomeServe;
        private bool? checkEntidade, checkProd,checkDoc,checkFilial;

        public string Instancia1 { get => Instancia; set => Instancia = value; }
        public string NomeServe1 { get => NomeServe; set => NomeServe = value; }
        public bool? CheckEntidade { get => checkEntidade; set => checkEntidade = value; }
        public bool? CheckProd { get => checkProd; set => checkProd = value; }
        public bool? CheckDoc { get => checkDoc; set => checkDoc = value; }
        public bool? CheckFilial { get => checkFilial; set => checkFilial = value; }
    }
}
