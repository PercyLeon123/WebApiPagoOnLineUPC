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
    public class ContribuyenteloginRepository : BaseRepository, IContribuyenteloginRepository
    {

        public ResponseBase logincontribuyente(EntityContribuyentelogin contribuyentelogin)
        {
            var returnEntity = new ResponseBase();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_loginContribuyente";

                    var p = new DynamicParameters();
                    p.Add(name: "@logincontribuyente", value: contribuyentelogin.login_cont, direction: ParameterDirection.Output);
                    p.Add(name: "@contracena", value: contribuyentelogin.contracena, dbType: DbType.String, direction: ParameterDirection.Input);
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
                            id = contribuyentelogin.codigocont
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