<%@ Page Title="" Language="C#" MasterPageFile="~/plantillaUsuLoagueado.Master" AutoEventWireup="true" CodeBehind="loggedHome.aspx.cs" Inherits="ProyectoAspNet.loggedHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <br />
        
        <div class="row justify-content-center">
			
           <asp:Label ID="lbDeshabilitado" CssClass="display-4" runat="server" Text="" ForeColor="Red" Visible="false">Su cuenta se encuentra deshabilitada, contacte con el administrador</asp:Label>


		    <div class="col-md-5 ml-4 mr-4 mt-2">

                <div class="card-header">
                    <h2 class="centrar">
    	                <asp:Label ID="lbNombreUsu" runat="server" Text=""></asp:Label> 
                        <asp:Label ID="lbNombreEdit" runat="server" Text=""></asp:Label>
                    </h2>
  		        </div>

				<div class="card">				
				    <div class="card-body izquierda">
                        <asp:Label ID="lbEdit" runat="server" Text="" Visible="false"></asp:Label>

                        <asp:Label ID="Label1" runat="server" Text="" Visible="false">
                            <div class="form-group">
		                        <label for="id">ID</label>
                                <asp:TextBox ID="txId" type="number" min="1" max="999" class="form-control" runat="server" autofocus></asp:TextBox>
	                       </div>
                        </asp:Label>

                        <div class="form-group">
		                    <label for="nombreLogin">Nombre</label>
                            <asp:TextBox ID="txNombre" class="form-control" runat="server" autofocus></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*No puede estar vacio" ControlToValidate="txNombre" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
	                    </div>                            

	                    <div class="form-group">
		                    <label for="nombrePassword">Apellidos</label>
		                    <asp:TextBox ID="txApellidos" class="form-control" runat="server" autofocus></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*No puede estar vacio" ControlToValidate="txApellidos" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
		                    <label for="nombrePassword">Alias</label>
		                    <asp:TextBox ID="txAlias" class="form-control" runat="server" autofocus></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*No puede estar vacio" ControlToValidate="txAlias" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
                        </div>

	                    <div class="form-group">
		                    <label for="nombreLogin">Login</label>
                            <asp:TextBox ID="txLoginReg" class="form-control" runat="server" autofocus></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*No puede estar vacio" ControlToValidate="txLoginReg" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
	                    </div>                            

	                    <div class="form-group" controltovalidate="txPassReg">
		                    <label for="nombrePassword">Clave</label>
		                    <asp:TextBox ID="txPassReg" type="password" class="form-control" runat="server" autofocus TextMode="SingleLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*No puede estar vacio" ControlToValidate="txPassReg" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
                        </div>

                        <asp:Label ID="lbTipoUsu" runat="server" Text="">
                         <div class="form-group" controltovalidate="txPassReg">
		                    <label for="tipoUsuario">Tipo de usuario</label>
                             <asp:DropDownList ID="cbTipoUsuario" class="form-control" runat="server"></asp:DropDownList>
                        </div>
                        </asp:Label>

                        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" class="btn btn-primary btn-lg btn-block" ValidationGroup="Registro" OnClick="btnActualizar_Click" />
                    </div>
                </div>
            </div>
            <br />
            <asp:Label ID="abreCol" runat="server" Text=""><div class="col mt-5"></asp:Label>
            <asp:Label ID="gv" runat="server" Text="">

                <asp:GridView ID="gvUsuarios" runat="server" CssClass="centrar" AutoGenerateColumns="true" BorderStyle="None" 
                    GridLines="Horizontal" OnRowDeleting="gvUsuarios_RowDeleting" OnRowEditing="gvUsuarios_RowEditing" OnRowDataBound="gvUsuarios_RowDataBound1" OnLoad="gvUsuarios_Load">

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

                <asp:Label ID="lbConfirmarBorrado" runat="server" Visible="false">

                    <div class="jumbotron mt-5">
                        <h1>Confirmación de borrado</h1>
                        <hr class="my-4">
                        <p>¿Esta seguro que desea borrar el registro seleccionado?</p>
                    </div>
                </asp:Label>
                <asp:Button ID="btnCancelarBorrado" class="btn btn-primary btn-lg mr-2" runat="server" Text="Cancelar" Visible="false" OnClick="btnCancelarBorrado_Click" />
                <asp:Button ID="btnConfirmarBorrado" class="btn btn-danger btn-lg ml-2" runat="server" Text="Borrar" Visible="false" OnClick="btnConfirmarBorrado_Click" />
            </asp:Label>
            <asp:Label ID="cierraCol" runat="server" Text=""></div></asp:Label>    
        

        </div>

        <br /><br /> <br />
    </main>
</asp:Content>
