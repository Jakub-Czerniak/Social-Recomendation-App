using System.Collections.Generic;
using System;
using DataLibrary.DataAccess;
using DataLibrary.Models;
using System.Data.SqlClient;

namespace DataLibrary.BusinessLogic
{
    public class UserProcessor
    {
        public static List<UserModel> FindUser(int userID)
        {
            UserModel data = new UserModel
            {
                Id = userID
            };
            string sql = @"EXECUTE FindUserById @ID";
            return SqlDataAccess.LoadData<UserModel>(sql, data);
        }

        public static List<UserModel> FindMatched(int userID)
        {
            UserModel data = new UserModel { Id = userID };
            string sql = @"EXECUTE  FindMatchedUsersById @ID";
            return SqlDataAccess.LoadData<UserModel>(sql, data);
        }

        public static List<UserModel> FindBestMatch(int userID)
        {
            UserModel data = new UserModel { Id = userID};
            string sql = @"EXECUTE FindBestMatchByInerests @ID";
            return SqlDataAccess.LoadData<UserModel> (sql, data);
        }
    }
}
