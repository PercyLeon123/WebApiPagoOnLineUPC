using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class ContribuyenteloginRepository : BaseRepository, IContribuyenteloginRepository
    {

        public ResponseBase logincontribuyente(string login, string contracena)
        {
            var returnEntity = new ResponseBase();
            var entitieslogin = new List<EntityContribuyentelogin>();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_loginContribuyente";

                    var p = new DynamicParameters();
                    p.Add(name: "@logincontribuyente", value:login,dbType:DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@contracena", value:contracena, dbType: DbType.String, direction: ParameterDirection.Input);

                    entitieslogin= db.Query<EntityContribuyentelogin>(sql: sql, param: p, commandType: CommandType.StoredProcedure).ToList();
                    EntityLoginResponse obj = new EntityLoginResponse();
                    obj.codigocont = entitieslogin.FirstOrDefault().codigocont;
                    obj.apenom = entitieslogin.FirstOrDefault().apenom;

                    if (entitieslogin != null)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = obj;


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