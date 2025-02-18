﻿using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class EstadoCuentaPendienteRepository : BaseRepository, IEstadoCuentaPendienteRepository
    {

        
        public ResponseBase EstadoCuentaPendiente(string idcontribuyente, int retorno)
        {
            var returnEntity = new ResponseBase();
            var entitieseecta = new List<EntityEstadoCuenta>();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_estadocuentapendiente";

                    var p = new DynamicParameters();
                    p.Add(name: "@idcontribuyente", value:idcontribuyente,dbType:DbType.String, direction: ParameterDirection.Input);                    
                    p.Add(name: "@resultado", value:retorno,dbType: DbType.Int32, direction: ParameterDirection.Output);

                    entitieseecta=  db.Query<EntityEstadoCuenta>(sql: sql, param: p, commandType: CommandType.StoredProcedure).ToList();

                    int idresultado = p.Get<int>("@resultado");

                    if(idresultado > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entitieseecta;
                       
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