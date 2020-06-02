<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="View_Ledgers.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-wrapper">
		  <h3 class="page-heading mb-4">Leadgers</h3>

		  <div class="card-deck">
			<div class="card col-lg-12 px-0 mb-4">
			  <div class="card-body">
				<h5 class="card-title">List of Leadgers</h5>
				

				<div class="table-responsive">
				 <table class="table">
            <thead>
              <tr>
                <th scope="col">ID</th>
                  <th scope="col">HASH</th>
                
                 
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
                                    <td><%=row["Hash"]%></td>
                                    
                                    <td><a href="Ledgers.aspx?id=<%=row.ItemArray[0]%>" class="btn btn-outline-danger"  >View</a></td>
<%--                                      <td><a href="deletefile.aspx?id=<%=row.ItemArray[0]%>" class="btn btn-outline-danger" onclick="return ConfirmDelete()" >Delete</a></td>--%>
                 

                                 </tr>
                            </tbody>
                           
                     <%  }
                      
                       
                   }%>
                   <%  else
                 {%>
                       Response.Write("<script>alert('No Data Found')</script>");
                   <%}%> 
           
          </table>
				</div>
			  </div>
			</div>
		  </div>
		</div>
</asp:Content>

