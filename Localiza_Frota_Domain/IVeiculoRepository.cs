using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localiza_Frotas_Domain
{
    public interface IVeiculoRepository
    {
        Veiculo GetById(Guid Id);
        IEnumerable<Veiculo> GetAll();
        void Add(Veiculo veiculo);
        void Delete(Veiculo veiculo);
        void Update(Veiculo veiculo);
        
    }
}
