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
    public class ContribuyenteRepository : BaseRepository, IContribuyenteRepository
    {

        public ResponseBase consulta(EntityContribuyente contribuyente)
        {
            var returnEntity = new ResponseBase();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_datoscontribuyente";

                    var p = new DynamicParameters();
                    p.Add(name: "@idcontribuyente", value: contribuyente.codigocont, dbType: DbType.String, direction: ParameterDirection.Input);                    
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
                            id = contribuyente.codigocont
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

        public ResponseBase actualiza(EntityContribuyente contribuyente)
        {
            var returnEntity = new ResponseBase();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_updatecontribuyente";

                    var p = new DynamicParameters();
                    p.Add(name: "@id", value: contribuyente.codigocont, direction: ParameterDirection.Output);
                    p.Add(name: "@dir_domicilio", value: contribuyente.dirdomicilio, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@telefono1", value: contribuyente.telefono1, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@telefono2", value: contribuyente.telefono2, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@telefono3", value: contribuyente.telefono3, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@telefono4", value: contribuyente.telefono4, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@correo", value: contribuyente.correo, dbType: DbType.String, direction: ParameterDirection.Input);
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
                            id = contribuyente.codigocont
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