using System;
using System.Data.SqlClient;

namespace ArUpdateReceiveMake
{
    public class Generate
    {
        Sqllist sqllist=new Sqllist();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string UpdateMake(string ordernolist)
        {
            var result = "Finish";
            try
            {
                Generdt(sqllist.UpdateMake(ordernolist));
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 按照指定的SQL语句执行记录(反审核时使用)
        /// </summary>
        private void Generdt(string sqlscript)
        {
            using (var sql = GetCloudConn())
            {
                sql.Open();
                var sqlCommand = new SqlCommand(sqlscript, sql);
                sqlCommand.ExecuteNonQuery();
                sql.Close();
            }
        }

        /// <summary>
        /// 获取连接返回信息
        /// </summary>
        /// <returns></returns>
        private SqlConnection GetCloudConn()
        {
            var sqlcon = new SqlConnection(GetConnectionString());
            return sqlcon;
        }

        /// <summary>
        /// 连接字符串
        /// </summary>
        /// <param name="conid">0:连接K3数据库,1:连接条码库</param>
        /// <returns></returns>
        private string GetConnectionString()
        {
            var strcon = string.Empty;

            //if (conid == 0)
            //{
                strcon = @"Data Source='192.168.1.228';Initial Catalog='AIS20181204095717';Persist Security Info=True;User ID='sa'; Password='kingdee';
                       Pooling=true;Max Pool Size=40000;Min Pool Size=0";
            //}
            //else
            //{
            //    strcon = @"Data Source='172.16.4.249';Initial Catalog='RTIM_YATU';Persist Security Info=True;User ID='sa'; Password='Yatu8888';
            //           Pooling=true;Max Pool Size=40000;Min Pool Size=0";
            //}

            return strcon;
        }
    }
}
