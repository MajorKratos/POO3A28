using POO3A28.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO3A28.BLL
{
    class tbl_GravadoraBLL
    {
        private DALBD daoBanco = new DALBD();

        public DataTable ListarGravadora()
        {
            string sql = string.Format($@"select * from TBL_Gravadora");
            return daoBanco.ExecutarConsulta(sql);
        }
    }
}
