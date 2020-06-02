<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="View_Files.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="content-wrapper">
		  <h3 class="page-heading mb-4">Manage Files</h3>

		  <div class="card-deck">
			<div class="card col-lg-12 px-0 mb-4">
			  <div class="card-body">
				<h5 class="card-title">List of Student Files</h5>
				
                <%--   <div class="form-group">
              <asp:TextBox ID="txtid" runat="server" placeholder="STUDENT ID" class="form-control p-input" ></asp:TextBox>
  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtid" ErrorMessage="STUDENT ID"></asp:RequiredFieldValidator>
						</div>
                  <div class="form-group">
                
                  <asp:Button ID="btnsubmit" runat="server" Text="SAVE" class="btn btn-primary" OnClick="btnsubmit_Click"></asp:Button>
            </div>--%>

				<div class="table-responsive">
				<table class="table">
            <thead>
              <tr>
                <th scope="col">ID</th>
                  <th scope="col">Date</th>
                <th scope="col">Branch</th>
                <th scope="col">Semseter</th>
                <th scope="col">Student_ID</th>
                  <th scope="col">File</th>
                 
                    <th scope="col">Download</th>
              </tr>
            </thead>
           
                <% if (flag == true)
                   {
                       foreach (System.Data.DataRow row in dt.Rows)
                       {%>
                            <tbody>
                                <tr>
                                   <td><%=row["id"]%></td>
                                    <td><%=row["date"]%></td>
                                    <td><%=row["branch"]%></td>
                                    <td><%=row["sem"]%></td>
                                    <td><%=row["student_id"]%></td>
                                    <td><%=row["file_name"]%></td>
                                   
                                      <td><a href="download.aspx?id=<%=row.ItemArray[0]%>" class="btn btn-outline-danger" onclick="return ConfirmDelete()" >Download</a></td>
                 

                                 </tr>
                            </tbody>
                           
                     <%  }
                      
                       
                   }%>
                   <%  else
                 {%>
                       <%--Response.Write("<script>alert('No Data Found')</script>");--%>
                   <%}%> 
           
          </table>
				</div>
			  </div>
			</div>
		  </div>
		</div>
</asp:Content>


