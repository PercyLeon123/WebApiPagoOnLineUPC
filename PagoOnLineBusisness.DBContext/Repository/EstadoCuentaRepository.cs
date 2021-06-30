using Dapper;
using PagoOnLineBusisness.DBContext.Base;
using PagoOnLineBusisness.DBContext.Interface;
using PagoOnLineBusisness.DBEntity.Base;
using PagoOnLineBusisness.DBEntity.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PagoOnLineBusisness.DBContext.Repository
{
    public class EstadoCuentaRepository : BaseRepository, IEstadoCuentaRepository
    {

        public ResponseBase EstadoCuentaHistorico(EntityEstadoCuenta estadoCuenta)
        {
            var returnEntity = new ResponseBase();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_estadocuentahistorico";

                    var p = new DynamicParameters();
                    p.Add(name: "@idcontribuyente", value: estadoCuenta.codigocont, direction: ParameterDirection.Output);
                    p.Add(name: "@desde", value: estadoCuenta.fecha_pago, direction: ParameterDirection.Output);
                    p.Add(name: "@hasta", value: estadoCuenta.fecha_pago, direction: ParameterDirection.Output);
                    p.Add(name: "@resultado", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    db.Query<EntityUser>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    int idresultado = p.Get<int>("@resultado");

                    if (idresultado > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = new
                        {
                            idresultado = idresultado,
                            id = estadoCuenta.codigocont
                        };
                    }
                    else
                    {
                        returnEntity.isSuccess = false;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                returnEntity.isSuccess = false;
                returnEntity.errorCode = "0001";
                returnEntity.errorMessage = ex.Message;
                returnEntity.data = null;
            }

            return returnEntity;
        }
        public ResponseBase EstadoCuentaPendiente(EntityEstadoCuenta estadoCuenta)
        {
            var returnEntity = new ResponseBase();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_estadocuentapendiente";

                    var p = new DynamicParameters();
                    p.Add(name: "@idcontribuyente", value: estadoCuenta.codigocont, direction: ParameterDirection.Output);                    
                    p.Add(name: "@resultado", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    db.Query<EntityUser>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    int idresultado = p.Get<int>("@resultado");

                    if(idresultado > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = new
                        {
                            idresultado = idresultado,
                            id = estadoCuenta.codigocont
                        };
                    }
                    else
                    {
                        returnEntity.isSuccess = false;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = null;
                    }
                }
            }
            catch(Exception ex)
            {
                returnEntity.isSuccess = false;
                returnEntity.errorCode = "0001";
                returnEntity.errorMessage = ex.Message;
                returnEntity.data = null;
            }

            return returnEntity;
        }
    }
}