using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO3A28.DTO
{
    class MusicaDTO
    {
        private int idMusica, idCD, idGravadora;
        private string nome, nomeAutor;

        public int IdMusica { get => idMusica; set => idMusica = value; }

        public string Nome { get => nome; set => nome = value; }
        public string NomeAutor { get => nomeAutor; set => nomeAutor = value; }
        public int IdCD { get => idCD; set => idCD = value; }
        public int IdGravadora { get => idGravadora; set => idGravadora = value; }
    }
}
