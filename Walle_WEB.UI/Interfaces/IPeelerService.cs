using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Walle_WEB.Model;

namespace Walle_WEB.UI.Interfaces
{
    public interface IPeelerService
    {
        Task<IEnumerable<PeelerBitacora>> GetAllPeeler();
        Task<PeelerBitacora> GetPeelerDetails(int id);
        Task SavePeeler(PeelerBitacora peelerbitacora);
        Task DeletePeeler(int id);
    }
}
