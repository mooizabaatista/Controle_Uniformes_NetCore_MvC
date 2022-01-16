using System.Collections.Generic;

namespace Requisicao_RSS.Domain.Entities
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        public string Registro { get; set; }
        public string Nome { get; set; }
        public string Funcao { get; set; }
        public string Turno { get; set; }
        public string BaseCamisa { get; set; }
        public string BaseCalca { get; set; }

        // Relacionamentos
        public virtual IEnumerable<Requisicao> Requisicoes { get; set; }
    }
}
