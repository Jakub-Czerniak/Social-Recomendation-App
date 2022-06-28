using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Models;
using DataLibrary.DataAccess;

namespace DataLibrary.BusinessLogic
{
    public class PairProcessor
    {
        public static int SendDecision(int UserID, int User2ID, string Decision)
        {
            PairModel data = new PairModel
            {
                User1_ID = UserID,
                User2_ID = User2ID,
                User1_Decision = Decision
            };
            string sql = @"EXECUTE SendDecision @User1_ID, @User2_ID, @User1_Decision";
            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
