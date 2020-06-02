<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Tpo.master" AutoEventWireup="true" CodeFile="manage_student.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-wrapper">
		  <h3 class="page-heading mb-4">Manage Student</h3>

		  <div class="card-deck">
			<div class="card col-lg-12 px-0 mb-4">
			  <div class="card-body">
				<h5 class="card-title">List of Student</h5>
				
                   <div class="form-group">
              <asp:TextBox ID="txtid" runat="server" placeholder="STUDENT ID" ></asp:TextBox>
  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtid" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                  <asp:Button ID="btnsubmit" runat="server" Text="Search" class="btn btn-primary" OnClick="btnsubmit_Click"></asp:Button>
						</div>
                  <div class="form-group">
                
            </div>


				<div class="table-responsive">
				 <table class="table">
            <thead>
              <tr>
                <th scope="col">Student_Id</th>
                <th scope="col">Branch</th>
                <th scope="col">Sem</th>
                <th scope="col">Name</th>
                  <th scope="col">Email</th>
                <th scope="col">Phone</th>
                    <th scope="col">Address</th>
                   <th scope="col">DOB</th>
                   <%--<th scope="col">Edit</th>
                    <th scope="col">Delete</th>--%>
              </tr>
            </thead>
           
                <% if (flag == true)
                   {
                       foreach (System.Data.DataRow row in dt.Rows)
                       {%>
                            <tbody>
                                <tr>
                                    <td><%=row["student_id"]%></td>
                                    <td><%=row["Branch"]%></td>
                                    <td><%=row["Semester"]%></td>
                                    <td><%=row["Name"]%></td>
                                    <td><%=row["Email"]%></td>
                                      <td><%=row["Phone"]%></td>
                                    <td><%=row["Address"]%></td>
                                     <td><%=row["Dob"]%></td>
                                     
                                    <%--<td><a href="add_students.aspx?id=<%=row.ItemArray[1]%>&msg=edit" class="btn btn-outline-success btn-sm">Edit</a></td>
                                      <td><a href="deletestudent.aspx?id=<%=row.ItemArray[1]%>" class="btn btn-outline-danger" onclick="return ConfirmDelete()" >Delete</a></td>--%>
                 

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


