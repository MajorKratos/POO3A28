using POO3A28.DAL;
using POO3A28.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO3A28.BLL
{
    class tbl_MusicaBLL
    {
        // Conectar com o banco de dados
        DALBD daoBanco = new DALBD();

        // Criar os metodos da classe
        // CRUD - Inserir - Pesquisar - Alterar - Deletar
        public DataTable PesquisarMusica(string condicao)
        {
            string sql = string.Format($@"select * from TBL_Musica where " + condicao);
            return daoBanco.ExecutarConsulta(sql);
        }
        public DataTable PesquisarMusica()
        {
            string sql = string.Format($@"select * from TBL_Musica");
            return daoBanco.ExecutarConsulta(sql);
        }
        public void InserirMusica(MusicaDTO ObjCliente)
        {
            string sql = string.Format($@"INSERT INTO TBL_Musica VALUES (NULL, '{ObjCliente.Nome}',
                                                                               '{ObjCliente.NomeAutor}',
                                                                               '{ObjCliente.IdGravadora}',
                                                                               '{ObjCliente.IdCD}');");
            daoBanco.ExecutarComando(sql);
        }
        public void AlterarMusica(MusicaDTO ObjCliente)
        {
            string sql = string.Format($@"UPDATE TBL_Musica set nome ='{ObjCliente.Nome}',
                                                                nomeAutor ='{ObjCliente.NomeAutor}',
                                                                idGravadora ='{ObjCliente.IdGravadora}',
                                                                idCD ='{ObjCliente.IdCD}' where idMusica ='{ObjCliente.IdMusica}';");
            daoBanco.ExecutarComando(sql);
        }
        public void ExcluirMusica(MusicaDTO objCliente)
        {
            string sql = string.Format($@"DELETE FROM TBL_Musica where idMusica = {objCliente.IdMusica};");
            daoBanco.ExecutarComando(sql);
        }
    }
}
