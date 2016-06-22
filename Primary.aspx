<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Primary.aspx.cs" Inherits="IYForm.WebForm1"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-1.9.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/modernizr-custom.js"></script>
    <script src="Scripts/polyfiller.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/style.css" rel="stylesheet" />
    <script>
        webshims.setOptions('waitReady', false);
        webshims.setOptions('forms-ext', { types: 'date' });
        webshims.polyfill('forms forms-ext');
    </script>
    <title>I. Y. College of Arts, Science and Commerce</title>
    <style type="text/css">
       
        
       
        .auto-style3 {
            width: 345px;
        }
        .auto-style4 {
            width: 345px;
        }
       
        
       
    </style>
</head>
<body>
    <div id="header">
        <span><h2 id="collegename">I. Y. College of Arts, Science and Commerce</h2></span>
        <span><h3 id="purpose">Admissions for FY Junior College 2015-16</h3></span>
    </div>

    <form id="admission" runat="server">
    <div id="personal" class="form-group">
        <h3> Personal Information </h3>
        <table class="table">
           
            <tr>
                  <td class="auto-style3"><label for="seatno">SSC Seat No</label></td>
                  <td class="auto-style5"><asp:TextBox runat="server" ID="seatno" CssClass="form-control"></asp:TextBox> </td>
                  <td class="auto-style8"><asp:RequiredFieldValidator runat="server" id="reqSeatNo" SetFocusOnError="true" ValidationGroup="Form1" ControlToValidate ="seatno" errormessage="Seat no is required." /> </td>
                  
            </tr>

            <tr>
                <td class="auto-style3"><label for="sname">Name</label></td>
                <td class="auto-style5"> <asp:TextBox runat="server" ID="sname" CssClass="form-control"></asp:TextBox> </td>
                <td class="auto-style8"><asp:RequiredFieldValidator runat="server" id="reqName" ValidationGroup="Form1" SetFocusOnError="true" ControlToValidate="sname" errormessage="Name cannot be left blank." />
                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "sname" ValidationGroup="Form1" SetFocusOnError="true" ID="RegularExpressionValidator1" ValidationExpression = "^[\s\S]{8,}$" runat="server" ErrorMessage="Minimum 8 characters required."></asp:RegularExpressionValidator> </td>
            </tr>
        
            <tr>
                <td class="auto-style3"><label for="mothername">Mother's Name</label></td>
                <td class="auto-style5"> <asp:TextBox runat="server" ID="mothername" CssClass="form-control"></asp:TextBox></td>
                <td class="auto-style8"> <asp:RequiredFieldValidator runat="server" id="regMName" SetFocusOnError="true" ControlToValidate="mothername" ValidationGroup="Form1" errormessage="Mother's name cannot be left blank." /> 
                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "mothername" SetFocusOnError="true" ID="RegularExpressionValidator2" ValidationGroup="Form1" ValidationExpression = "^[\s\S]{3,}$" runat="server" ErrorMessage="Minimum 3 characters required."></asp:RegularExpressionValidator> </td>
            </tr>

        
            <tr>
                <td class="auto-style3"><label for="gender">Gender</label></td>
                <td class="auto-style5">
                    <asp:DropDownList runat="server" ID="gender" CssClass="form-control">
                            <asp:ListItem Value="Female" Text="Female">Female</asp:ListItem>
                            <asp:ListItem Selected="True" Value="Male" Text="Male">Male</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>

               <td class="auto-style3"><label for="caste">Caste</label></td>
                <td class="auto-style5"><asp:DropDownList runat="server" ID="caste" CssClass="form-control">
                    <asp:ListItem Value="SC" Text="SC">SC</asp:ListItem>
                    <asp:ListItem Value="ST" Text="ST">ST</asp:ListItem>
                    <asp:ListItem Value="VJ-A" Text="VJ-A">VJ - A</asp:ListItem>
                    <asp:ListItem Value="NT-A" Text="NT-A">NT-A</asp:ListItem>
                    <asp:ListItem Value="NT-B" Text="NT-B">NT-B</asp:ListItem>
                    <asp:ListItem Value="NT-C" Text="NT-C">NT-C</asp:ListItem>
                    <asp:ListItem Value="NT-D" Text="NT-D">NT-D</asp:ListItem> 
                    <asp:ListItem Value="SBC" Text="SBC">SBC</asp:ListItem>
                    <asp:ListItem Value="OBC" Text="OBC">OBC</asp:ListItem>
                    <asp:ListItem Value="Open" Text="Open">Open</asp:ListItem>
                    </asp:DropDownList>
                 </td>
            </tr>
        
            <tr>
                 <td class="auto-style3"><label for="studentmob">Student's Mobile No </label> </td>
                 <td class="auto-style5"> <asp:TextBox runat="server" ID="studentmob" CssClass="form-control"></asp:TextBox> </td>
               <td class="auto-style8"> <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator3" SetFocusOnError="true" ValidationGroup="Form1" ControlToValidate="studentmob" errormessage="Please provide a mobile number." />  
                 <asp:RegularExpressionValidator Display = "Dynamic" ValidationGroup="Form1" ControlToValidate = "studentmob" SetFocusOnError="true" ID="RegularExpressionValidator3" ValidationExpression = "^\d{10}$" runat="server" ErrorMessage="Enter a valid mobile number."></asp:RegularExpressionValidator> </td>
                 
            </tr>   
            
            <tr>
                  <td class="auto-style3"> <label for="studentmob2">Parent's Mobile No</label></td>
                 <td class="auto-style5"><asp:TextBox runat="server" ID="studentmob2" CssClass="form-control"></asp:TextBox> </td>
                 <td class="auto-style8"> <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" SetFocusOnError="true" ValidationGroup="Form1"  ControlToValidate="studentmob2" errormessage="Please provide a mobile number." />
                  <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "studentmob2" ValidationGroup="Form1" SetFocusOnError="true" ID="RegularExpressionValidator4" ValidationExpression = "^\d{10}$" runat="server" ErrorMessage="Enter a valid mobile number."></asp:RegularExpressionValidator>  </td>
            </tr>


                    <tr>
            <td class="auto-style4"> <label for="dob">Date of Birth</label>&nbsp; 

            </td>
            
            
            <td> 
                <asp:TextBox ID="dob" runat="server" type="date" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dob" SetFocusOnError="true" ValidationGroup="Form1" ErrorMessage="Date of Birth is required." ></asp:RequiredFieldValidator>               
                <br />
            </td>
        </tr>

            <tr>
            <td class="auto-style4"><label for="PH">Physically Handicapped</label></td>
            <td class="auto-style7"> <asp:RadioButtonList runat="server" ID="PH" CssClass="radio-inline">
                            <asp:ListItem Value="Yes" Text="Yes">Yes</asp:ListItem>
                            <asp:ListItem Text="No" Value="No">No</asp:ListItem>
                 </asp:RadioButtonList>
            </td>
        </tr>
      

            </table>
        </div>

        <div id="education" class="form-group">
            <h3>Academic Information</h3>

        <table class="table">

        <tr>
            
            <td class="auto-style4"><label for="yop">Year of Passing </label> </td>
            <td class="auto-style7">
                <asp:DropDownList runat="server" ID="yop" CssClass="form-control">
                <asp:ListItem Selected="True" Value="March 2015" Text="March 2015">March 2015</asp:ListItem>
                <asp:ListItem Value="October 2014" Text="October 2014">October 2014</asp:ListItem>
                <asp:ListItem  Value="March 2014" Text="March 2014">March 2014</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
      
        <tr>
            <td class="auto-style4"> <label for="score">Board Exam Marks (out of 500) </label></td>
            <td class="auto-style7"> <asp:TextBox runat="server" ID="score" CssClass="form-control"></asp:TextBox> </td>
             <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator4" ControlToValidate="score" SetFocusOnError="true" ValidationGroup="Form1" errormessage="Please enter your score." />
            <td><asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "score" ValidationGroup="Form1" SetFocusOnError="true" ID="RegularExpressionValidator5" ValidationExpression = "^\d{3}$" runat="server" ErrorMessage="Enter a valid 3 digit score."></asp:RegularExpressionValidator></td>
        </tr>

        <tr>
            <td class="auto-style4"><label for="faculty">Faculty</label></td>
            <td class="auto-style7"><asp:DropDownList runat="server" ID="faculty" CssClass="form-control">
                        <asp:ListItem Value="Arts" Text="Arts">Arts</asp:ListItem>
                        <asp:ListItem Value="Science" Text="Science">Science</asp:ListItem>
                        <asp:ListItem Value="Commerce" Text="Commerce">Commerce</asp:ListItem>
                 </asp:DropDownList>
            </td>
         </tr>
       
        <tr>
            <td class="auto-style4">  <label for="onlineapp">Applied Online</label> </td>
            <td class="auto-style7"> <asp:RadioButtonList runat="server" ID="onlineapp" CssClass="radio-inline">
                            <asp:ListItem Value="Yes" Text="Yes">Yes</asp:ListItem>
                            <asp:ListItem Selected="True" Value="No" Text="No">No</asp:ListItem>
                        </asp:RadioButtonList>
            </td>
          </tr>

        <tr>
            <td class="auto-style4"><label for="status">Status</label> </td>
            <td class="auto-style7"> <asp:DropDownList runat="server" ID="status" CssClass="form-control">
                    <asp:ListItem Selected="True" Value="Fresher" Text="Fresher">Fresher</asp:ListItem>
                    <asp:ListItem Value="Repeater" Text="Repeater">Repeater</asp:ListItem>
                    <asp:ListItem Value="Previously Passed" Text="Previously passed">Previously passed</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td class="auto-style4"><label for="board">Board</label></td>
            <td class="auto-style7"> <asp:DropDownList runat="server" ID="board" CssClass="form-control">
                    <asp:ListItem Selected="True" Value="SSC" Text="SSC">SSC</asp:ListItem>
                    <asp:ListItem Value="CBSE" Text="CBSE">CBSE</asp:ListItem>
                    <asp:ListItem Value="ICSE" Text="ICSE">ICSE</asp:ListItem>
                    <asp:ListItem Value="NIOS" Text="NIOS">NIOS</asp:ListItem>
                    <asp:ListItem Value="Other" Text="Other">Other</asp:ListItem>
               </asp:DropDownList>
            </td>
       </tr>


       <tr>
            <td class="auto-style4"><label for="category"> Category </label> </td>
           <td> <asp:DropDownList runat="server" ID="category" CssClass="form-control">
                    <asp:ListItem Value="ex-Serviceman" Text="ex-Serviceman">ex-Serviceman</asp:ListItem>
                    <asp:ListItem Value="Sports" Text="Sports">Sports</asp:ListItem>
                    <asp:ListItem Value="Arts & cultural" Text="Arts & cultural">Arts & cultural</asp:ListItem>
                    <asp:ListItem Value="Physically handicapped" Text="Physically handicapped">Physically Handicapped</asp:ListItem>
                    <asp:ListItem Value="General" Selected="True" Text="General">General</asp:ListItem>
                  </asp:DropDownList>  </td>
        </tr>

      
         
        </table>
    </div>

    <br />

    <div id="buttons">
        <asp:Button runat="server" class="btn btn-primary" ID="submit" Text="Submit" OnClick="submit_Click" /> &nbsp; &nbsp; &nbsp;
        <asp:Button runat="server" class="btn btn-primary" ID="pdf" Text="Download PDF" OnClick="pdf_Click" />
        <asp:Button runat="server" CssClass="btn btn-default" ID="editForm" Text="Edit" OnClick="editForm_Click" /> 

        <br />
        <br />
    </div>

    <asp:ValidationSummary ID="Summary1" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Form1"/>

    </form>


</body>
</html>
