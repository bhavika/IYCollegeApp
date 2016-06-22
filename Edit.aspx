<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="IYForm.WebForm2"  %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script src="Scripts/jquery-1.9.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/modernizr-custom.js"></script>
    <script src="Scripts/polyfiller.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/style.css" rel="stylesheet" />
    
    <title>I. Y. College of Arts, Science and Commerce</title>
</head>
<body>
    <div id="login">
        <span><h2 id="collegename">I. Y. College of Arts, Science and Commerce</h2></span>
        <span><h3 id="purpose">Admissions for First Year Junior College (Std XI) 2015-16</h3></span>
    </div>

    <br />

    <h4 id="helptext">Fill in the 3 fields below to edit your previously submitted form.</h4>

    <br /> 

    <form runat="server" class="form-group">   
        <table class="table-condensed" id="edit">
            <tr>
                  <td><label for="eSeatNo">SSC Seat No</label></td> 
                  <td><br /></td>
                  <td><asp:TextBox runat="server" ID="eSeatNo" CssClass="form-control"></asp:TextBox> </td>
                  <td><asp:RequiredFieldValidator runat="server" id="reqEditSeatNo" SetFocusOnError="true" ValidationGroup="Form2" ControlToValidate ="eSeatNo" errormessage="Seat no is required." /> </td>
                  
            </tr>
        
           

            <tr>
                <td><label for="emothername">Mother's Name</label></td>
                 <td><br /></td>
                <td> <asp:TextBox runat="server" ID="emothername" CssClass="form-control"></asp:TextBox></td>
                <td> <asp:RequiredFieldValidator runat="server" id="eregMName" SetFocusOnError="true" ControlToValidate="emothername" ValidationGroup="Form1" errormessage="Mother's name cannot be left blank." /> 
                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "emothername" SetFocusOnError="true" ID="RegularExpressionValidator2" ValidationGroup="Form1" ValidationExpression = "^[\s\S]{3,}$" runat="server" ErrorMessage="Minimum 3 characters required."></asp:RegularExpressionValidator> </td>
            </tr>
           
            <tr>
                  <td> <label for="edob">Date of Birth</label>&nbsp; </td>
                    <td><br /></td>
                  <td> 
                   <asp:TextBox ID="edob" runat="server" type="date" CssClass="form-control"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="edob" SetFocusOnError="true" ValidationGroup="Form1" ErrorMessage="Date of Birth is required." ></asp:RequiredFieldValidator>               
                  </td>
            </tr>


            <tr>
                <td> <asp:Button id="editButton" OnClick="edit_click" runat="server" CssClass="btn btn-primary" Text="Edit" PostBackUrl="~/Primary.aspx"/> </td>
            </tr>

        </table>
         <asp:ValidationSummary ID="Summary2" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Form2"/>
    </form>
</body>
</html>
