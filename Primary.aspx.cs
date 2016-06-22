using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;



namespace IYForm
{

    public partial class WebForm1: System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (PreviousPage != null)
            {
                List<String> sessionValues = new List<String>();
                sessionValues = (List<String>) Session["valueObjects"];
                List<String> controlStrings = new List<String>();

                Session.Abandon();


                if (sessionValues == null)
                {
                    Response.Write(@"<script language='javascript'> alert ('One or more of the entered values is incorect. Please try again.') </script> ");
                    Response.Write(@"<script language='javascript'> window.location.href = 'Edit.aspx' </script>");
                }

                else if (sessionValues != null)
                {
                    foreach (String str in sessionValues)
                    {
                        controlStrings.Add(str);
                    }

                    try
                    {
                        TextBox t1 = (TextBox)Page.FindControl("sname");
                        t1.Text = controlStrings.ElementAt(0);

                        TextBox inactiveSeatNo = (TextBox)Page.FindControl("seatno");
                        inactiveSeatNo.Text = controlStrings.ElementAt(13);
                        inactiveSeatNo.Enabled = false;


                        TextBox inactiveMName = (TextBox)Page.FindControl("mothername");
                        inactiveMName.Text = controlStrings.ElementAt(14);
                        inactiveMName.Enabled = false;


                        DropDownList d1 = (DropDownList)Page.FindControl("gender");
                        d1.SelectedValue = controlStrings.ElementAt(1);


                        DropDownList d2 = (DropDownList)Page.FindControl("caste");
                        d2.SelectedValue = controlStrings.ElementAt(2);

                        TextBox t3 = (TextBox)Page.FindControl("studentmob");
                        t3.Text = controlStrings.ElementAt(3);

                        TextBox t4 = (TextBox)Page.FindControl("studentmob2");
                        t4.Text = controlStrings.ElementAt(4);

                        DropDownList d3 = (DropDownList)Page.FindControl("yop");
                        d3.SelectedValue = controlStrings.ElementAt(5);

                        TextBox t5 = (TextBox)Page.FindControl("score");
                        t5.Text = controlStrings.ElementAt(6);

                        DropDownList d4 = (DropDownList)Page.FindControl("faculty");
                        d4.SelectedValue = controlStrings.ElementAt(7);

                        RadioButtonList rb1 = (RadioButtonList)Page.FindControl("onlineapp");
                        rb1.SelectedValue = controlStrings.ElementAt(8);

                        DropDownList d6 = (DropDownList)Page.FindControl("status");
                        d6.SelectedValue = controlStrings.ElementAt(9);

                        DropDownList d7 = (DropDownList)Page.FindControl("board");
                        d7.SelectedValue = controlStrings.ElementAt(10);

                        DropDownList d8 = (DropDownList)Page.FindControl("category");
                        d8.SelectedValue = controlStrings.ElementAt(11);

                        RadioButtonList rb2 = (RadioButtonList)Page.FindControl("PH");
                        rb2.SelectedValue = controlStrings.ElementAt(12);

                        TextBox datebox = (TextBox)Page.FindControl("dob");
                        datebox.Text = controlStrings.ElementAt(15);
                        datebox.Enabled = false;

                        Button editBtn = (Button)Page.FindControl("editForm");
                        editBtn.Enabled = false;
                        editBtn.Visible = false;


                    }
                    catch (ArgumentOutOfRangeException argrange)
                    {
                        argrange.StackTrace.ToString();
                        Response.Write(@"<script language='javascript'> alert ('One or more of the entered values is incorect. Please try again.') </script> ");

                    }
                    
                }

            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            Page.Validate("Form1");
            if (Page.IsValid)
            {

                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;


                String SSCSeatNo;
                String name;
                String mname;
                String Gender;
                String Caste;
                String mobile;
                String parentMobile;
                String year;
                int total;
                String Faculty;
                String apponline;
                String Status;
                String Board;
                String birthday;
                String Category;
                String phyHandicap;
                int appnumber;
                String ts;


                SSCSeatNo = seatno.Text;
                name = sname.Text.ToUpper();
                mname = mothername.Text.ToUpper();
                Gender = gender.SelectedValue;
                Caste = caste.SelectedValue;
                mobile = studentmob.Text;
                parentMobile = studentmob2.Text;
                year = yop.Text;
                total = Convert.ToInt16(score.Text);
                Faculty = faculty.SelectedValue;
                apponline = onlineapp.SelectedValue;
                Status = status.SelectedValue;
                Board = board.SelectedValue;
                birthday = dob.Text;

                Category = category.SelectedValue;
                phyHandicap = PH.SelectedValue;



                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    String insertQuery = "insert into studentdata(SSCSeatNo, Name, MothersName, Gender, Caste, MobileNo, ParentMobile, YearOfPassing, SSCTotal, Faculty, AppOnline, Status, Board, DOB, Category, PhysicalHandicap) values(@SSCSeatNo, @name, @mname, @Gender, @Caste, @mobile, @parentMobile , @year, @total, @Faculty, @apponline, @Status, @Board, @birthday, @Category, @phyHandicap)";
                    String getLastInsert = "select LAST_INSERT_ID()";
                    String getTimestamp = "select TimeStamp from studentdata where AppNo=@appnumber";

                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, con))
                    {
                        MySqlCommand cmd2 = new MySqlCommand(getLastInsert, con);
                        MySqlCommand cmd3 = new MySqlCommand(getTimestamp, con);

                        cmd.Parameters.AddWithValue("@SSCSeatNo", SSCSeatNo);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@mname", mname);
                        cmd.Parameters.AddWithValue("@Gender", Gender);
                        cmd.Parameters.AddWithValue("@Caste", Caste);
                        cmd.Parameters.AddWithValue("@mobile", mobile);
                        cmd.Parameters.AddWithValue("@parentMobile", parentMobile);
                        cmd.Parameters.AddWithValue("@year", year);
                        cmd.Parameters.AddWithValue("@total", total);
                        cmd.Parameters.AddWithValue("@Faculty", Faculty);
                        cmd.Parameters.AddWithValue("@apponline", apponline);
                        cmd.Parameters.AddWithValue("@Status", Status);
                        cmd.Parameters.AddWithValue("@Board", Board);
                        cmd.Parameters.AddWithValue("@birthday", birthday);
                        cmd.Parameters.AddWithValue("@Category", Category);
                        cmd.Parameters.AddWithValue("@phyHandicap", phyHandicap);


                        //check if the record exists
                        String checkExists = "SELECT EXISTS (SELECT 1 FROM studentdata WHERE SSCSeatNo = @SSCSeatNo)";
                        MySqlCommand cmdCheckExists = new MySqlCommand(checkExists, con);
                        cmdCheckExists.Parameters.AddWithValue("@SSCSeatNo", SSCSeatNo);
                        int recExists = Convert.ToInt32(cmdCheckExists.ExecuteScalar());

                        if (recExists == 1)
                        {
                            Response.Write(@"<script language='javascript'> alert ('You have already submitted an application. Click on Download PDF to view and save your form.') </script> ");
                        }

                        else if( recExists == 0)
                        {

                            cmd.ExecuteNonQuery();
                        
                            appnumber = Convert.ToInt32(cmd2.ExecuteScalar());
                            System.Diagnostics.Debug.Write("Last Insert" + appnumber);

                            cmd3.Parameters.AddWithValue("@appnumber", appnumber);

                            DateTime tstamp = (DateTime)cmd3.ExecuteScalar();
                            ts = tstamp.ToLongDateString();

                            createPDF(SSCSeatNo, name, mname, Gender, Caste, mobile, parentMobile, year, total, Faculty, apponline, Status, Board, birthday, Category, phyHandicap, appnumber, ts);

                            Response.Write(@"<script language='javascript'> alert ('Your application has been submitted. Click the Download PDF button below to download your form.') </script> ");


                        }
                        cmd.Dispose();
                        cmd2.Dispose();
                        cmd3.Dispose();
                        con.Close();
                    }

                } //end of Using 

               
            }
        }




        protected void createPDF(String SSCSeatNo, String name, String mname, String Gender, String Caste, String mobile, String parentMobile, String year, int total, String Faculty, String apponline, String Status, String Board, String birthday, String Category, String phyHandicap, int appnumber, String ts)
        {
            
            try
            {

                String dir = Server.MapPath("~/pdfs/");
                String ext = ".pdf";

                String pdfLocation = dir + SSCSeatNo + ext;

                Document pdfDoc = new Document(PageSize.A4, 10, 10, 20, 20);
                PdfWriter.GetInstance(pdfDoc, new FileStream(pdfLocation, FileMode.Create));
                pdfDoc.Open();
                PdfPTable corner = new PdfPTable(2);
                corner.TotalWidth = 100;

                

                String appno = appnumber.ToString();
                String totalscore = total.ToString();

                //PdfPCell cornercell = new PdfPCell(new Phrase("Application No"));
                //corner.AddCell(cornercell);

                Paragraph collegename = new Paragraph("IY College of Arts, Science and Commerce.");
                Paragraph formpurpose = new Paragraph("Admission updation acknowledgement for First Year Junior College 2015-16");
                Paragraph space = new Paragraph(" ");

                collegename.Alignment = Element.ALIGN_CENTER;
                formpurpose.Alignment = Element.ALIGN_CENTER;
                pdfDoc.Add(collegename);
                pdfDoc.Add(formpurpose);
                pdfDoc.Add(space);
                pdfDoc.Add(space);

                corner.AddCell(new Phrase("Application no "+appno, new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD)));
                corner.AddCell(new Phrase(ts));
                corner.AddCell(new Phrase(Faculty));

                PdfPTable general = new PdfPTable(2);
                general.TotalWidth = 100;
                general.AddCell(new Phrase("Board Seat No", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD)));
                general.AddCell(new Phrase(SSCSeatNo));

                general.AddCell(new Phrase("Name", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD)));
                general.AddCell(new Phrase(name));

                general.AddCell(new Phrase("Mother's name", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD)));
                general.AddCell(new Phrase(mname));

                general.AddCell(new Phrase("Gender", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD)));
                general.AddCell(new Phrase(Gender));

                general.AddCell(new Phrase("Caste", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD)));
                general.AddCell(new Phrase(Caste));

                general.AddCell(new Phrase("Mobile No", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD)));
                general.AddCell(new Phrase(mobile));

                general.AddCell(new Phrase("Parent's mobile No", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD)));
                general.AddCell(new Phrase(parentMobile));


                general.AddCell(new Phrase("Date of Birth", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD)));
                general.AddCell(new Phrase(birthday));

                general.AddCell(new Phrase("Physically handicapped", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD)));
                general.AddCell(new Phrase(phyHandicap));


                PdfPTable education = new PdfPTable(4);
                education.AddCell(new Phrase("Year of Passing", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD)));
                education.AddCell(new Phrase(year));

                education.AddCell(new Phrase("Faculty", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD)));
                education.AddCell(new Phrase(Faculty));

                education.AddCell(new Phrase("Board score", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD)));
                education.AddCell(new Phrase(totalscore));

                education.AddCell(new Phrase("Applied online", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD)));
                education.AddCell(new Phrase(apponline));


                education.AddCell(new Phrase("Status", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD)));
                education.AddCell(new Phrase(Status));

                education.AddCell(new Phrase("Board", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD)));
                education.AddCell(new Phrase(Board));

                education.AddCell(new Phrase("Category", new Font(Font.FontFamily.HELVETICA, 12f, Font.BOLD)));
                education.AddCell(new Phrase(Category));


                pdfDoc.Add(corner);
                pdfDoc.Add(general);
                pdfDoc.Add(education);

                pdfDoc.Close();
                
                
              
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        protected void editForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("Edit.aspx");
        }

        protected void changes_Click(object sender, EventArgs e)
        {
            Page.Validate("Form1");
            if (Page.IsValid)
            {

                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;


                String SSCSeatNo;
                String name;
                String mname;
                String Gender;
                String Caste;
                String mobile;
                String parentMobile;
                String year;
                int total;
                String Faculty;
                String apponline;
                String Status;
                String Board;
                String birthday;
                String Category;
                String phyHandicap;
                int appnumber;
                String ts;

                SSCSeatNo = seatno.Text;
                name = sname.Text.ToUpper();
                mname = mothername.Text.ToUpper();
                Gender = gender.SelectedValue;
                Caste = caste.SelectedValue;
                mobile = studentmob.Text;
                parentMobile = studentmob2.Text;
                year = yop.Text;
                total = Convert.ToInt16(score.Text);
                Faculty = faculty.SelectedValue;
                apponline = onlineapp.SelectedValue;
                Status = status.SelectedValue;
                Board = board.SelectedValue;
                birthday = dob.Text;

                Category = category.SelectedValue;
                phyHandicap = PH.SelectedValue;



                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    
                    String getAppNo = "select AppNo from studentdata where SSCSeatNo = @SSCSeatNo";
                    String getTimestamp = "select TimeStamp from studentdata where SSCSeatNo=@SSCSeatNo";

                    con.Open();
                    
                    using (MySqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = "update studentdata set Name = @name, Gender = @Gender, Caste = @Caste, MobileNo = @mobile, ParentMobile = @parentMobile, YearOfPassing = @year, SSCTotal = @total, Faculty = @Faculty, AppOnline = @apponline, Status = @Status, Board = @Board, Category = @Category, PhysicalHandicap =@phyHandicap where SSCSeatNo = @SSCSeatNo and MothersName= @mname and DOB = @birthday";

                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@Gender", Gender);
                        cmd.Parameters.AddWithValue("@Caste", Caste);
                        cmd.Parameters.AddWithValue("@mobile", mobile);
                        cmd.Parameters.AddWithValue("@parentMobile", parentMobile);
                        cmd.Parameters.AddWithValue("@year", year);
                        cmd.Parameters.AddWithValue("@total", total);
                        cmd.Parameters.AddWithValue("@Faculty", Faculty);
                        cmd.Parameters.AddWithValue("@apponline", apponline);
                        cmd.Parameters.AddWithValue("@Status", Status);
                        cmd.Parameters.AddWithValue("@Board", Board);
                        cmd.Parameters.AddWithValue("@Category", Category);
                        cmd.Parameters.AddWithValue("@phyHandicap", phyHandicap);
                        cmd.Parameters.AddWithValue("@SSCSeatNo", SSCSeatNo);
                        cmd.Parameters.AddWithValue("@mname", mname);
                        cmd.Parameters.AddWithValue("@birthday", birthday);
                        
                       
                        MySqlCommand cmd2 = new MySqlCommand(getTimestamp, con);
                        cmd2.Parameters.AddWithValue("@SSCSeatNo", SSCSeatNo);

                        MySqlCommand cmd3 = new MySqlCommand(getAppNo, con);
                        cmd3.Parameters.AddWithValue("@SSCSeatNo", SSCSeatNo);
                        appnumber = Convert.ToInt32(cmd3.ExecuteScalar());
                       
                        cmd.ExecuteNonQuery();

                        DateTime tstamp = (DateTime)cmd2.ExecuteScalar();
                        ts = tstamp.ToLongDateString();

                        cmd.Dispose();
                        cmd2.Dispose();
                        cmd3.Dispose();
                        con.Close();
                    }

                } //end of Using 

                createPDF(SSCSeatNo, name, mname, Gender, Caste, mobile, parentMobile, year, total, Faculty, apponline, Status, Board, birthday, Category, phyHandicap, appnumber, ts);

                Response.Write(@"<script language='javascript'> alert ('Your changes have been saved.') </script> ");
                
            }
        }

        protected void pdf_Click(object sender, EventArgs e)
        {
            

            Page.Validate("Form1");
            if (Page.IsValid)
            {

                TextBox txtSeatNo = (TextBox) Page.FindControl("seatno");
                String filename = txtSeatNo.Text;

                String pathToFile = "~/pdfs/"+filename+".pdf";

                Response.Redirect(pathToFile);

            }
        }

        }
  
    }
