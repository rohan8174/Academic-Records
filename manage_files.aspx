<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Tpo.master" AutoEventWireup="true" CodeFile="manage_files.aspx.cs" Inherits="_Default" %>

<script runat="server">

   
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
		  <h3 class="page-heading mb-4">Manage Files</h3>



          <div class="form-group">
              <asp:TextBox ID="txtid" runat="server" placeholder="STUDENT ID" ></asp:TextBox>
  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtid" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                  <asp:Button ID="btnsubmit" runat="server" Text="Search" class="btn btn-primary" OnClick="btnsubmit_Click"></asp:Button>
						</div>
		  <div class="card-deck">
			<div class="card col-lg-12 px-0 mb-4">
			  <div class="card-body">
				<h5 class="card-title">List of Student Files</h5>
				

				<div class="table-responsive">
				<table class="table">
            <thead>
              <tr>
                <th scope="col">ID</th>
                  <th scope="col">Student_ID</th>
                  <th scope="col">Name</th>                 
                <th scope="col">Branch</th>
                <th scope="col">Semseter</th>
               
                  <th scope="col">File</th>
                   <th scope="col">Date</th>
                 
                    <%--<th scope="col">Delete</th>--%>
              </tr>
            </thead>
           
                <% if (flag == true)
                   {
                       foreach (System.Data.DataRow row in dt.Rows)
                       {%>
                            <tbody>
                                <tr>
                                    <td><%=row["id"]%></td>
                                     <td><%=row["student_id"]%></td>
                                     <td><%=row["name"]%></td>                                    
                                    <td><%=row["branch"]%></td>
                                    <td><%=row["semester"]%></td>                                   
                                    <td><%=row["file_name"]%></td>
                                    <td><%=row["date"]%></td>
                                    <td><a href="download.aspx?id=<%=row.ItemArray[0]%>" class="btn btn-outline-danger" onclick="return ConfirmDelete()" >Download</a></td>
                                     <td><a href="match_hash.aspx?id=<%=row.ItemArray[0]%>" class="btn btn-outline-danger"  >Hash</a></td>
<%--                                      <td><a href="deletefile.aspx?id=<%=row.ItemArray[0]%>" class="btn btn-outline-danger" onclick="return ConfirmDelete()" >Delete</a></td>--%>
                 

                                 </tr>
                            </tbody>
                           
                     <%  }
                      
                       
                   }%>
                   <%  else
                 {%>
                      <%-- Response.Write("<script>alert('No Data Found')</script>");--%>
                   <%}%> 
           
          </table>
				</div>
			  </div>
			</div>
		  </div>
		</div>
</asp:Content>

