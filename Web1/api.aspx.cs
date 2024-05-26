using SuatAn;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace web1
{
    public partial class api : System.Web.UI.Page
    {
        public class TeamStanding
        {
            public string rank { get; set; }
            public string title { get; set; }
            public string artist { get; set; }
            public string listener { get; set; }


        }

        void top(string action)
        {
            try
            {
                // Kết nối đến cơ sở dữ liệu
                SqlServer db = new SqlServer();

                // Gọi stored procedure GetTopTracks từ cơ sở dữ liệu
                SqlCommand cm = db.GetCmd("GetTopTracks");

                // Thực thi truy vấn và nhận kết quả
                string jsonString = (string)db.Scalar(cm);

                // Chuyển đổi chuỗi JSON thành danh sách các đối tượng
                List<TeamStanding> teamStats = JsonConvert.DeserializeObject<List<TeamStanding>>(jsonString);

                // Chuyển đổi danh sách các đối tượng thành chuỗi JSON
                string teamStatsJson = JsonConvert.SerializeObject(teamStats);

                // Trả về kết quả cho client
                this.Response.Write(teamStatsJson);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi ở đây, ví dụ:
                this.Response.Write("An error occurred: " + ex.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Lấy action từ request
                string action = Request["action"];

                switch (action)
                {
                    case "GetTopTracks":
                        top(action);
                        break;
                    default:
                        // Handle unknown action
                        this.Response.Write("Unknown action.");
                        break;
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi ở đây, ví dụ:
                this.Response.Write("An error occurred: " + ex.Message);
            }
        }
    }
}
