<%@ Page Title="" Language="C#" MasterPageFile="~/plantilla.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ProyectoAspNet.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>  <!-- Siempre necesario -->

        
        <asp:Label ID="lbMensajeInicio" runat="server" Text="Label" Visible="False"><br /> <h2 class="centrar"></asp:Label>
        <asp:Label ID="lbMensaje" runat="server" Text="Label" Visible="False" ForeColor="Red"></asp:Label>
        <asp:Label ID="lbMensajeFinal" runat="server" Text="Label" Visible="False"></h2></asp:Label>

        <div class="row justify-content-center mt-5">
			
		    <div class="col-md-4">

                <div class="card-header">
    	            <h4 class="centrar">Inicia Sesión</h4>
  		        </div>

				<div class="card">				
				    <div class="card-body izquierda">	
                        
                        <p class="centrar"><asp:Label ID="txError" runat="server" Text="Usuario y/o Password Incorrecto" Visible="False" ForeColor="Red"></asp:Label></p>

		                <p class="card-text"> 
                            
			                <div class="form-group row centrar">
			                    <label for="nombreLogin">Login</label>
                                    <asp:TextBox ID="txLogin" class="form-control" runat="server" autofocus></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*No puede estar vacio" ControlToValidate="txLogin" ForeColor="Red" ValidationGroup="Login"></asp:RequiredFieldValidator>
			                </div>                            

			                <div class="form-group row">
			                    <label for="nombrePassword">Clave</label>
			                     <asp:TextBox ID="txPass" type="password" class="form-control" runat="server" autofocus></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*No puede estar vacio" ControlToValidate="txPass" ForeColor="Red" ValidationGroup="Login"></asp:RequiredFieldValidator>
                            </div>
                 
                            <asp:Button ID="btnEnviar" runat="server" Text="Enviar" class="btn btn-primary btn-lg btn-block" OnClick="btnEnviar_Click" ValidationGroup="Login" />
                        </p>                       
                    </div>
                </div>
            </div>

            <div class="col-md-5">

                <div class="card-header">
    	            <h4 class="centrar">Registrate</h4>
  		        </div>

				<div class="card">				
				    <div class="card-body izquierda">	
                        
                        <p class="centrar"><asp:Label ID="Label1" runat="server" Text="Usuario y/o Password Incorrecto" Visible="False" ForeColor="Red"></asp:Label></p>

		                <p class="card-text"> 
                            
                            <div class="form-group row">
			                    <label for="nombreLogin">Nombre</label>
                                <asp:TextBox ID="txNombre" class="form-control" runat="server" autofocus></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*No puede estar vacio" ControlToValidate="txNombre" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>			                    
                            </div>                            

			                <div class="form-group row">
			                    <label for="nombrePassword">Apellidos</label>
			                    <asp:TextBox ID="txApellidos" class="form-control" runat="server" autofocus></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*No puede estar vacio" ControlToValidate="txApellidos" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group row">
			                    <label for="nombrePassword">Alias</label>
			                    <asp:TextBox ID="txAlias" class="form-control" runat="server" autofocus></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*No puede estar vacio" ControlToValidate="txAlias" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
                            </div>

			                <div class="form-group row">
			                    <label for="nombreLogin">Login</label>
                                <asp:TextBox ID="txLoginReg" class="form-control" runat="server" autofocus></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*No puede estar vacio" ControlToValidate="txLoginReg" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
			                </div>                            

			                <div class="form-group row">
			                    <label for="nombrePassword">Clave</label>
			                    <asp:TextBox ID="txPassReg" class="form-control" runat="server" autofocus TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*No puede estar vacio" ControlToValidate="txPassReg" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
                            </div>

                             <div class="form-group row">
			                    <label for="nombrePassword">Repetir clave</label>
			                    <asp:TextBox ID="txPassRepetir" class="form-control" runat="server" autofocus TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*No puede estar vacio" ControlToValidate="txPassReg" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*Las claves no coinciden" ControlToValidate="txPassRepetir" ForeColor="Red" ValidationGroup="Registro" ControlToCompare="txPassReg"></asp:CompareValidator>
                             </div>

                            <asp:Button ID="Button1" runat="server" Text="Enviar" class="btn btn-primary btn-lg btn-block" OnClick="btnRegistrar_Click" ValidationGroup="Registro" />
                        </p>                       
                    </div>
                </div>
            </div>
        </div>
        
        <br /><br /> <br />

    </main>
</asp:Content>
