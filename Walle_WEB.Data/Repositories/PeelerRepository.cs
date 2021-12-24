using Walle_WEB.Model;
using Dapper;
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Walle_WEB.Data.Repositories
{
    public class PeelerRepository : IPeelerRepository
    {
        public string Message { get; set; }
        private SqlConfiguration _connectionString;

        public PeelerRepository(SqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected SqlConnection dbConnection()
        {
            return new SqlConnection(_connectionString.ConnectionString);
        }

        public  async Task<bool> DeletePeeler(int id)
        {
            var db = dbConnection();

            var sql = @"DELETE PeelerBitacora
                        WHERE IdPeeler = @IdPeeler ";

            var result = await db.ExecuteAsync(sql, new { IdPeeler = id });

            return result > 0;
        }

        public async Task<IEnumerable<PeelerBitacora>> GetAllPeeler()
        {
            var db = dbConnection();

            var sql = @" SELECT IdPeeler, NoDeLote 
                         FROM PeelerBitacora ";

            return await db.QueryAsync<PeelerBitacora>(sql, new { });
        }

        public async Task<PeelerBitacora> GetPeelerDetails(int id)
        {
            var db = dbConnection();

            var sql = @" SELECT IdPeeler, NoDeLote 
                         FROM PeelerBitacora
                         WHERE IdPeeler = @idpeeler ";

            return await db.QueryFirstOrDefaultAsync<PeelerBitacora>(sql, new { IdPeeler = id });
        }

        public async Task<bool> InsertPeeler(PeelerBitacora peelerbitacora)
        {

            var db = dbConnection();

            var sql = @" INSERT INTO PeelerBitacora (no_de_lote, no_de_bloque, tipo_de_espuma, IdPedido, IdOperador, IdMaquina, IdTurno, FechaPeeler, Dañado, DetallesId, PesoRollo, no_rollo, Alma, Espesor, Largo, PesoRecuperable, PesoDesperdicio, HoraInicial, HoraFinal, Created, UserCreated, Updated, UserUpdated) 
                         VALUES(@NoDeLote, @NoDeBloque, @TipoDeEspuma, @IdPedido, @IdOperador, @IdMaquina, @IdTurno, @FechaPeeler, @Dañado, @DetallesId, @PesoRollo, @NoRollo, @Alma, @Espesor, @Largo, @PesoRecuperable, @PesoDesperdicio, @HoraInicial, @HoraFinal, @Created, @UserCreated, @Updated, @UserUpdated) ";

            try
            {
                int result = await db.ExecuteAsync(sql, new { peelerbitacora.NoDeLote, peelerbitacora.NoDeBloque, peelerbitacora.TipoDeEspuma, peelerbitacora.IdPedido, peelerbitacora.IdOperador, peelerbitacora.IdMaquina, peelerbitacora.IdTurno, peelerbitacora.FechaPeeler, peelerbitacora.Dañado, peelerbitacora.DetallesId, peelerbitacora.PesoRollo, peelerbitacora.NoRollo, peelerbitacora.Alma, peelerbitacora.Espesor, peelerbitacora.Largo, peelerbitacora.PesoRecuperable, peelerbitacora.PesoDesperdicio, peelerbitacora.HoraInicial, peelerbitacora.HoraFinal, peelerbitacora.Created, peelerbitacora.UserCreated, peelerbitacora.Updated, peelerbitacora.UserUpdated });
                return result > 0;
            }
            catch (Exception ex)
            {
                Message = "Something went wrong... " + ex.Message;
            }

            return false;
        }

        public async Task<bool> UpdatePeeler(PeelerBitacora peelerbitacora)
        {
            var db = dbConnection();

            var sql = @" INSERT INTO PeelerBitacora (NoDeLote) 
                         VALUES(@NoDeLote) ";

            var result = await db.ExecuteAsync(sql, new { peelerbitacora.NoDeLote });

            return result > 0;
        }
    }
}
