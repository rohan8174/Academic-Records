<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Upload_File_Student.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
     <div class=" container-scroller" style="width:100%">
    <div class="container-fluid">
      <div class="row row-offcanvas row-offcanvas-right">
        <div class="content-wrapper">
       <%--   <h3 class="page-heading mb-4">Manage Student</h3>--%>
          <div class="row mb-2">
            <div class="col-lg-12">
              <div class="card">
                <div class="card-body">
                  <h5 class="card-title mb-4">Share Files</h5>


                    <div class="form-group">
                
            
                   <asp:DropDownList ID="DropDownList1" runat="server"  class="form-control p-input" >
                
						</asp:DropDownList>
                      
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1" ErrorMessage="Select TPO "></asp:RequiredFieldValidator>
                    
		  </div>
                    


             <div class="form-group">
                
            
                 <asp:TextBox ID="txtdes" runat="server" placeholder="Discription" class="form-control p-input"></asp:TextBox>
  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdes" ErrorMessage="Discription"></asp:RequiredFieldValidator>
                    
		  </div>


            
            
            
            
            
     
              <div class="form-group"  >
   
            <asp:DropDownList ID="DropDownList2" runat="server"  class="form-control p-input" />
						</div>


   
            <div class="form-group">
                
                  <asp:Button ID="btnsubmit" runat="server" Text="SHARE" class="btn btn-primary" OnClick="btnsubmit_Click"></asp:Button>
            </div>
           
    </div>

                   </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
     </div>
     </div>
</asp:Content>

