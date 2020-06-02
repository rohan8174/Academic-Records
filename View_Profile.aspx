<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="View_Profile.aspx.cs" Inherits="_Default" %>

<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        var chkvalue = "";


        function showimg() {
            debugger;
            var showimage = document.querySelector('#<%=showimge.ClientID %>');
            var file = document.querySelector('#<%=fileuplogo.ClientID%>').files[0];

            var reader = new window.FileReader();

            reader.onload = function () {
                showimage.src = reader.result;

            }
            if (file) {
                //reader.readasdataurl(file);
                reader.readAsDataURL(file);

            }
            else {
                showimage.src = "";
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class=" container-scroller" style="width:100%">
    <div class="container-fluid">
      <div class="row row-offcanvas row-offcanvas-right">
        <div class="content-wrapper">
         <%-- <h3 class="page-heading mb-4">Manage Project</h3>--%>
          <div class="row mb-2">
            <div class="col-lg-12">
              <div class="card" style="background-color:#f2f7f8">
                <div class="card-body">
                  <h5 class="card-title mb-4">Add New Student</h5>

           
        
             <div class="form-group">
             
                <asp:Image ID="showimge" runat="server" Height="100" Width="150" />
                 
		  </div>
            

                         
                 <div class="form-group">
               <asp:TextBox ID="txtbranch" runat="server" placeholder="BRANCH" class="form-control p-input" ReadOnly="true"></asp:TextBox>
  <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtbranch" ErrorMessage="BRANCH"></asp:RequiredFieldValidator>
						</div>
               
                       
                     
                
                 
               
            
                 <div class="form-group">
                       
                      <asp:TextBox ID="txtsem" runat="server" placeholder="SEMESTER" class="form-control p-input"  ReadOnly="true"></asp:TextBox>
  <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtsem" ErrorMessage="SEMESTER"></asp:RequiredFieldValidator>
						</div>

		  
                 
                  <div class="form-group">
              <asp:TextBox ID="txtid" runat="server" placeholder="STUDENT ID" class="form-control p-input" ReadOnly="true"></asp:TextBox>
  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtid" ErrorMessage="STUDENT ID"></asp:RequiredFieldValidator>
						</div>
                 

             <div class="form-group">
              <asp:TextBox ID="txtname" runat="server" placeholder="FULL NAME" class="form-control p-input" ></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtname" ErrorMessage="FULL NAME"></asp:RequiredFieldValidator>
						</div>
                 
                 <div  class="form-group" >
                  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
              <asp:TextBox ID="txtdate" runat="server" placeholder="Date" class="single-input"></asp:TextBox>
                  <ajax:calendarextender ID="CalendarExtender2" runat="server" TargetControlID="txtdate"
                                    Format="dd/MM/yyyy">
                                </ajax:calendarextender>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtdate" ErrorMessage="DATE OF BIRTH"></asp:RequiredFieldValidator>

						</div>

             <div class="form-group">
              <asp:TextBox ID="txtemail" runat="server" placeholder="EMAIL" class="form-control p-input" ></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtemail" ErrorMessage="EMAIL"></asp:RequiredFieldValidator>
						</div>
                 
            <div class="form-group">
              <asp:TextBox ID="txtphone" runat="server" placeholder="PHONE NB" class="form-control p-input" ></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtphone" ErrorMessage="PHONE NB"></asp:RequiredFieldValidator>
						</div>
                 
                 <div class="form-group">
              <asp:TextBox ID="txtaddress" runat="server" placeholder="ADDRESS" class="form-control p-input" ></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtaddress" ErrorMessage="ADDRESS"></asp:RequiredFieldValidator>
						</div>
            
            
             <div class="form-group">
              <asp:TextBox ID="txtpass" runat="server" placeholder="PASSWORD" class="form-control p-input" ></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtpass" ErrorMessage="PASSWORD"></asp:RequiredFieldValidator>
						</div>
            
            <div class="form-group">
             
               
                 
              <asp:FileUpload ID="fileuplogo" runat="server" onchange="showimg()"  class="form-control p-input"/>
                                                 
		  </div>

                 
                 <div class="form-group">
                
                  <asp:Button ID="btnsubmit" runat="server" Text="SAVE" class="btn btn-primary" OnClick="btnsubmit_Click"></asp:Button>
            </div>
                 
             
           
     </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

  </div>
  <%--  </div>--%>
</asp:Content>

