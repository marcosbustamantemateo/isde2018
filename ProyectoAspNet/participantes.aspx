<%@ Page Title="" Language="C#" MasterPageFile="~/plantillaUsuLoagueado.Master" AutoEventWireup="true" CodeBehind="participantes.aspx.cs" Inherits="ProyectoAspNet.participantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <br /><br />
        <div class="row justify-content-center">
            <asp:Label ID="lbTitulo" runat="server" CssClass="display-4 centrar" Text="Participantes"></asp:Label>
        </div>
        <br />
        <div class="row justify-content-center">

        <asp:Label ID="lbVacio" runat="server" CssClass="centrar mt-2" Text="<br>No existen participantes" Visible="false"></asp:Label>

        <asp:GridView ID="gvParticipantes" runat="server" CssClass="centrar" AutoGenerateColumns="true" BorderStyle="None" 
            GridLines="Horizontal" OnRowDeleting="gvParticipantes_RowDeleting" OnRowEditing="gvParticipantes_RowEditing" OnLoad="gvParticipantes_Load">

        <HeaderStyle BackColor="#A9D0F5" Font-Bold="True" ForeColor="Black" />

        <Columns>          
            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" Text="Editar" CssClass="btn btn-success mb-2 mt-2" CommandName="Edit" />
                </ItemTemplate>
                
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>

            <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" CommandName="Delete" CssClass="btn btn-danger mb-2 mt-2" Text="Borrar" />
                </ItemTemplate>              
                
            </asp:TemplateField>
        </Columns>   
    </asp:GridView>
</div>
             <div class="row justify-content-center">
                 <div class="col-5 mb-5">
                    <asp:Label ID="lbConfirmarBorrado" runat="server" Visible="False">

                        <div class="jumbotron mt-5">
                          <h1>Confirmación de borrado</h1>
                          <hr class="my-4">
                          <p>¿Esta seguro que desea borrar el registro seleccionado?</p>
                        </div>
                    </asp:Label>
                      <asp:Button ID="btnCancelarBorrado" class="btn btn-primary btn-lg mr-2" runat="server" Text="Cancelar" Visible="false" OnClick="btnCancelarBorrado_Click" />
                    <asp:Button ID="btnConfirmarBorrado" class="btn btn-danger btn-lg ml-2" runat="server" Text="Borrar" Visible="false" OnClick="BtnConfirmarBorrado_Click1" />

                </div>
            </div>
        
        <div class="row justify-content-center mb-5">

                 <div class="col-5 mb-5">
                    <asp:Label ID="lbMenuAnadir" runat="server" Text="">


                <div class="card-header">
    	            <h2 class="centrar">
                        <asp:Label ID="lbParticipante" runat="server" Text="Label">Nuevo Participante</asp:Label>

    	            </h2>
                            
  		        </div>

				<div class="card">				
				    <div class="card-body izquierda">
                        <asp:Label ID="lbId" runat="server" Text="Label" Visible="false">
                            <div class="form-group">
		                        <label for="id">ID</label>
                                <asp:TextBox ID="txId" type="number" min="1" max="999" class="form-control" runat="server" autofocus></asp:TextBox>
	                        </div>
                        </asp:Label>
                         
                        <div class="form-group">
		                    <label for="nombre">Nombre</label>
                            <asp:TextBox ID="txNombre" class="form-control" runat="server" autofocus></asp:TextBox>
	                    </div>                            

	                    <div class="form-group">
		                    <label for="apellidos">Apellidos</label>
		                    <asp:TextBox ID="txApellidos" class="form-control" runat="server" autofocus></asp:TextBox>
                        </div>

	                    <div class="form-group">
		                    <label for="dorsal">Dorsal</label>
                            <asp:TextBox ID="txDorsal" type="number" min="1" max="999" class="form-control" runat="server" autofocus></asp:TextBox>
                            </div>  
                        
                        <div class="form-group">
		                    <label for="dorsal">Categoria</label>
                            <asp:DropDownList ID="cbCategorias" runat="server" CssClass="form-control"></asp:DropDownList>
	                    </div>
                        

                        <asp:Button ID="btnAnadirParticipante" class="btn btn-block btn-primary btn-lg" runat="server" Text="Añadir" OnClick="btnAnadirParticipante_Click" />
                    </div>
                </div>

                    </asp:Label>
                     
                </div>
            </div>
            
        
    </main>
</asp:Content>
