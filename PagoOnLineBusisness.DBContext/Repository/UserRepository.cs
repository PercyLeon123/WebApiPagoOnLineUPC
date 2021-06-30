﻿using Dapper;
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
    public class UserRepository : BaseRepository, IUserRepository
    {
        public ResponseBase Insert(EntityUser user)
        {
            var returnEntity = new ResponseBase();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_InsertarUsuario";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDUSUARIO", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@LOGINUSUARIO", value: user.LoginUsuario, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@PASSWORDUSUARIO", value: user.PasswordUsuario, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@IDPERFIL", value: int.Parse(user.IdPerfil), dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@NOMBRES", value: user.Nombres, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@APELLIDOPATERNO", value: user.ApellidoPaterno, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@APELLIDOMATERNO", value: user.ApellidoMaterno, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@DOCUMENTOIDENTIDAD", value: user.DocumentoIdentidad, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOCREA", value: 1, dbType: DbType.Int32, direction: ParameterDirection.Input);


                    db.Query<EntityUser>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    int idUsuario = p.Get<int>("@IDUSUARIO");

                    if(idUsuario > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = new
                        {
                            id = idUsuario,
                            nombre = user.Nombres
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