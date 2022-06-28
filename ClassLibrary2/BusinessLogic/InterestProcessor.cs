using System.Collections.Generic;
using DataLibrary.Models;
using DataLibrary.DataAccess;

namespace DataLibrary.BusinessLogic
{
    public class InterestProcessor
    {
        public static List<InterestModel> FindInterests(int userID)
        {
            InterestModel data = new InterestModel
            {
                Id= userID
            };
            string sql = @"EXECUTE FindInterestsByUserId @Id";
            return SqlDataAccess.LoadData<InterestModel>(sql, data);
        }
    }
}
