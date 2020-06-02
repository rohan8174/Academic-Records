<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Tpo.master" AutoEventWireup="true" CodeFile="match_hash.aspx.cs" Inherits="_Default" %>

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
                  <h5 class="card-title mb-4">File Hash Matching</h5>

                     <div class="form-group">
                
            
             <asp:Label ID="Label1" runat="server"  Text="FILE NAME :- "></asp:Label>   
                      
              <asp:Label ID="Label2" runat="server"  Text=""></asp:Label>      
		  </div>


                     <div class="form-group">
                
            
             <asp:Label ID="Label3" runat="server"  Text="HASH VALUE :- "></asp:Label>   
                      
              <asp:Label ID="Label4" runat="server"  Text=""></asp:Label>      
		  </div>
         
            
          
            

              <div class="form-group"  >
   
             <asp:FileUpload ID="fileuplogo" runat="server"   class="form-control p-input"/>
					
                  <asp:Label ID="Label5" runat="server"  Text="GENERATED HASH :- " Visible="False"></asp:Label>   
                      
              <asp:Label ID="Label6" runat="server"  Text=""></asp:Label>      
		  </div> 

                  	</div>


   
            <div class="form-group">
                
                  <asp:Button ID="btnsubmit" runat="server" Text="MATCH" class="btn btn-primary" OnClick="btnsubmit_Click"></asp:Button>
            </div>
           
    </div>

                   </div>
              </div>
            </div>
          </div>
        </div>
      </div>
 

</asp:Content>

