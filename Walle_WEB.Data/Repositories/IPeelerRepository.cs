using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Walle_WEB.Model;


namespace Walle_WEB.Data.Repositories
{
    public interface IPeelerRepository
    {
        Task<IEnumerable<PeelerBitacora>> GetAllPeeler();
        Task<PeelerBitacora> GetPeelerDetails(int id);
        Task<bool> InsertPeeler(PeelerBitacora peelerbitacora);
        Task<bool> UpdatePeeler(PeelerBitacora peelerbitacora);
        Task<bool> DeletePeeler(int id);

    }
}