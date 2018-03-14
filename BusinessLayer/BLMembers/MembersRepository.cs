using System;
using System.Data.SqlClient;
using Dapper;
using TestModels.MembersModel;
using System.Data;

namespace BusinessLayer.BLMembers
{
    public class MembersRepository : IMemberRepository
    {

        public bool AddMember(Members member)
        {
            using (var conn = new SqlConnection(Common.SQLConnection.GetConnection()))
            {
                try
                {
                    conn.Open();

                    var affectedRows = conn.Execute("CreateMember",
                        new { Account = member.Account, Pwd = member.Password, MemberId = member.MemberId },
                        commandType: CommandType.StoredProcedure);

                    if (affectedRows > 0)
                    {
                        return true;
                    }

                    return false;
                }
                catch (Exception err)
                {
                    throw err;
                }

            }
        }

        public Members GetMember(Members member)
        {
            Members data = new Members();

            using (var conn = new SqlConnection(Common.SQLConnection.GetConnection()))
            {
                try
                {
                    conn.Open();

                    data = conn.QuerySingle<Members>("GetMember",
                        new { Account = member.Account, Pwd = member.Password },
                        commandType: CommandType.StoredProcedure);

                    if (data != null)
                    {
                        return data;
                    }

                    return null;
                }
                catch (Exception err)
                {
                    throw err;
                }

            }
        }

        public bool IsMemberExists(Members member)
        {
            using (var conn = new SqlConnection(Common.SQLConnection.GetConnection()))
            {
                try
                {
                    conn.Open();

                    var memberList = conn.Query<Members>("IsMemberExists",
                        new { Account = member.Account },
                        commandType: CommandType.StoredProcedure).AsList();

                    if(memberList.Count > 0)
                    {
                        return true;
                    }

                    return false;
                }
                catch (Exception err)
                {
                    throw err;
                }
                
            }
        }

        

    }
}
