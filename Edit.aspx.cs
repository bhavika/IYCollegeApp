using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace IYForm
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void edit_click(object sender, EventArgs e)
        {
           
            Page.Validate("Form2");
            if (IsValid)
            {
                String EditSeatNo = eSeatNo.Text;
                String EditMName = emothername.Text.ToUpper();
                String tempDOB = edob.Text;

                String EditDOB = Convert.ToDateTime(tempDOB).ToString("yyyy-MM-dd");
                
                String Name;
                String Gender;
                String Caste;
                String MobileNo;
                String ParentMobile;
                String YOP;
                String BoardTotal;
                String Faculty;
                String AppOnline;
                String Status;
                String Board;
                String Category;
                String phyHandicap;


                MySqlDataReader datareader;
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

                using(MySqlConnection con = new MySqlConnection(constr))
                {
                    String populateForm = "select Name, Gender, Caste, MobileNo, ParentMobile, YearOfPassing, SSCTotal, Faculty, AppOnline, Status, Board, Category, PhysicalHandicap from studentdata where SSCSeatNo=@EditSeatNo AND MothersName=@EMName AND DOB=@EditDOB";
                    con.Open();
                    
                    using (MySqlCommand cmd = new MySqlCommand(populateForm, con))
                    {
                        cmd.Parameters.AddWithValue("@EditSeatNo", EditSeatNo);
                        cmd.Parameters.AddWithValue("@EMName", EditMName);
                        cmd.Parameters.AddWithValue("@EditDOB", EditDOB);


                        datareader = cmd.ExecuteReader();

                        if (datareader.HasRows)
                        {
                            while (datareader.Read())
                            {
                                Name = datareader.GetString(0);
                                Gender = datareader.GetString(1);
                                Caste = datareader.GetString(2);
                                MobileNo = datareader.GetString(3);
                                ParentMobile = datareader.GetString(4);
                                YOP = datareader.GetString(5);
                                BoardTotal = datareader.GetString(6);
                                Faculty = datareader.GetString(7);
                                AppOnline = datareader.GetString(8);
                                Status = datareader.GetString(9);
                                Board = datareader.GetString(10);
                                Category = datareader.GetString(11);
                                phyHandicap = datareader.GetString(12);


                                List<String> values = new List<String>();
                                values.Add(Name);
                                values.Add(Gender);
                                values.Add(Caste);
                                values.Add(MobileNo);
                                values.Add(ParentMobile);
                                values.Add(YOP);
                                values.Add(BoardTotal);
                                values.Add(Faculty);
                                values.Add(AppOnline);
                                values.Add(Status);
                                values.Add(Board);
                                values.Add(Category);
                                values.Add(phyHandicap);
                                values.Add(EditSeatNo);
                                values.Add(EditMName);
                                values.Add(EditDOB);

                                Session["valueObjects"] = values;

                            }


                        }
                        else
                        {
                            Response.Write(@"<script language='javascript'> alert('One or more of the entered fields is incorrect. Please try again');");
                        }
                    }

                }
            }

        }

    }
}